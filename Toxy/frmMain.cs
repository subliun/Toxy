using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

using MetroFramework;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MetroFramework.Interfaces;
using MetroMessageBox = MetroFramework.MetroMessageBox;

using SharpTox;

namespace Toxy
{
    public partial class frmMain : MetroForm
    {
        private Tox tox;
        private string id;
        private Thread connloop;

        private Dictionary<int, frmConversation> convdic = new Dictionary<int, frmConversation>();
        private Dictionary<int, frmGroupChat> groupdic = new Dictionary<int, frmGroupChat>();
        private Dictionary<ToxFile, frmFileTransfer> filetdic = new Dictionary<ToxFile, frmFileTransfer>();

        private Config config;

        public frmMain()
        {
            InitializeComponent();

            tox = new Tox(false);
            tox.Invoker = BeginInvoke;
            tox.OnFriendRequest += OnFriendRequest;
            tox.OnFriendMessage += OnFriendMessage;
            tox.OnFriendAction += OnFriendAction;
            tox.OnUserStatus += OnUserStatus;
            tox.OnStatusMessage += OnStatusMessage;
            tox.OnConnectionStatusChanged += OnConnectionStatusChanged;
            tox.OnNameChange += OnNameChange;
            tox.OnTypingChange += OnTypingChange;

            tox.OnGroupInvite += OnGroupInvite;
            tox.OnGroupMessage += OnGroupMessage;
            tox.OnGroupAction += OnGroupAction;
            tox.OnGroupNamelistChange += OnGroupNamelistChange;

            tox.OnFileSendRequest += OnFileSendRequest;
            tox.OnFileData += OnFileData;
            tox.OnFileControl += OnFileControl;

            config = Config.Instance;
            if (!config.Load("toxy.cfg"))
                MessageBox.Show("Could not load toxy.cfg, using defaults", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (File.Exists("data"))
            {
                if (!tox.Load("data"))
                {
                    MessageBox.Show("Could not load tox data, this program will now exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }

            bool bootstrap_success = false;
            foreach (ToxNode node in Nodes)
                if (tox.BootstrapFromNode(node))
                    bootstrap_success = true;

            if (!bootstrap_success)
            {
                MessageBox.Show("Could not bootstrap from any of the default addresses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            tox.Start();

            id = tox.GetAddress();
        }

        private void OnFileControl(int friendnumber, int receive_send, int filenumber, int control_type, byte[] data)
        {
            ToxFile file = new ToxFile(friendnumber, filenumber);

            if (filetdic.ContainsKey(file))
                filetdic[file].ProcessFileControl((ToxFileControl)control_type);

            if (convdic.ContainsKey(friendnumber))
                convdic[friendnumber].ProcessFileControl((ToxFileControl)control_type);
        }

        private void OnFileData(int friendnumber, int filenumber, byte[] data)
        {
            ToxFile file = new ToxFile(friendnumber, filenumber);

            if (filetdic.ContainsKey(file))
                filetdic[file].AddData(data);
        }

        private void OnFileSendRequest(int friendnumber, int filenumber, ulong filesiz, string filename)
        {
            frmFileTransfer form = new frmFileTransfer(tox, friendnumber, filenumber, filesiz, filename, 1);
            form.FormClosed += fileform_FormClosed;
            form.OnTransferComplete += OnTransferComplete;
            form.Show();

            filetdic.Add(new ToxFile(friendnumber, filenumber), form);
        }

        private void OnTransferComplete(object sender, EventArgs e)
        {
            frmFileTransfer form = ((frmFileTransfer)sender);
            int filenumber = form.FileNumber;
            int friendnumber = form.FriendNumber;

            ToxFile file = new ToxFile(friendnumber, filenumber);

            if (!filetdic.ContainsKey(file))
                return; //this shouldn't happen

            filetdic.Remove(file);
        }

        private void fileform_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFileTransfer form = ((frmFileTransfer)sender);
            int filenumber = form.FileNumber;
            int friendnumber = form.FriendNumber;

            ToxFile file = new ToxFile(friendnumber, filenumber);

            if (!filetdic.ContainsKey(file))
                return; //this shouldn't happen

            filetdic.Remove(file);
        }

        private void OnGroupNamelistChange(int groupnumber, int peernumber, ToxChatChange change)
        {
            if (groupdic.ContainsKey(groupnumber))
                groupdic[groupnumber].NamelistChange(peernumber, change);
        }

        private void OnGroupAction(int groupnumber, int friendgroupnumber, string action)
        {
            if (!groupdic.ContainsKey(groupnumber))
            {
                frmGroupChat form = new frmGroupChat(tox, groupnumber);
                form.FormClosed += groupform_FormClosed;
                form.Show();
                form.AppendAction(friendgroupnumber, action);

                groupdic.Add(groupnumber, form);
            }
            else
            {
                groupdic[groupnumber].AppendAction(friendgroupnumber, action);
            }
        }

        private void OnGroupMessage(int groupnumber, int friendgroupnumber, string message)
        {
            if (!groupdic.ContainsKey(groupnumber))
            {
                frmGroupChat form = new frmGroupChat(tox, groupnumber);
                form.FormClosed += groupform_FormClosed;
                form.Show();
                form.AppendMessage(friendgroupnumber, message);

                groupdic.Add(groupnumber, form);
            }
            else
            {
                groupdic[groupnumber].AppendMessage(friendgroupnumber, message);
            }
        }

        private void groupform_FormClosed(object sender, FormClosedEventArgs e)
        {
            int groupnumber = ((frmGroupChat)sender).GroupNumber;

            if (!groupdic.ContainsKey(groupnumber))
                return; //this shouldn't happen

            groupdic.Remove(groupnumber);
        }

        private void OnGroupInvite(int friendnumber, string group_public_key)
        {
            if (MetroMessageBox.Show(this, "You have received an invite to join a group from \"" + tox.GetName(friendnumber) + "\". Would you like to join?", "Group invite received", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int groupnumber = tox.JoinGroup(friendnumber, group_public_key);

                if (groupnumber != -1)
                {
                    frmGroupChat form = new frmGroupChat(tox, groupnumber);
                    form.FormClosed += groupform_FormClosed;
                    form.Show();

                    groupdic.Add(groupnumber, form);
                }
            }
        }

        private void OnConnectionStatusChanged(int friendnumber, byte status)
        {
            foreach (Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend friend = (Friend)control;

                    if (friend.FriendNumber == friendnumber)
                    {
                        friend.IsOnline = status != 0;
                        friend.Invalidate();
                    }
                }
            }

            if (!convdic.ContainsKey(friendnumber))
                return;

            convdic[friendnumber].ChangeConnectionStatus(status);
        }

        private void OnNameChange(int friendnumber, string newname)
        {
            foreach(Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend friend = (Friend)control;

                    if (friend.FriendNumber == friendnumber)
                    {
                        friend.SetUsername(newname);
                        friend.Invalidate();
                    }            
                }
            }

            if (!convdic.ContainsKey(friendnumber))
                return;

            convdic[friendnumber].UpdateName(newname);
        }

        private void OnStatusMessage(int friendnumber, string newstatus)
        {
            foreach (Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend friend = (Friend)control;

                    if (friend.FriendNumber == friendnumber)
                    {
                        friend.SetStatusMessage(newstatus);
                        friend.Invalidate();
                    }
                }
            }

            if (!convdic.ContainsKey(friendnumber))
                return;

            convdic[friendnumber].UpdateStatusMessage(newstatus);
        }

        private void ConnectLoop()
        {
            bool connected = false;
            while (true)
            {
                if (tox.IsConnected())
                {
                    if (!connected)
                    {
                        Invoke(((Action)(() => Text = "Toxy (Online)")));
                        connected = true;
                    }
                }
                else
                {
                    if (connected)
                        Invoke(((Action)(() => Text = "Toxy (Offline)")));

                    connected = false;

                    foreach (ToxNode node in Nodes)
                        tox.BootstrapFromNode(node);
                }

                Thread.Sleep(2000);
            }
        }

        private void OnUserStatus(int friendnumber, ToxUserStatus status)
        {
            foreach (Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend friend = (Friend)control;

                    if (friend.FriendNumber == friendnumber)
                    {
                        friend.Status = status;
                        friend.Invalidate();
                    }
                }
            }

            if (!convdic.ContainsKey(friendnumber))
                return;

            convdic[friendnumber].UpdateStatus(status);
        }

        private void OnTypingChange(int friendnumber, bool is_typing)
        {
            if (!convdic.ContainsKey(friendnumber))
                return;

            convdic[friendnumber].ChangeTypingStatus(is_typing);
        }

        private void OnFriendAction(int friendnumber, string action)
        {
            if (!convdic.ContainsKey(friendnumber))
            {
                frmConversation form = new frmConversation(tox, friendnumber);
                form.FormClosed += convform_FormClosed;
                form.Show();
                form.AppendAction(action);

                convdic.Add(friendnumber, form);
            }
            else
            {
                convdic[friendnumber].AppendAction(action);
            }
        }

        private void OnFriendMessage(int friendnumber, string message)
        {
            if (!convdic.ContainsKey(friendnumber))
            {
                frmConversation form = new frmConversation(tox, friendnumber);
                form.FormClosed += convform_FormClosed;
                form.Show();
                form.AppendMessage(message);

                convdic.Add(friendnumber, form);
            }
            else
            {
                convdic[friendnumber].AppendMessage(message);
            }
        }

        private void OnFriendRequest(string id, string message)
        {
            FriendRequest req = new FriendRequest(id, message);
            req.Theme = Theme;
            req.Style = Style;
            req.Size = new Size(panelRequests.Size.Width - 20, req.Size.Height);
            req.Location = new Point(0, 0 + (panelRequests.Controls.Count - 2) * 100);
            req.OnAccept += req_OnAccept;
            req.OnDecline += req_OnDecline;
            panelRequests.Controls.Add(req);

            RefreshFriendRequestCount();
        }

        private void req_OnDecline(object sender, EventArgs e)
        {
            panelRequests.Controls.Remove((FriendRequest)sender);

            RefreshFriendRequestCount();
        }

        private void req_OnAccept(object sender, EventArgs e)
        {
            int friendnumber = tox.AddFriendNoRequest(((FriendRequest)sender).ID);
            panelRequests.Controls.Remove((FriendRequest)sender);

            RefreshFriendRequestCount();

            AddFriendControl(friendnumber);
        }

        private void AddFriendControl(int friendnumber)
        {
            Friend friend = new Friend(friendnumber);
            friend.StyleManager = metroStyleManager1;
            friend.SetUsername(tox.GetName(friendnumber));
            friend.Status = tox.GetUserStatus(friendnumber);
            friend.Location = new Point(0, 0 + (panelFriends.Controls.Count - 2) * 80);
            //friend.MouseDoubleClick += friendcontrol_MouseDoubleClick;
            friend.MouseClick += friend_MouseClick;

            if (tox.GetFriendConnectionStatus(friendnumber) == 0)
            {
                DateTime time = tox.GetLastOnline(friendnumber);
                friend.SetStatusMessage("Last online: " + time.ToShortDateString() + " " + time.ToShortTimeString());
            }
            else
            {
                friend.SetStatusMessage(tox.GetStatusMessage(friendnumber));
            }

            panelFriends.Controls.Add(friend);
        }

        private void friend_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            foreach (Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend f = (Friend)control;
                    f.Selected = false;
                    f.Invalidate();
                }
            }

            Friend friend = (Friend)sender;
            friend.Selected = true;
            friend.Invalidate();

            lblUsername.Text = tox.GetName(friend.FriendNumber);
            lblUserstatus.Text = tox.GetStatusMessage(friend.FriendNumber);
        }

