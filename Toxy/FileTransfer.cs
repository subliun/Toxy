using System;
using System.Drawing;
using System.IO;
using System.Threading;

using SharpTox;

using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace Toxy
{
    public partial class FileTransfer : MetroUserControl
    {
        public int FileNumber;
        public int FriendNumber;
        public ulong FileSize;
        public string FileName;

        public bool Selected = false;
        public bool Finished = false;
        public bool Sending = false;

        public FileStream Stream;
        public Thread Thread;

        public event EventHandler OnDeleteMe;

        private Tox tox;

        public FileTransfer(Tox tox, int filenumber, int friendnumber, ulong filesize, string filename, bool sending)
        {
            FileNumber = filenumber;
            FriendNumber = friendnumber;
            FileSize = filesize;
            FileName = filename;
            Sending = sending;

            this.tox = tox;

            TabStop = false;
            InitializeComponent();

            lblDescription.Text = string.Format("Transferring {0}...", filename);
            lblProgress.Text = string.Format("0/{0}", filesize);
        }

        public void ChangeProgress(int value)
        {
            BeginInvoke(((Action)(() => progressBar.Value = value)));
        }

        public void ChangeStatus(string status)
        {
            BeginInvoke(((Action)(() => lblProgress.Text = status)));
        }

        public void TransferFinished(bool killed)
        {
            Finished = true;

            BeginInvoke(((Action)(() =>
                {
                    lblDescription.Text = "Transfer finished!";
                    btnCancel.Text = "Close";
                })));

            if (Stream != null)
                Stream.Close();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //draw border
            Color bordercolor;
            if (!Selected)
                bordercolor = MetroPaint.BackColor.Button.Normal(Theme);
            else
                bordercolor = Color.White;

            e.Graphics.DrawRectangle(new Pen(bordercolor, 5f), new Rectangle(new Point(0, 0), Size));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Finished)
            {
                OnDeleteMe(this, new EventArgs());
            }
            else
            {
                if (Stream != null)
                    Stream.Close();

                if (!Sending)
                    File.Delete(FileName);

                tox.FileSendControl(FriendNumber, Sending ? 0 : 1, FileNumber, ToxFileControl.KILL, new byte[0]);

                OnDeleteMe(this, new EventArgs());
            }
        }
    }
}
