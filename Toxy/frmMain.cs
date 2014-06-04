using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

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
        private ToxAv toxav;

        private string id;
        private Thread connloop;

        private Dictionary<int, string> convdic = new Dictionary<int, string>();
        private Dictionary<int, string> groupdic = new Dictionary<int, string>();

        private Config config;

        private int current_number; //can be a groupnumber or a friendnumber
        private bool typing = false;
        private int unread = 0;

        private frmCall callform;

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

            tox.OnReadReceipt += OnReadReceipt;

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

            toxav = new ToxAv(tox.GetPointer(), ToxAv.DefaultCodecSettings, 1);
            toxav.Invoker = BeginInvoke;
            toxav.OnInvite += toxav_OnInvite;
            toxav.OnStart += toxav_OnStart;
            toxav.OnStarting += toxav_OnStart;
        }

        private void toxav_OnStart(int call_index, IntPtr args)
        {
            if (callform == null)
                return;

            callform.Start();
        }

        private void toxav_OnInvite(int call_index, IntPtr args)
        {
            if (callform != null)
                return;

            if (MetroMessageBox.Show(this, "Someone is calling you, would you like to answer this call?", "Incoming call", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            callform = new frmCall(tox, toxav);
            callform.FormClosed += callform_FormClosed;
            callform.CallIndex = call_index;
            callform.Show();
            callform.Answer();
        }

        private void OnReadReceipt(int friendnumber, uint receipt)
        {
            Console.WriteLine("{0} has received message #{1}", tox.GetName(friendnumber), receipt);
        }

        private void OnFileControl(int friendnumber, int receive_send, int filenumber, int control_type, byte[] data)
        {
            foreach (Control control in panelTransfers.Controls)
            {
                if (control.GetType() == typeof(FileTransfer))
                {
                    FileTransfer ft = (FileTransfer)control;

                    if (!(ft.FileNumber == filenumber && ft.FriendNumber == friendnumber && !ft.Finished))
                        continue;

                    switch ((ToxFileControl)control_type)
                    {
                        case ToxFileControl.FINISHED:
                            {
                                if (ft.Stream != null)
                                    ft.Stream.Close();

                                ft.TransferFinished(false);
                                break;
                            }
                        case ToxFileControl.KILL:
                            {
                                if (ft.Stream != null)
                                    ft.Stream.Close();

                                ft.TransferFinished(true);
                                break;
                            }
                        case ToxFileControl.ACCEPT:
                            break;
                    }
                }
            }
        }

        private void OnFileData(int friendnumber, int filenumber, byte[] data)
        {
            foreach (Control control in panelTransfers.Controls)
            {
                if (control.GetType() == typeof(FileTransfer))
                {
                    FileTransfer ft = (FileTransfer)control;

                    if (!(ft.FileNumber == filenumber && ft.FriendNumber == friendnumber && !ft.Finished))
                        continue;

                    ft.AddData(data, tox.FileDataRemaining(friendnumber, filenumber, 1));
                }
            }
        }

        private FileTransfer AddFileTransferControl(int friendnumber, int filenumber, ulong filesiz, string filename)
        {
            FileTransfer control = new FileTransfer(filenumber, friendnumber, filesiz, filename);
            control.OnDeleteMe += control_OnDeleteMe;
            control.StyleManager = metroStyleManager1;

            panelTransfers.Controls.Add(control);

            ReorganizePanel(panelTransfers, typeof(FileTransfer));

            return control;
        }

        private void control_OnDeleteMe(object sender, EventArgs e)
        {
            panelTransfers.Controls.Remove((FileTransfer)sender);
            ReorganizePanel(panelTransfers, typeof(FileTransfer));
        }

        private void OnFileSendRequest(int friendnumber, int filenumber, ulong filesiz, string filename)
        {
            DialogResult result = MetroMessageBox.Show(this, string.Format("{0} wants to share {1} ({2} bytes) with you. Would you like to accept this file transfer?", tox.GetName(friendnumber), filename, filesiz), "Incoming filetransfer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            tox.FileSendControl(friendnumber, 1, filenumber, (int)ToxFileControl.ACCEPT, new byte[0]);

            FileTransfer control = AddFileTransferControl(friendnumber, filenumber, filesiz, filename);
            control.Stream = new FileStream(filename, FileMode.Create);

            tabControl.SelectedTab = tabTransfers;
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

            if (WindowState != FormWindowState.Normal)
            {
                unread++;
                //UpdateIcon(unread);
            }

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

            if (WindowState != FormWindowState.Normal)
            {
                unread++;
                //UpdateIcon(unread);
            }

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
            foreach (Control control in panelFriends.Controls)
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
                        BeginInvoke(((Action)(() => Text = "Toxy (Online)")));
                        connected = true;
                    }
                }
                else
                {
                    if (connected)
                        BeginInvoke(((Action)(() => Text = "Toxy (Offline)")));

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

            if (WindowState != FormWindowState.Normal)
            {
                unread++;
                //UpdateIcon(unread);
            }

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

            if (WindowState != FormWindowState.Normal)
            {
                unread++;
                //UpdateIcon(unread);
            }

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
            tox.SetSendsReceipts(friendnumber, true);

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
            {
                tox.SetSendsReceipts(friends[i], true);
                AddFriendControl(friends[i]);
            }

            foreach (Control control in panelFriends.Controls)
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

        /*private void UpdateIcon(int messagecount)
        {
            if (messagecount != 0)
            {
                Bitmap bitmap = new Bitmap((Bitmap)Toxy.Properties.Resources.toxy, new Size(10, 10));
                Graphics g = Graphics.FromImage(bitmap);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(new SolidBrush(Color.FromArgb(35, 31, 30)), new Rectangle(new Point(bitmap.Size.Width - 180, bitmap.Size.Height - 275), new Size(115, 115)));
                g.DrawString(messagecount.ToString(), new Font("Monospace", 115f, FontStyle.Bold), new SolidBrush(Color.White), new Point(bitmap.Size.Width - 178, bitmap.Size.Height - 285));
                g.Dispose();

                this.Icon = Icon.FromHandle(bitmap.GetHicon());
            }
            else
            {
                this.Icon = Icon.FromHandle(new Bitmap((Bitmap)Toxy.Properties.Resources.toxy, new Size(10, 10)).GetHicon());
            }
        }*/

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
            new ToxNode("144.76.60.215", 33445, "04119E835DF3E78BACF0F84235B300546AF8B936F035185E2A8E9E0A67C8924F", false)
        };

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && config["close_to_tray"])
            {
                e.Cancel = true;
                Hide();
            }
            else
            {
                if (callform != null)
                    callform.EndCall();

                connloop.Abort();
                connloop.Join();

                config.Save("toxy.cfg");

                tox.Save("data");
                tox.Kill();
            }
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            frmAddFriend form = new frmAddFriend();
            if (form.ShowDialog() != DialogResult.OK)
                return;

            int friendnumber = tox.AddFriend(form.ID, form.Message);
            tox.SetSendsReceipts(friendnumber, true);

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

            if (e.Button == MouseButtons.Right)
                ctxMenuGroup.Show(Cursor.Position);
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
            foreach (Control control in panelFriends.Controls)
                if (control.GetType() == typeof(Friend))
                    if (((Friend)control).Selected)
                        return (Friend)control;

            return null;
        }

        private void ReorganizePanel(MetroPanel panel, Type type)
        {
            panel.VerticalScroll.Value = 0;

            int count = 0;
            foreach (Control control in panel.Controls)
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
                btnInvite.Visible = true;
                btnCall.Visible = false;
                btnSendFile.Visible = false;

                foreach (Control ctrl in panelGroups.Controls)
                {
                    if (ctrl.GetType() == typeof(Group))
                    {
                        //this doesn't make any sense, I know, will fix this later
                        foreach (Control c in panelGroups.Controls)
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
                btnInvite.Visible = false;
                btnCall.Visible = true;
                btnSendFile.Visible = true;

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

        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trayMenuOpen_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void ctxMenuGroupDelete_Click(object sender, EventArgs e)
        {
            Group group = GetSelectedGroup();
            if (group == null)
                return;

            tox.DeleteGroupChat(group.GroupNumber);
            panelGroups.Controls.Remove(group);

            ReorganizePanel(panelGroups, typeof(Group));
        }

        private Group GetSelectedGroup()
        {
            foreach (Control control in panelGroups.Controls)
                if (control.GetType() == typeof(Group))
                    if (((Group)control).Selected)
                        return (Group)control;

            return null;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //gotta use this for now, apparently the gotfocus event doesn't even work
            if (WindowState == FormWindowState.Normal)
            {
                unread = 0;
                //UpdateIcon(unread);
            }
        }

        private void btnInvite_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab != tabGroups)
                return;

            ctxMenuInvite.Items.Clear();

            foreach(int friend in tox.GetFriendlist())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(tox.GetName(friend));
                item.Click += delegate(object s, EventArgs args) { if (!tox.InviteFriend(friend, current_number)) { MessageBox.Show("Could not send invite. Did you select a group?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); } };
                item.Tag = friend;

                ctxMenuInvite.Items.Add(item);
            }

            ctxMenuInvite.Show(btnInvite, new Point(0, btnInvite.Height));
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            if (callform != null)
                return;

            callform = new frmCall(tox, toxav);
            callform.FormClosed += callform_FormClosed;
            callform.Call(current_number, ToxAvCallType.Audio, 30);
            callform.Show();
        }

        private void callform_FormClosed(object sender, FormClosedEventArgs e)
        {
            callform = null;
        }
    }
}