        private void RefreshFriendRequestCount()
        {
            int count = panelRequests.Controls.Count - 2;
            if (count != 0)
                tabRequests.Text = string.Format("Requests [{0}]", count);
            else
                tabRequests.Text = "Requests";
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            int[] friends = tox.GetFriendlist();
            for (int i = 0; i < friends.Length; i++)
                AddFriendControl(friends[i]);

            //txtName.Text = tox.GetSelfName();
            //txtStatus.Text = tox.GetSelfStatusMessage();

            connloop = new Thread(ConnectLoop);
            connloop.Start();
        }

        private void friendcontrol_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            Friend friend = (Friend)sender;

            if (convdic.ContainsKey(friend.FriendNumber))
            {
                frmConversation conv = convdic[friend.FriendNumber];

                if (conv.WindowState == FormWindowState.Minimized)
                    conv.WindowState = FormWindowState.Normal;
                else
                    conv.FocusMe();
            }
            else
            {
                frmConversation form = new frmConversation(tox, friend.FriendNumber);
                form.FormClosed += convform_FormClosed;
                form.Show();

                convdic.Add(friend.FriendNumber, form);
            }

        }

        private void friendtile_Click(object sender, EventArgs e)
        {
            int friendnumber = (int)((MetroTile)sender).Tag;

            if (convdic.ContainsKey(friendnumber))
            {
                if (convdic[friendnumber] != null)
                {
                    convdic[friendnumber].WindowState = FormWindowState.Normal;
                    convdic[friendnumber].Focus();
                }
                else
                {
                    frmConversation form = new frmConversation(tox, friendnumber);
                    form.FormClosed += convform_FormClosed;
                    convdic[friendnumber] = form;

                    form.Show();
                }
            }
            else
            {
                frmConversation form = new frmConversation(tox, friendnumber);
                form.FormClosed += convform_FormClosed;
                convdic.Add(friendnumber, form);

                form.Show();
            }
        }

