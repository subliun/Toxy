using System;
using System.Windows.Forms;

using MetroFramework.Forms;
using MetroFramework.Controls;

using SharpTox;

namespace Toxy
{
    public partial class frmGroupChat : MetroForm
    {
        public int GroupNumber;
        private Tox tox;

        public frmGroupChat(Tox tox, int groupnumber)
        {
            this.tox = tox;
            GroupNumber = groupnumber;

            InitializeComponent();
        }

        public void AppendMessage(int friendgroupnumber, string message)
        {
            string line = "<" + tox.GetGroupMemberName(GroupNumber, friendgroupnumber) + "> " + message;

            txtConversation.AppendText(line);
            txtConversation.AppendText(Environment.NewLine);
        }

        public void AppendAction(int friendgroupnumber, string action)
        {
            string line = " * " + tox.GetGroupMemberName(GroupNumber, friendgroupnumber) + " " + action;

            txtConversation.AppendText(line);
            txtConversation.AppendText(Environment.NewLine);
        }

        public void NamelistChange(int peernumber, ToxChatChange change)
        {
            string[] names = tox.GetGroupNames(GroupNumber);

            string label = "";
            foreach (string name in names)
            {
                if (string.IsNullOrEmpty(name))
                    label += "Unknown\n";
                else
                    label += name + "\n";
            }

            lblGroupMembers.Text = label;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            foreach(int friendnumber in tox.GetFriendlist())
                tox.InviteFriend(friendnumber, GroupNumber);
        }

        private void txtToSend_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            MetroTextBox box = (MetroTextBox)sender;

            if (e.KeyChar != Convert.ToChar(Keys.Return))
                return;

            if (box.Text.StartsWith("/me "))
            {
                string action = box.Text.Substring(4);
                tox.SendGroupAction(GroupNumber, action);
                box.Text = "";

                e.Handled = true;
            }
            else
            {
                tox.SendGroupMessage(GroupNumber, txtToSend.Text);
                txtToSend.Text = "";

                e.Handled = true;
            }
        }
    }
}
