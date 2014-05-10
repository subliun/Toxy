using System;
using System.Windows.Forms;
using System.Drawing;

using MetroFramework.Controls;
using MetroFramework.Drawing;

namespace Toxy
{
    public partial class FriendRequest : MetroUserControl
    {
        public string ID;
        private string Message;

        public event EventHandler OnAccept;
        public event EventHandler OnDecline;

        public FriendRequest(string id, string message)
        {
            ID = id;
            Message = message;

            InitializeComponent();

            lblID.Text = id;
            lblMessage.Text = message;

            BackColor = MetroPaint.BackColor.Button.Normal(Theme);
        }

        public FriendRequest()
        {
            InitializeComponent();  
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (OnAccept != null)
                OnAccept(this, new EventArgs());
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            if (OnDecline != null)
                OnDecline(this, new EventArgs());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            //draw border
            Color color = MetroPaint.BackColor.Button.Normal(Theme);
            e.Graphics.DrawRectangle(new Pen(color, 5f), new Rectangle(new Point(0, 0), Size));
        }
    }
}
