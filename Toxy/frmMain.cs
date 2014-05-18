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

using Microsoft.WindowsAPICodePack.Taskbar;

using SharpTox;

namespace Toxy
{
    public partial class frmMain : MetroForm
    {
        private Tox tox;
        private string id;
        private Thread connloop;

        private Dictionary<int, string> convdic = new Dictionary<int, string>();
        private Dictionary<int, string> groupdic = new Dictionary<int, string>();
        private Dictionary<ToxFile, frmFileTransfer> filetdic = new Dictionary<ToxFile, frmFileTransfer>();

        private Config config;

        private int current_number; //can be a groupnumber or a friendnumber
        private bool typing = false;

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

            //if (convdic.ContainsKey(friendnumber))
             //   convdic[friendnumber].ProcessFileControl((ToxFileControl)control_type);
        }

        private void OnFileData(int friendnumber, int filenumber, byte[] data)
        {
            ToxFile file = new ToxFile(friendnumber, filenumber);

            if (filetdic.ContainsKey(file))
                filetdic[file].AddData(data);
        }

        private void AddFileTransferControl(int friendnumber, int filenumber, ulong filesiz, string filename)
        {
            FileTransfer control = new FileTransfer(filenumber, friendnumber, filesiz, filename);
            control.StyleManager = metroStyleManager1;
            control.MouseClick += file_MouseClick;

            panelTransfers.Controls.Add(control);

            ReorganizePanel(panelTransfers, typeof(FileTransfer));
        }

        private void file_MouseClick(object sender, MouseEventArgs e)
        {
            //throw new NotImplementedException();
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
            foreach (Control control in panelGroups.Controls)
            {
                if (control.GetType() == typeof(Group))
                {
                    Group group = (Group)control;

                    if (group.GroupNumber == groupnumber)
                        group.ChangePeerCount(tox.GetGroupMemberCount(groupnumber));
                }
            }

            if (tabControl.SelectedTab == tabGroups)
                if (current_number == groupnumber)
                    lblUserstatus.Text = "Members: " + string.Join(", ", tox.GetGroupNames(groupnumber));
        }

        private void OnGroupAction(int groupnumber, int friendgroupnumber, string action)
        {
            action = string.Format(" * {0} {1}" + Environment.NewLine, tox.GetGroupMemberName(groupnumber, friendgroupnumber), action);

            if (groupdic.ContainsKey(groupnumber))
                groupdic[groupnumber] += action;
            else
                groupdic.Add(groupnumber, action);

            this.Flash();

            if (tabControl.SelectedTab != tabGroups)
                return;

            if (current_number != groupnumber)
                return;

            txtConversation.AppendText(action);
        }

        private void OnGroupMessage(int groupnumber, int friendgroupnumber, string message)
        {
            message = string.Format("<{0}> {1}" + Environment.NewLine, tox.GetGroupMemberName(groupnumber, friendgroupnumber), message);

            if (groupdic.ContainsKey(groupnumber))
                groupdic[groupnumber] += message;
            else
                groupdic.Add(groupnumber, message);

            this.Flash();

            if (tabControl.SelectedTab != tabGroups)
                return;

            if (current_number != groupnumber)
                return;

            txtConversation.AppendText(message);
        }

