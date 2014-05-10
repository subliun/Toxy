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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tabFriends = new MetroFramework.Controls.MetroTabPage();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabGroups = new MetroFramework.Controls.MetroTabPage();
            this.btnNewGroup = new MetroFramework.Controls.MetroButton();
            this.tabRequests = new MetroFramework.Controls.MetroTabPage();
            this.panelRequests = new MetroFramework.Controls.MetroPanel();
            this.tabOptions = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.toggleEncryption = new MetroFramework.Controls.MetroToggle();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.toggleTypeDetection = new MetroFramework.Controls.MetroToggle();
            this.txtKey = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.comboColor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.comboTheme = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.btnIDClipboard = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtStatus = new MetroFramework.Controls.MetroTextBox();
            this.txtName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tabAbout = new MetroFramework.Controls.MetroTabPage();
            this.linkGithub = new MetroFramework.Controls.MetroLink();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.panelFriends = new MetroFramework.Controls.MetroPanel();
            this.tabFriends.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.tabGroups.SuspendLayout();
            this.tabRequests.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFriends
            // 
            this.tabFriends.Controls.Add(this.panelFriends);
            this.tabFriends.Controls.Add(this.metroButton2);
            this.tabFriends.HorizontalScrollbarBarColor = true;
            this.tabFriends.HorizontalScrollbarHighlightOnWheel = false;
            this.tabFriends.HorizontalScrollbarSize = 10;
            this.tabFriends.Location = new System.Drawing.Point(4, 38);
            this.tabFriends.Name = "tabFriends";
            this.tabFriends.Size = new System.Drawing.Size(718, 400);
            this.tabFriends.TabIndex = 0;
            this.tabFriends.Text = "Friends";
            this.tabFriends.VerticalScrollbarBarColor = true;
            this.tabFriends.VerticalScrollbarHighlightOnWheel = false;
            this.tabFriends.VerticalScrollbarSize = 10;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(630, 16);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(75, 23);
            this.metroButton2.TabIndex = 2;
            this.metroButton2.Text = "Add";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabGroups);
            this.metroTabControl1.Controls.Add(this.tabRequests);
            this.metroTabControl1.Controls.Add(this.tabOptions);
            this.metroTabControl1.Controls.Add(this.tabFriends);
            this.metroTabControl1.Controls.Add(this.tabAbout);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Multiline = true;
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 3;
            this.metroTabControl1.Size = new System.Drawing.Size(726, 442);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tabGroups
            // 
            this.tabGroups.Controls.Add(this.btnNewGroup);
            this.tabGroups.HorizontalScrollbarBarColor = true;
            this.tabGroups.HorizontalScrollbarHighlightOnWheel = false;
            this.tabGroups.HorizontalScrollbarSize = 10;
            this.tabGroups.Location = new System.Drawing.Point(4, 38);
            this.tabGroups.Name = "tabGroups";
            this.tabGroups.Size = new System.Drawing.Size(718, 400);
            this.tabGroups.TabIndex = 3;
            this.tabGroups.Text = "Groups";
            this.tabGroups.VerticalScrollbarBarColor = true;
            this.tabGroups.VerticalScrollbarHighlightOnWheel = false;
            this.tabGroups.VerticalScrollbarSize = 10;
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Location = new System.Drawing.Point(626, 14);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(75, 23);
            this.btnNewGroup.TabIndex = 2;
            this.btnNewGroup.Text = "New group";
            this.btnNewGroup.UseSelectable = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // tabRequests
            // 
            this.tabRequests.Controls.Add(this.panelRequests);
            this.tabRequests.HorizontalScrollbarBarColor = true;
            this.tabRequests.HorizontalScrollbarHighlightOnWheel = false;
            this.tabRequests.HorizontalScrollbarSize = 10;
            this.tabRequests.Location = new System.Drawing.Point(4, 38);
            this.tabRequests.Name = "tabRequests";
            this.tabRequests.Size = new System.Drawing.Size(718, 400);
            this.tabRequests.TabIndex = 4;
            this.tabRequests.Text = "Requests";
            this.tabRequests.VerticalScrollbarBarColor = true;
            this.tabRequests.VerticalScrollbarHighlightOnWheel = false;
            this.tabRequests.VerticalScrollbarSize = 10;
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
            this.panelRequests.Size = new System.Drawing.Size(715, 385);
            this.panelRequests.TabIndex = 2;
            this.panelRequests.VerticalScrollbar = true;
            this.panelRequests.VerticalScrollbarBarColor = true;
            this.panelRequests.VerticalScrollbarHighlightOnWheel = false;
            this.panelRequests.VerticalScrollbarSize = 10;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.metroLabel11);
            this.tabOptions.Controls.Add(this.metroLabel10);
            this.tabOptions.Controls.Add(this.toggleEncryption);
            this.tabOptions.Controls.Add(this.metroLabel9);
            this.tabOptions.Controls.Add(this.toggleTypeDetection);
            this.tabOptions.Controls.Add(this.txtKey);
            this.tabOptions.Controls.Add(this.metroLabel8);
            this.tabOptions.Controls.Add(this.metroLabel7);
            this.tabOptions.Controls.Add(this.metroButton1);
            this.tabOptions.Controls.Add(this.comboColor);
            this.tabOptions.Controls.Add(this.metroLabel5);
            this.tabOptions.Controls.Add(this.comboTheme);
            this.tabOptions.Controls.Add(this.metroLabel4);
            this.tabOptions.Controls.Add(this.btnIDClipboard);
            this.tabOptions.Controls.Add(this.metroLabel3);
            this.tabOptions.Controls.Add(this.metroLabel2);
            this.tabOptions.Controls.Add(this.txtStatus);
            this.tabOptions.Controls.Add(this.txtName);
            this.tabOptions.Controls.Add(this.metroLabel1);
            this.tabOptions.HorizontalScrollbarBarColor = true;
            this.tabOptions.HorizontalScrollbarHighlightOnWheel = false;
            this.tabOptions.HorizontalScrollbarSize = 10;
            this.tabOptions.Location = new System.Drawing.Point(4, 38);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Size = new System.Drawing.Size(718, 400);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Options";
            this.tabOptions.VerticalScrollbarBarColor = true;
            this.tabOptions.VerticalScrollbarHighlightOnWheel = false;
            this.tabOptions.VerticalScrollbarSize = 10;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(367, 57);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(36, 19);
            this.metroLabel11.TabIndex = 17;
            this.metroLabel11.Text = "Style";
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(12, 187);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(124, 19);
            this.metroLabel10.TabIndex = 16;
            this.metroLabel10.Text = "Tox data encryption";
            // 
            // toggleEncryption
            // 
            this.toggleEncryption.AutoSize = true;
            this.toggleEncryption.Location = new System.Drawing.Point(175, 187);
            this.toggleEncryption.Name = "toggleEncryption";
            this.toggleEncryption.Size = new System.Drawing.Size(80, 17);
            this.toggleEncryption.TabIndex = 15;
            this.toggleEncryption.Text = "Off";
            this.toggleEncryption.UseSelectable = true;
            this.toggleEncryption.CheckedChanged += new System.EventHandler(this.toggleEncryption_CheckedChanged);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(12, 112);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(105, 19);
            this.metroLabel9.TabIndex = 14;
            this.metroLabel9.Text = "Typing detection";
            // 
            // toggleTypeDetection
            // 
            this.toggleTypeDetection.AutoSize = true;
            this.toggleTypeDetection.Location = new System.Drawing.Point(175, 114);
            this.toggleTypeDetection.Name = "toggleTypeDetection";
            this.toggleTypeDetection.Size = new System.Drawing.Size(80, 17);
            this.toggleTypeDetection.TabIndex = 13;
            this.toggleTypeDetection.Text = "Off";
            this.toggleTypeDetection.UseSelectable = true;
            // 
            // txtKey
            // 
            this.txtKey.Enabled = false;
            this.txtKey.Lines = new string[0];
            this.txtKey.Location = new System.Drawing.Point(112, 215);
            this.txtKey.MaxLength = 32767;
            this.txtKey.Name = "txtKey";
            this.txtKey.PasswordChar = '*';
            this.txtKey.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKey.SelectedText = "";
            this.txtKey.Size = new System.Drawing.Size(143, 23);
            this.txtKey.TabIndex = 1;
            this.txtKey.UseSelectable = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(12, 215);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(94, 19);
            this.metroLabel8.TabIndex = 12;
            this.metroLabel8.Text = "Encryption key";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(12, 156);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(81, 25);
            this.metroLabel7.TabIndex = 11;
            this.metroLabel7.Text = "Security";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(422, 258);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(122, 23);
            this.metroButton1.TabIndex = 10;
            this.metroButton1.Text = "Save Changes";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // comboColor
            // 
            this.comboColor.FormattingEnabled = true;
            this.comboColor.ItemHeight = 23;
            this.comboColor.Items.AddRange(new object[] {
            "Black",
            "White",
            "Silver",
            "Blue",
            "Green",
            "Lime",
            "Teal",
            "Orange",
            "Brown",
            "Pink",
            "Magenta",
            "Purple",
            "Red",
            "Yellow"});
            this.comboColor.Location = new System.Drawing.Point(367, 146);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(177, 29);
            this.comboColor.TabIndex = 9;
            this.comboColor.UseSelectable = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(367, 124);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(42, 19);
            this.metroLabel5.TabIndex = 2;
            this.metroLabel5.Text = "Color";
            // 
            // comboTheme
            // 
            this.comboTheme.FormattingEnabled = true;
            this.comboTheme.ItemHeight = 23;
            this.comboTheme.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.comboTheme.Location = new System.Drawing.Point(367, 79);
            this.comboTheme.Name = "comboTheme";
            this.comboTheme.Size = new System.Drawing.Size(177, 29);
            this.comboTheme.TabIndex = 8;
            this.comboTheme.UseSelectable = true;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel4.Location = new System.Drawing.Point(367, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(70, 25);
            this.metroLabel4.TabIndex = 7;
            this.metroLabel4.Text = "Theme";
            // 
            // btnIDClipboard
            // 
            this.btnIDClipboard.Location = new System.Drawing.Point(12, 258);
            this.btnIDClipboard.Name = "btnIDClipboard";
            this.btnIDClipboard.Size = new System.Drawing.Size(243, 23);
            this.btnIDClipboard.TabIndex = 6;
            this.btnIDClipboard.Text = "Copy ID to clipboard";
            this.btnIDClipboard.UseSelectable = true;
            this.btnIDClipboard.Click += new System.EventHandler(this.btnIDClipboard_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 56);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(68, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Username";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 85);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(43, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Status";
            // 
            // txtStatus
            // 
            this.txtStatus.Lines = new string[0];
            this.txtStatus.Location = new System.Drawing.Point(101, 85);
            this.txtStatus.MaxLength = 32767;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.PasswordChar = '\0';
            this.txtStatus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStatus.SelectedText = "";
            this.txtStatus.Size = new System.Drawing.Size(154, 23);
            this.txtStatus.TabIndex = 3;
            this.txtStatus.UseSelectable = true;
            // 
            // txtName
            // 
            this.txtName.Lines = new string[0];
            this.txtName.Location = new System.Drawing.Point(101, 56);
            this.txtName.MaxLength = 32767;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(154, 23);
            this.txtName.TabIndex = 2;
            this.txtName.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(12, 28);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(78, 25);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "General";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.linkGithub);
            this.tabAbout.Controls.Add(this.pictureBox1);
            this.tabAbout.Controls.Add(this.metroLabel6);
            this.tabAbout.HorizontalScrollbarBarColor = true;
            this.tabAbout.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAbout.HorizontalScrollbarSize = 10;
            this.tabAbout.Location = new System.Drawing.Point(4, 38);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Size = new System.Drawing.Size(718, 400);
            this.tabAbout.TabIndex = 2;
            this.tabAbout.Text = "About";
            this.tabAbout.VerticalScrollbarBarColor = true;
            this.tabAbout.VerticalScrollbarHighlightOnWheel = false;
            this.tabAbout.VerticalScrollbarSize = 10;
            // 
            // linkGithub
            // 
            this.linkGithub.Location = new System.Drawing.Point(280, 238);
            this.linkGithub.Name = "linkGithub";
            this.linkGithub.Size = new System.Drawing.Size(138, 23);
            this.linkGithub.TabIndex = 4;
            this.linkGithub.Text = "Contribute @ GitHub";
            this.linkGithub.UseSelectable = true;
            this.linkGithub.Click += new System.EventHandler(this.linkGithub_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Toxy.Properties.Resources.toxy2;
            this.pictureBox1.Location = new System.Drawing.Point(291, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(319, 73);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(52, 25);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Toxy";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // panelFriends
            // 
            this.panelFriends.AutoScroll = true;
            this.panelFriends.HorizontalScrollbarBarColor = true;
            this.panelFriends.HorizontalScrollbarHighlightOnWheel = false;
            this.panelFriends.HorizontalScrollbarSize = 10;
            this.panelFriends.Location = new System.Drawing.Point(3, 16);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(332, 381);
            this.panelFriends.TabIndex = 3;
            this.panelFriends.VerticalScrollbar = true;
            this.panelFriends.VerticalScrollbarBarColor = true;
            this.panelFriends.VerticalScrollbarHighlightOnWheel = false;
            this.panelFriends.VerticalScrollbarSize = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::Toxy.Properties.Resources.toxy2;
            this.BackImagePadding = new System.Windows.Forms.Padding(170, 15, 0, 0);
            this.BackMaxSize = 40;
            this.ClientSize = new System.Drawing.Size(766, 522);
            this.Controls.Add(this.metroTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Toxy (Offline)";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabFriends.ResumeLayout(false);
            this.metroTabControl1.ResumeLayout(false);
            this.tabGroups.ResumeLayout(false);
            this.tabRequests.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabPage tabFriends;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage tabOptions;
        private MetroFramework.Controls.MetroTabPage tabAbout;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtStatus;
        private MetroFramework.Controls.MetroTextBox txtName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTabPage tabGroups;
        private MetroFramework.Controls.MetroButton btnIDClipboard;
        private MetroFramework.Controls.MetroComboBox comboTheme;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroComboBox comboColor;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTabPage tabRequests;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox txtKey;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroToggle toggleTypeDetection;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroToggle toggleEncryption;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroPanel panelRequests;
        private MetroFramework.Controls.MetroButton btnNewGroup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLink linkGithub;
        private MetroFramework.Controls.MetroPanel panelFriends;

    }
}

