using System;
using System.Drawing;

using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace Toxy
{
    public partial class Group : MetroUserControl
    {
        public int GroupNumber;
        public int PeerCount;

        public string GroupName;

        public bool Selected = false;
        public bool NewMessages = false;

        public Group(int groupnumber)
        {
            GroupNumber = groupnumber;

            TabStop = false;
            InitializeComponent();

            GroupName = "Groupchat #" + groupnumber.ToString();
            lblGroupname.Text = GroupName;
            lblGroupStatus.Text = "0 peers online";
        }

        public void ChangePeerCount(int count)
        {
            PeerCount = count;
            lblGroupStatus.Text = count.ToString() + " peers online";
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.FillEllipse(new SolidBrush(Color.LimeGreen), new Rectangle(new Point(Size.Width - 30, Size.Height / 2 - 10), new Size(15, 15)));

            if (NewMessages)
                e.Graphics.DrawEllipse(new Pen(Color.LimeGreen) { Width = 2 }, new Rectangle(new Point(Size.Width - 34, Size.Height / 2 - 14), new Size(23, 23)));

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