        private void OnGroupInvite(int friendnumber, string group_public_key)
        {
            this.Flash();

            if (MetroMessageBox.Show(this, "You have received an invite to join a group from \"" + tox.GetName(friendnumber) + "\". Would you like to join?", "Group invite received", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int groupnumber = tox.JoinGroup(friendnumber, group_public_key);

                if (groupnumber != -1)
                    AddGroupControl(groupnumber);
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

            if (tabControl.SelectedTab == tabFriends)
                if (current_number == friendnumber)
                    lblUsername.Text = newname;
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

            if (tabControl.SelectedTab == tabFriends)
                if (current_number == friendnumber)
                    lblUserstatus.Text = newstatus;
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
        }

        private void OnTypingChange(int friendnumber, bool is_typing)
        {
            if (tabControl.SelectedTab != tabFriends)
                return;

            if (current_number != friendnumber)
                return;

            if (is_typing)
                lblUsername.Text = tox.GetName(friendnumber) + " (typing...)";
            else
                lblUsername.Text = tox.GetName(friendnumber);
        }

        private void OnFriendAction(int friendnumber, string action)
        {
            action = string.Format(" * {0} {1}" + Environment.NewLine, tox.GetName(friendnumber), action);

            if (convdic.ContainsKey(friendnumber))
                convdic[friendnumber] += action;
            else
                convdic.Add(friendnumber, action);

            this.Flash();

            if (tabControl.SelectedTab != tabFriends)
                return;

            if (current_number != friendnumber)
                return;

            txtConversation.AppendText(action);
        }

        private void OnFriendMessage(int friendnumber, string message)
        {
            message = string.Format("<{0}> {1}" + Environment.NewLine, tox.GetName(friendnumber), message);

            if (convdic.ContainsKey(friendnumber))
                convdic[friendnumber] += message;
            else
                convdic.Add(friendnumber, message);

            this.Flash();

            if (tabControl.SelectedTab != tabFriends)
                return;

            if (current_number != friendnumber)
                return;

            txtConversation.AppendText(message);
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

            this.Flash();
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

            ReorganizePanel(panelFriends, typeof(Friend));
        }

        private void friend_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
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

            current_number = friend.FriendNumber;

            txtConversation.Text = "";

            if (convdic.ContainsKey(current_number))
                txtConversation.Text = convdic[current_number];

            if (e.Button == MouseButtons.Right)
                ctxMenuFriend.Show(Cursor.Position);
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

            foreach(Control control in panelFriends.Controls)
            {
                if (control.GetType() == typeof(Friend))
                {
                    Friend friend = (Friend)control;
                    friend.Selected = true;
                    friend.Invalidate();

                    lblUsername.Text = tox.GetName(friend.FriendNumber);
                    lblUserstatus.Text = tox.GetStatusMessage(friend.FriendNumber);

                    current_number = friend.FriendNumber;
                    break;
                }
            }

            tabControl.SelectedTab = tabFriends;

            connloop = new Thread(ConnectLoop);
            connloop.Start();

            InitThumbButtons();
        }

        private void InitThumbButtons()
        {
            if (!TaskbarManager.IsPlatformSupported)
                return;

            ThumbnailToolBarManager manager = TaskbarManager.Instance.ThumbnailToolBars;
            ThumbnailToolBarButton[] buttons = new ThumbnailToolBarButton[3];

            ThumbnailToolBarButton online = new ThumbnailToolBarButton(Toxy.Properties.Resources.toxy_online, "Online");
            online.Click += delegate(object sender, ThumbnailButtonClickedEventArgs args) { tox.SetUserStatus(ToxUserStatus.NONE); };
            buttons[0] = online;

            ThumbnailToolBarButton away = new ThumbnailToolBarButton(Toxy.Properties.Resources.toxy_away, "Away");
            away.Click += delegate(object sender, ThumbnailButtonClickedEventArgs args) { tox.SetUserStatus(ToxUserStatus.AWAY); };
            buttons[1] = away;

            ThumbnailToolBarButton busy = new ThumbnailToolBarButton(Toxy.Properties.Resources.toxy_busy, "Busy");
            busy.Click += delegate(object sender, ThumbnailButtonClickedEventArgs args) { tox.SetUserStatus(ToxUserStatus.BUSY); };
            buttons[2] = busy;

            manager.AddButtons(this.Handle, buttons);
        }

        private static ToxNode[] Nodes = new ToxNode[] {
            new ToxNode("192.184.81.118", 33445, "5CD7EB176C19A2FD840406CD56177BB8E75587BB366F7BB3004B19E3EDC04143", false),
            new ToxNode("107.161.21.13", 33445, "5848E6344856921AAF28DAB860C5816780FE0C8873AAC415C1B7FA7FAA4EF046", false),
            new ToxNode("37.187.46.132", 33445, "C021232F9AC83914A45DFCF242129B216FED5ED34683F385D932A66BC9178270", false),
        };

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            connloop.Abort();

            config.Save("toxy.cfg");

            tox.Save("data");
            tox.Kill();
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            frmAddFriend form = new frmAddFriend();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            int friendnumber = tox.AddFriend(form.ID, form.Message);
            AddFriendControl(friendnumber);

            tabControl.SelectedTab = tabFriends;
        }

