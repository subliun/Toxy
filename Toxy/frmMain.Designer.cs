namespace Toxy
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelFriends = new MetroFramework.Controls.MetroPanel();
            this.panelRequests = new MetroFramework.Controls.MetroPanel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabFriends = new MetroFramework.Controls.MetroTabPage();
            this.tabRequests = new MetroFramework.Controls.MetroTabPage();
            this.tabGroups = new MetroFramework.Controls.MetroTabPage();
            this.panelGroups = new MetroFramework.Controls.MetroPanel();
            this.tabTransfers = new MetroFramework.Controls.MetroTabPage();
            this.panelTransfers = new MetroFramework.Controls.MetroPanel();
            this.txtToSend = new MetroFramework.Controls.MetroTextBox();
            this.btnAddFriend = new MetroFramework.Controls.MetroButton();
            this.btnOptions = new MetroFramework.Controls.MetroButton();
            this.btnNewGroup = new MetroFramework.Controls.MetroButton();
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.lblUserstatus = new MetroFramework.Controls.MetroLabel();
            this.btnSendFile = new MetroFramework.Controls.MetroButton();
            this.ctxMenuFriend = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.ctxMenuCopyID = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuFriendDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnInvite = new MetroFramework.Controls.MetroButton();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuGroup = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.ctxMenuGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMenuInvite = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.btnCall = new MetroFramework.Controls.MetroButton();
            this.dataConversation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabFriends.SuspendLayout();
            this.tabRequests.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.tabTransfers.SuspendLayout();
            this.ctxMenuFriend.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.ctxMenuGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataConversation)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFriends
            // 
            this.panelFriends.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFriends.AutoScroll = true;
            this.panelFriends.HorizontalScrollbar = true;
            this.panelFriends.HorizontalScrollbarBarColor = true;
            this.panelFriends.HorizontalScrollbarHighlightOnWheel = false;
            this.panelFriends.HorizontalScrollbarSize = 10;
            this.panelFriends.Location = new System.Drawing.Point(0, 13);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(342, 404);
            this.panelFriends.TabIndex = 3;
            this.panelFriends.VerticalScrollbar = true;
            this.panelFriends.VerticalScrollbarBarColor = true;
            this.panelFriends.VerticalScrollbarHighlightOnWheel = false;
            this.panelFriends.VerticalScrollbarSize = 10;
            // 
            // panelRequests
            // 
            this.panelRequests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelRequests.AutoScroll = true;
            this.panelRequests.HorizontalScrollbar = true;
            this.panelRequests.HorizontalScrollbarBarColor = true;
            this.panelRequests.HorizontalScrollbarHighlightOnWheel = false;
            this.panelRequests.HorizontalScrollbarSize = 10;
            this.panelRequests.Location = new System.Drawing.Point(0, 12);
            this.panelRequests.Name = "panelRequests";
            this.panelRequests.Size = new System.Drawing.Size(338, 405);
            this.panelRequests.TabIndex = 2;
            this.panelRequests.VerticalScrollbar = true;
            this.panelRequests.VerticalScrollbarBarColor = true;
            this.panelRequests.VerticalScrollbarHighlightOnWheel = false;
            this.panelRequests.VerticalScrollbarSize = 10;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.tabFriends);
            this.tabControl.Controls.Add(this.tabRequests);
            this.tabControl.Controls.Add(this.tabGroups);
            this.tabControl.Controls.Add(this.tabTransfers);
            this.tabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tabControl.Location = new System.Drawing.Point(23, 63);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 1;
            this.tabControl.Size = new System.Drawing.Size(346, 455);
            this.tabControl.TabIndex = 2;
            this.tabControl.TabStop = false;
            this.tabControl.UseSelectable = true;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabFriends
            // 
            this.tabFriends.Controls.Add(this.panelFriends);
            this.tabFriends.HorizontalScrollbarBarColor = true;
            this.tabFriends.HorizontalScrollbarHighlightOnWheel = false;
            this.tabFriends.HorizontalScrollbarSize = 10;
            this.tabFriends.Location = new System.Drawing.Point(4, 38);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Size = new System.Drawing.Size(338, 413);
            this.tabFriends.TabIndex = 0;
            this.tabFriends.Text = "Friends";
            this.tabFriends.VerticalScrollbarBarColor = true;
            this.tabFriends.VerticalScrollbarHighlightOnWheel = false;
            this.tabFriends.VerticalScrollbarSize = 10;
            // 
            // tabRequests
            // 
            this.tabRequests.Controls.Add(this.panelRequests);
            this.tabRequests.HorizontalScrollbarBarColor = true;
            this.tabRequests.HorizontalScrollbarHighlightOnWheel = false;
            this.tabRequests.HorizontalScrollbarSize = 10;
            this.tabRequests.Location = new System.Drawing.Point(4, 38);
            this.tabRequests.Name = "tabRequests";
            this.tabRequests.Size = new System.Drawing.Size(338, 413);
            this.tabRequests.TabIndex = 1;
            this.tabRequests.Text = "Requests";
            this.tabRequests.VerticalScrollbarBarColor = true;
            this.tabRequests.VerticalScrollbarHighlightOnWheel = false;
            this.tabRequests.VerticalScrollbarSize = 10;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.panelGroups);
            this.tabGroups.HorizontalScrollbarBarColor = true;
            this.tabGroups.HorizontalScrollbarHighlightOnWheel = false;
            this.tabGroups.HorizontalScrollbarSize = 10;
            this.tabGroups.Location = new System.Drawing.Point(4, 38);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(338, 413);
            this.tabGroups.TabIndex = 2;
            this.tabGroups.Text = "Groups";
            this.tabGroups.VerticalScrollbarBarColor = true;
            this.tabGroups.VerticalScrollbarHighlightOnWheel = false;
            this.tabGroups.VerticalScrollbarSize = 10;
            // 
            // panelGroups
            // 
            this.panelGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGroups.AutoScroll = true;
            this.panelGroups.HorizontalScrollbar = true;
            this.panelGroups.HorizontalScrollbarBarColor = true;
            this.panelGroups.HorizontalScrollbarHighlightOnWheel = false;
            this.panelGroups.HorizontalScrollbarSize = 10;
            this.panelGroups.Location = new System.Drawing.Point(0, 12);
            this.panelGroups.Name = "panelGroups";
            this.panelGroups.Size = new System.Drawing.Size(338, 392);
            this.panelGroups.TabIndex = 3;
            this.panelGroups.VerticalScrollbar = true;
            this.panelGroups.VerticalScrollbarBarColor = true;
            this.panelGroups.VerticalScrollbarHighlightOnWheel = false;
            this.panelGroups.VerticalScrollbarSize = 10;
            // 
            // tabTransfers
            // 
            this.tabTransfers.Controls.Add(this.panelTransfers);
            this.tabTransfers.HorizontalScrollbarBarColor = true;
            this.tabTransfers.HorizontalScrollbarHighlightOnWheel = false;
            this.tabTransfers.HorizontalScrollbarSize = 10;
            this.tabTransfers.Location = new System.Drawing.Point(4, 38);
            this.tabTransfers.Name = "tabTransfers";
            this.tabTransfers.Size = new System.Drawing.Size(338, 413);
            this.tabTransfers.TabIndex = 3;
            this.tabTransfers.Text = "Transfers";
            this.tabTransfers.VerticalScrollbarBarColor = true;
            this.tabTransfers.VerticalScrollbarHighlightOnWheel = false;
            this.tabTransfers.VerticalScrollbarSize = 10;
            // 
            // panelTransfers
            // 
            this.panelTransfers.HorizontalScrollbarBarColor = true;
            this.panelTransfers.HorizontalScrollbarHighlightOnWheel = false;
            this.panelTransfers.HorizontalScrollbarSize = 10;
            this.panelTransfers.Location = new System.Drawing.Point(0, 13);
            this.panelTransfers.Name = "panelTransfers";
            this.panelTransfers.Size = new System.Drawing.Size(338, 391);
            this.panelTransfers.TabIndex = 2;
            this.panelTransfers.VerticalScrollbarBarColor = true;
            this.panelTransfers.VerticalScrollbarHighlightOnWheel = false;
            this.panelTransfers.VerticalScrollbarSize = 10;
            // 
            // txtToSend
            // 
            this.txtToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSend.Lines = new string[0];
            this.txtToSend.Location = new System.Drawing.Point(375, 524);
            this.txtToSend.MaxLength = 32767;
            this.txtToSend.Name = "txtToSend";
            this.txtToSend.PasswordChar = '\0';
            this.txtToSend.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToSend.SelectedText = "";
            this.txtToSend.Size = new System.Drawing.Size(788, 23);
            this.txtToSend.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToSend.TabIndex = 0;
            this.txtToSend.UseSelectable = true;
            this.txtToSend.UseStyleColors = true;
            this.txtToSend.TextChanged += new System.EventHandler(this.txtToSend_TextChanged);
            this.txtToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSend_KeyPress);
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFriend.Location = new System.Drawing.Point(27, 524);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(113, 23);
            this.btnAddFriend.TabIndex = 1;
            this.btnAddFriend.Text = "Add friend";
            this.btnAddFriend.UseSelectable = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptions.Location = new System.Drawing.Point(265, 524);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(104, 23);
            this.btnOptions.TabIndex = 3;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseSelectable = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewGroup.Location = new System.Drawing.Point(146, 524);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(113, 23);
            this.btnNewGroup.TabIndex = 2;
            this.btnNewGroup.Text = "Create group";
            this.btnNewGroup.UseSelectable = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click_1);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblUsername.Location = new System.Drawing.Point(375, 79);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(0, 0);
            this.lblUsername.TabIndex = 8;
            // 
            // lblUserstatus
            // 
            this.lblUserstatus.AutoSize = true;
            this.lblUserstatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUserstatus.Location = new System.Drawing.Point(375, 98);
            this.lblUserstatus.Name = "lblUserstatus";
            this.lblUserstatus.Size = new System.Drawing.Size(0, 0);
            this.lblUserstatus.TabIndex = 9;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendFile.Location = new System.Drawing.Point(1088, 95);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 5;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseSelectable = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // ctxMenuFriend
            // 
            this.ctxMenuFriend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuCopyID,
            this.ctxMenuFriendDelete});
            this.ctxMenuFriend.Name = "ctxMenuFriend";
            this.ctxMenuFriend.Size = new System.Drawing.Size(153, 48);
            // 
            // ctxMenuCopyID
            // 
            this.ctxMenuCopyID.Name = "ctxMenuCopyID";
            this.ctxMenuCopyID.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuCopyID.Text = "Copy public ID";
            this.ctxMenuCopyID.Click += new System.EventHandler(this.ctxMenuCopyID_Click);
            // 
            // ctxMenuFriendDelete
            // 
            this.ctxMenuFriendDelete.Name = "ctxMenuFriendDelete";
            this.ctxMenuFriendDelete.Size = new System.Drawing.Size(152, 22);
            this.ctxMenuFriendDelete.Text = "Delete";
            this.ctxMenuFriendDelete.Click += new System.EventHandler(this.ctxMenuFriendDelete_Click);
            // 
            // btnInvite
            // 
            this.btnInvite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvite.Location = new System.Drawing.Point(1065, 95);
            this.btnInvite.Name = "btnInvite";
            this.btnInvite.Size = new System.Drawing.Size(98, 23);
            this.btnInvite.TabIndex = 6;
            this.btnInvite.Text = "Invite a friend";
            this.btnInvite.UseSelectable = true;
            this.btnInvite.Visible = false;
            this.btnInvite.Click += new System.EventHandler(this.btnInvite_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Toxy";
            this.trayIcon.Visible = true;
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuOpen,
            this.trayMenuExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(132, 48);
            // 
            // trayMenuOpen
            // 
            this.trayMenuOpen.Name = "trayMenuOpen";
            this.trayMenuOpen.Size = new System.Drawing.Size(131, 22);
            this.trayMenuOpen.Text = "Open Toxy";
            this.trayMenuOpen.Click += new System.EventHandler(this.trayMenuOpen_Click);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(131, 22);
            this.trayMenuExit.Text = "Exit";
            this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);
            // 
            // ctxMenuGroup
            // 
            this.ctxMenuGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMenuGroupDelete});
            this.ctxMenuGroup.Name = "ctxMenuGroup";
            this.ctxMenuGroup.Size = new System.Drawing.Size(108, 26);
            // 
            // ctxMenuGroupDelete
            // 
            this.ctxMenuGroupDelete.Name = "ctxMenuGroupDelete";
            this.ctxMenuGroupDelete.Size = new System.Drawing.Size(107, 22);
            this.ctxMenuGroupDelete.Text = "Delete";
            this.ctxMenuGroupDelete.Click += new System.EventHandler(this.ctxMenuGroupDelete_Click);
            // 
            // ctxMenuInvite
            // 
            this.ctxMenuInvite.Name = "ctxMenuInvite";
            this.ctxMenuInvite.Size = new System.Drawing.Size(61, 4);
            // 
            // btnCall
            // 
            this.btnCall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCall.Location = new System.Drawing.Point(1007, 95);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 5;
            this.btnCall.Text = "Call";
            this.btnCall.UseSelectable = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // dataConversation
            // 
            this.dataConversation.AllowUserToAddRows = false;
            this.dataConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataConversation.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataConversation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataConversation.ColumnHeadersVisible = false;
            this.dataConversation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataConversation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataConversation.Location = new System.Drawing.Point(375, 124);
            this.dataConversation.MultiSelect = false;
            this.dataConversation.Name = "dataConversation";
            this.dataConversation.RowHeadersVisible = false;
            this.dataConversation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataConversation.ShowEditingIcon = false;
            this.dataConversation.Size = new System.Drawing.Size(788, 390);
            this.dataConversation.TabIndex = 10;
            this.dataConversation.SelectionChanged += new System.EventHandler(this.dataConversation_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.HeaderText = "Username";
            this.Column1.Name = "Column1";
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Messages";
            this.Column2.Name = "Column2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::Toxy.Properties.Resources.toxy2;
            this.BackImagePadding = new System.Windows.Forms.Padding(170, 15, 0, 0);
            this.BackMaxSize = 40;
            this.ClientSize = new System.Drawing.Size(1178, 561);
            this.Controls.Add(this.dataConversation);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnInvite);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.lblUserstatus);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.txtToSend);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Toxy (Offline)";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabFriends.ResumeLayout(false);
            this.tabRequests.ResumeLayout(false);
            this.tabGroups.ResumeLayout(false);
            this.tabTransfers.ResumeLayout(false);
            this.ctxMenuFriend.ResumeLayout(false);
            this.trayMenu.ResumeLayout(false);
            this.ctxMenuGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataConversation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelRequests;
        private MetroFramework.Controls.MetroPanel panelFriends;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage tabFriends;
        private MetroFramework.Controls.MetroTabPage tabRequests;
        private MetroFramework.Controls.MetroTextBox txtToSend;
        private MetroFramework.Controls.MetroButton btnOptions;
        private MetroFramework.Controls.MetroButton btnAddFriend;
        private MetroFramework.Controls.MetroButton btnNewGroup;
        private MetroFramework.Controls.MetroLabel lblUserstatus;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroButton btnSendFile;
        private MetroFramework.Controls.MetroTabPage tabGroups;
        private MetroFramework.Controls.MetroTabPage tabTransfers;
        private MetroFramework.Controls.MetroContextMenu ctxMenuFriend;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuFriendDelete;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuCopyID;
        private MetroFramework.Controls.MetroPanel panelGroups;
        private MetroFramework.Controls.MetroButton btnInvite;
        private MetroFramework.Controls.MetroPanel panelTransfers;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.ToolStripMenuItem trayMenuOpen;
        private MetroFramework.Controls.MetroContextMenu ctxMenuGroup;
        private System.Windows.Forms.ToolStripMenuItem ctxMenuGroupDelete;
        private MetroFramework.Controls.MetroContextMenu ctxMenuInvite;
        private MetroFramework.Controls.MetroButton btnCall;
        private System.Windows.Forms.DataGridView dataConversation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

    }
}