        private void convform_FormClosed(object sender, FormClosedEventArgs e)
        {
            int friendnumber = ((frmConversation)sender).FriendNumber;

            if (!convdic.ContainsKey(friendnumber))
                return; //this shouldn't happen

            convdic.Remove(friendnumber);
        }

        private static ToxNode[] Nodes = new ToxNode[] {
            new ToxNode("192.184.81.118", 33445, "5CD7EB176C19A2FD840406CD56177BB8E75587BB366F7BB3004B19E3EDC04143", false),
            new ToxNode("107.161.21.13", 33445, "5848E6344856921AAF28DAB860C5816780FE0C8873AAC415C1B7FA7FAA4EF046", false),
            new ToxNode("37.187.46.132", 33445, "C021232F9AC83914A45DFCF242129B216FED5ED34683F385D932A66BC9178270", false),
        };

        private void btnIDClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(id);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            connloop.Abort();

            config.Save("toxy.cfg");

            tox.Save("data");
            tox.Kill();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //tox.SetName(txtName.Text);
            //tox.SetStatusMessage(txtStatus.Text);
        }

        private void toggleEncryption_CheckedChanged(object sender, EventArgs e)
        {
            MetroToggle toggle = (MetroToggle)sender;

            /*if (!toggle.Checked)
                txtKey.Enabled = false;
            else
                txtKey.Enabled = true;*/
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            int groupnumber = tox.NewGroup();
            frmGroupChat form = new frmGroupChat(tox, groupnumber);
            form.FormClosed += groupform_FormClosed;
            form.Show();

            groupdic.Add(groupnumber, form);
        }

        private void linkGithub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Impyy/Toxy");
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            frmAddFriend form = new frmAddFriend();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            int friendnumber = tox.AddFriend(form.ID, form.Message);
            AddFriendControl(friendnumber);
        }

        private void btnNewGroup_Click_1(object sender, EventArgs e)
        {
            int groupnumber = tox.NewGroup();

            if (groupnumber != -1)
            {
                frmGroupChat groupchat = new frmGroupChat(tox, groupnumber);
                groupchat.Show();
            }
            else
            {
                MessageBox.Show("Could not create group");
            }
        }
    }
}