        private void btnNewGroup_Click_1(object sender, EventArgs e)
        {
            int groupnumber = tox.NewGroup();

            if (groupnumber == -1)
                return;

            tabControl.SelectedTab = tabGroups;
            lblUsername.Text = "Groupchat #" + groupnumber.ToString();
            lblUserstatus.Text = "Members: ";

            AddGroupControl(groupnumber);
        }

        private void AddGroupControl(int groupnumber)
        {
            Group group = new Group(groupnumber);
            group.StyleManager = metroStyleManager1;
            group.MouseClick += group_MouseClick;

            panelGroups.Controls.Add(group);

            ReorganizePanel(panelGroups, typeof(Group));
        }

        private void group_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(e.Button == MouseButtons.Left || e.Button == MouseButtons.Right))
                return;

            foreach (Control control in panelGroups.Controls)
            {
                if (control.GetType() == typeof(Group))
                {
                    Group g = (Group)control;
                    g.Selected = false;
                    g.Invalidate();
                }
            }

            Group group = (Group)sender;
            group.Selected = true;
            group.Invalidate();

            lblUsername.Text = group.GroupName;
            lblUserstatus.Text = "Members: " + string.Join(", ", tox.GetGroupNames(group.GroupNumber));

            current_number = group.GroupNumber;

            txtConversation.Text = "";

            if (groupdic.ContainsKey(current_number))
                txtConversation.Text = groupdic[current_number];

            //if (e.Button == MouseButtons.Right)
                //ctxMenuGroup.Show(Cursor.Position);
        }

        private int GetGroupCount()
        {
            int count = 0;

            foreach (Control control in panelGroups.Controls)
                if (control.GetType() == typeof(Group))
                    count++;

            return count;
        }

        private void txtToSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            MetroTextBox box = (MetroTextBox)sender;

            if (e.KeyChar != Convert.ToChar(Keys.Return))
                return;

            if (tabControl.SelectedTab == tabFriends)
            {
                if (tox.GetFriendConnectionStatus(current_number) != 1)
                    return;

                if (box.Text.StartsWith("/me "))
                {
                    string action = box.Text.Substring(4);
                    tox.SendAction(current_number, action);

                    string line = string.Format(" * {0} {1}" + Environment.NewLine, tox.GetSelfName(), action);

                    txtConversation.AppendText(line);
                    box.Text = "";

                    if (convdic.ContainsKey(current_number))
                        convdic[current_number] += line;
                    else
                        convdic.Add(current_number, line);

                    e.Handled = true;
                }
                else
                {
                    tox.SendMessage(current_number, txtToSend.Text);

                    string line = string.Format("<{0}> {1}" + Environment.NewLine, tox.GetSelfName(), txtToSend.Text);

                    txtConversation.AppendText(line);
                    txtToSend.Text = "";

                    if (convdic.ContainsKey(current_number))
                        convdic[current_number] += line;
                    else
                        convdic.Add(current_number, line);

                    e.Handled = true;
                }
            }
            else if (tabControl.SelectedTab == tabGroups)
            {
                if (box.Text.StartsWith("/me "))
                {
                    string action = box.Text.Substring(4);
                    tox.SendGroupAction(current_number, action);

                    box.Text = "";
                    e.Handled = true;
                }
                else
                {
                    tox.SendGroupMessage(current_number, txtToSend.Text);

                    box.Text = "";
                    e.Handled = true;
                }
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            frmOptions form = new frmOptions(tox);
            form.Show();
        }

        private Friend GetSelectedFriend()
        {
            foreach(Control control in panelFriends.Controls)
                if (control.GetType() == typeof(Friend))
                    if (((Friend)control).Selected)
                        return (Friend)control;

            return null;
        }

        private void ReorganizePanel(MetroPanel panel, Type type)
        {
            int count = 0;
            foreach(Control control in panel.Controls)
            {
                if (control.GetType() == type)
                {
                    control.Location = new Point(0, 0 + count * 80);
                    count++;
                }
            }

            //panel.Invalidate();
        }

        private void ctxMenuFriendDelete_Click(object sender, EventArgs e)
        {
            Friend friend = GetSelectedFriend();
            if (friend == null)
                return;

            tox.DeleteFriend(friend.FriendNumber);
            panelFriends.Controls.Remove(friend);

            ReorganizePanel(panelFriends, typeof(Friend));
        }

        private void ctxMenuCopyID_Click(object sender, EventArgs e)
        {
            Friend friend = GetSelectedFriend();
            if (friend == null)
                return;

            Clipboard.SetText(tox.GetClientID(friend.FriendNumber));
        }

        private void txtToSend_TextChanged(object sender, EventArgs e)
        {
            if (!config["typing_detection"])
                return;

            if (tabControl.SelectedTab != tabFriends)
                return;

            MetroTextBox box = (MetroTextBox)sender;

            if (!string.IsNullOrEmpty(box.Text))
            {
                if (!typing)
                {
                    typing = true;
                    tox.SetUserIsTyping(current_number, true);
                }
            }
            else
            {
                if (typing)
                {
                    typing = false;
                    tox.SetUserIsTyping(current_number, false);
                }
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This functionality has not been implemented yet. Friends can send files to you though.");
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtConversation.Text = "";
            MetroTabControl control = (MetroTabControl)sender;

            if (control.SelectedTab == tabGroups)
            {
                foreach (Control ctrl in panelGroups.Controls)
                {
                    if (ctrl.GetType() == typeof(Group))
                    {
                        //this doesn't make any sense, I know, will fix this later
                        foreach(Control c in panelGroups.Controls)
                        {
                            if (c.GetType() == typeof(Group))
                            {
                                Group g = (Group)c;
                                g.Selected = false;
                                g.Invalidate();
                            }
                        }

                        Group group = (Group)ctrl;
                        group.Selected = true;
                        group.Invalidate();

                        lblUsername.Text = group.GroupName;
                        lblUserstatus.Text = "Members: " + string.Join(", ", tox.GetGroupNames(group.GroupNumber));

                        current_number = group.GroupNumber;

                        if (groupdic.ContainsKey(current_number))
                            txtConversation.Text = groupdic[current_number];

                        break;
                    }
                }
            }
            else if (tabControl.SelectedTab == tabFriends)
            {
                foreach (Control ctrl in panelFriends.Controls)
                {
                    if (ctrl.GetType() == typeof(Friend))
                    {
                        //this doesn't make any sense, I know, will fix this later
                        foreach (Control c in panelFriends.Controls)
                        {
                            if (c.GetType() == typeof(Friend))
                            {
                                Friend f = (Friend)c;
                                f.Selected = false;
                                f.Invalidate();
                            }
                        }

                        Friend friend = (Friend)ctrl;
                        friend.Selected = true;
                        friend.Invalidate();

                        lblUsername.Text = tox.GetName(friend.FriendNumber);
                        lblUserstatus.Text = tox.GetStatusMessage(friend.FriendNumber);

                        current_number = friend.FriendNumber;

                        if (convdic.ContainsKey(current_number))
                            txtConversation.Text = convdic[current_number];

                        break;
                    }
                }
            }
        }

        private void btnInviteAll_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != tabGroups)
                return;

            foreach (int friend in tox.GetFriendlist())
                tox.InviteFriend(friend, current_number);
        }
    }
}
