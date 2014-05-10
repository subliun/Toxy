using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

using SharpTox;

using MetroFramework.Forms;
using MetroFramework.Controls;

namespace Toxy
{
    public partial class frmConversation : MetroForm
    {
        public int FriendNumber;
        private Tox tox;
        private ToxUserStatus status = ToxUserStatus.NONE;

        private frmFileTransfer transferform = null;

        private bool typing = false;

        public frmConversation(Tox tox, int friendnumber)
        {
            this.tox = tox;
            FriendNumber = friendnumber;

            InitializeComponent();

            string name = tox.GetName(friendnumber);
            if (string.IsNullOrEmpty(name))
                Text = tox.GetClientID(friendnumber);
            else
                Text = name;

            lblStatus.Text = tox.GetStatusMessage(friendnumber);
            status = tox.GetUserStatus(friendnumber);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Color color = Color.LimeGreen;

            switch (status)
            {
                case ToxUserStatus.BUSY:
                    color = Color.PaleVioletRed;
                    break;
                case ToxUserStatus.AWAY:
                    color = Color.Yellow;
                    break;
                case ToxUserStatus.NONE:
                    if (tox.GetFriendConnectionStatus(FriendNumber) == 0)
                        color = Color.Red;
                    else
                        color = Color.LimeGreen;
                    break;
                default:
                    color = Color.Red;
                    break;
            }

            e.Graphics.FillRectangle(new SolidBrush(color), new Rectangle(new Point(20, 27), new Size(5, 20)));
        }

        public void UpdateStatus(ToxUserStatus status)
        {
            this.status = status;
            Invalidate();
        }

        public void ProcessFileControl(ToxFileControl control)
        {
            if (transferform != null && !transferform.IsDisposed)
                transferform.ProcessFileControl(control);
        }

        public void UpdateStatusMessage(string newstatus)
        {
            lblStatus.Text = newstatus;
        }

        public void AppendMessage(string message)
        {
            string line = "<" + tox.GetName(FriendNumber) + "> " + message;

            txtConversation.AppendText(line);
            txtConversation.AppendText(Environment.NewLine);
        }

        public void AppendAction(string action)
        {
            string line = " * " + tox.GetName(FriendNumber) + " " + action;

            txtConversation.AppendText(line);
            txtConversation.AppendText(Environment.NewLine);
        }

        public void ChangeTypingStatus(bool is_typing)
        {
            if (is_typing)
                lblTyping.Text = tox.GetName(FriendNumber) + " is typing...";
            else
                lblTyping.Text = "";
        }

        public void ChangeConnectionStatus(byte status)
        {

        }

        private void txtToSend_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MetroTextBox box = (MetroTextBox)sender;

            if (e.KeyChar != Convert.ToChar(Keys.Return))
                return;

            if (tox.GetFriendConnectionStatus(FriendNumber) != 1)
                return;

            if (box.Text.StartsWith("/me "))
            {
                string action = box.Text.Substring(4);
                tox.SendAction(FriendNumber, action);

                string line = " * " + tox.GetSelfName() + " " + action;

                txtConversation.AppendText(line);
                txtConversation.AppendText(Environment.NewLine);
                box.Text = "";

                e.Handled = true;
            }
            else
            {
                tox.SendMessage(FriendNumber, txtToSend.Text);

                string line = "<" + tox.GetSelfName() + "> " + txtToSend.Text;

                txtConversation.AppendText(line);
                txtConversation.AppendText(Environment.NewLine);
                txtToSend.Text = "";

                e.Handled = true;
            }
        }

        public void UpdateName(string newname)
        {
            Text = newname;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (transferform != null)
                return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Choose a file to share";
            dialog.InitialDirectory = Environment.CurrentDirectory;

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            string filename = dialog.FileName;
            ulong filesize = (ulong)new FileInfo(filename).Length;

            transferform = new frmFileTransfer(tox, FriendNumber, -1, filesize, filename, 0);
            transferform.FormClosed += transfer_FormClosed;
            transferform.OnTransferComplete += OnTransferComplete;
            transferform.Show();
        }

        private void transfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            transferform = null;
        }

        private void OnTransferComplete(object sender, EventArgs e)
        {
            transferform = null;
        }

        private void txtToSend_TextChanged(object sender, EventArgs e)
        {
            MetroTextBox box = (MetroTextBox)sender;

            if (!string.IsNullOrEmpty(box.Text))
            {
                if (!typing)
                {
                    typing = true;
                    tox.SetUserIsTyping(FriendNumber, true);
                }
            }
            else
            {
                if (typing)
                {
                    typing = false;
                    tox.SetUserIsTyping(FriendNumber, false);
                }
            }
        }
    }
}
