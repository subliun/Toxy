using System;
using System.Drawing;

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

        public FileTransfer(int filenumber, int friendnumber, ulong filesize, string filename)
        {
            FileNumber = filenumber;
            FriendNumber = friendnumber;
            FileSize = filesize;
            FileName = filename;

            InitializeComponent();

            lblDescription.Text = string.Format("Transferring {0}...", filename);
            lblProgress.Text = string.Format("0/{0}", filesize);
        }

        public void ChangeProgress(int value)
        {
            progressBar.Value = value;
        }

        public void TransferFinished()
        {
            
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.FillEllipse(new SolidBrush(Color.LimeGreen), new Rectangle(new Point(Size.Width - 30, Size.Height / 2 - 10), new Size(15, 15)));

            //draw border
            Color bordercolor;
            if (!Selected)
                bordercolor = MetroPaint.BackColor.Button.Normal(Theme);
            else
                bordercolor = Color.White;

            e.Graphics.DrawRectangle(new Pen(bordercolor, 5f), new Rectangle(new Point(0, 0), Size));
        }
    }
}
