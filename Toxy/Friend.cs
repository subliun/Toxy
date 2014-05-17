using System;
using System.Drawing;
using System.Windows.Forms;

using SharpTox;

using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace Toxy
{
    public partial class Friend : MetroUserControl
    {
        public int FriendNumber;

        public ToxUserStatus Status;
        public string StatusMessage;
        public string Username;
        public bool IsOnline = false;

        public bool Selected = false;

        public Friend(int friendnumber)
        {
            FriendNumber = friendnumber;

            InitializeComponent();
        }

        public Friend()
        {
            InitializeComponent();
        }

        public void SetUsername(string username)
        {
            Username = username;
            lblUsername.Text = username;
        }

        public void SetStatusMessage(string message)
        {
            StatusMessage = message;
            lblStatus.Text = message;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //draw online status indicator
            Color statuscolor;
            if (IsOnline)
            {
                switch (Status)
                {
                    case ToxUserStatus.AWAY:
                        statuscolor = Color.Yellow;
                        break;
                    case ToxUserStatus.BUSY:
                        statuscolor = Color.Red;
                        break;
                    case ToxUserStatus.NONE:
                        statuscolor = Color.LimeGreen;
                        break;
                    default:
                        statuscolor = Color.Red;
                        break;
                }

                e.Graphics.FillEllipse(new SolidBrush(statuscolor), new Rectangle(new Point(Size.Width - 30, Size.Height / 2 - 10), new Size(15, 15)));
            }
            else
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red), new Rectangle(new Point(Size.Width - 30, Size.Height / 2 - 10), new Size(15, 15)));
            }

            //draw border
            Color bordercolor;
            if (!Selected)
                bordercolor = MetroPaint.BackColor.Button.Normal(Theme);
            else
                bordercolor = Color.White;

            e.Graphics.DrawRectangle(new Pen(bordercolor, 5f), new Rectangle(new Point(0, 0), Size));
        }

        private void Friend_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Selected = !Selected;
            Invalidate();
        }
    }
}
