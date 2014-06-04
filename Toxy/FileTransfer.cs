using System;
using System.Drawing;
using System.IO;

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

        public FileStream Stream;

        public event EventHandler OnDeleteMe;

        public FileTransfer(int filenumber, int friendnumber, ulong filesize, string filename)
        {
            FileNumber = filenumber;
            FriendNumber = friendnumber;
            FileSize = filesize;
            FileName = filename;

            TabStop = false;
            InitializeComponent();

            lblDescription.Text = string.Format("Transferring {0}...", filename);
            lblProgress.Text = string.Format("0/{0}", filesize);
        }

        public void ChangeProgress(int value)
        {
            progressBar.Value = value;
        }

        public void TransferFinished(bool killed)
        {
            Finished = true;

            lblDescription.Text = "Transfer finished!";
            btnCancel.Text = "Close";
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

        public void AddData(byte[] data, ulong remaining)
        {
            if (Stream == null)
                throw new Exception("Unexpectedly received data");

            double value = (double)remaining / (double)FileSize;

            progressBar.Value = 100 - (int)(value * 100);
            lblProgress.Text = string.Format("{0}/{1}", FileSize - remaining, FileSize);

            Stream.Write(data, 0, data.Length);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (Finished)
            {
                OnDeleteMe(this, new EventArgs());
            }
            else
            {
                Stream.Close();
                File.Delete(FileName);

                OnDeleteMe(this, new EventArgs());
            }
        }
    }
}
