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
            this.panelFriends = new MetroFramework.Controls.MetroPanel();
            this.panelRequests = new MetroFramework.Controls.MetroPanel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.tabRequests = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.txtConversation = new MetroFramework.Controls.MetroTextBox();
            this.txtToSend = new MetroFramework.Controls.MetroTextBox();
            this.btnAddFriend = new MetroFramework.Controls.MetroButton();
            this.metroButton4 = new MetroFramework.Controls.MetroButton();
            this.btnNewGroup = new MetroFramework.Controls.MetroButton();
            this.lblUsername = new MetroFramework.Controls.MetroLabel();
            this.lblUserstatus = new MetroFramework.Controls.MetroLabel();
            this.metroButton6 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabRequests.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
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
            this.panelFriends.Location = new System.Drawing.Point(0, 3);
            this.panelFriends.Name = "panelFriends";
            this.panelFriends.Size = new System.Drawing.Size(338, 401);
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
            this.panelRequests.Location = new System.Drawing.Point(3, 12);
            this.panelRequests.Name = "panelRequests";
            this.panelRequests.Size = new System.Drawing.Size(332, 385);
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
            // tabRequests
            // 
            this.tabRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabRequests.Controls.Add(this.metroTabPage1);
            this.tabRequests.Controls.Add(this.metroTabPage2);
            this.tabRequests.Location = new System.Drawing.Point(23, 63);
            this.tabRequests.Name = "tabRequests";
            this.tabRequests.SelectedIndex = 1;
            this.tabRequests.Size = new System.Drawing.Size(346, 442);
            this.tabRequests.TabIndex = 2;
            this.tabRequests.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.panelFriends);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(338, 400);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Chats";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.panelRequests);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(338, 400);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Requests";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // txtConversation
            // 
            this.txtConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversation.Lines = new string[0];
            this.txtConversation.Location = new System.Drawing.Point(375, 124);
            this.txtConversation.MaxLength = 32767;
            this.txtConversation.Multiline = true;
            this.txtConversation.Name = "txtConversation";
            this.txtConversation.PasswordChar = '\0';
            this.txtConversation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConversation.SelectedText = "";
            this.txtConversation.Size = new System.Drawing.Size(788, 394);
            this.txtConversation.TabIndex = 3;
            this.txtConversation.UseSelectable = true;
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
            // 
            // btnAddFriend
            // 
            this.btnAddFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFriend.Location = new System.Drawing.Point(27, 511);
            this.btnAddFriend.Name = "btnAddFriend";
            this.btnAddFriend.Size = new System.Drawing.Size(113, 36);
            this.btnAddFriend.TabIndex = 5;
            this.btnAddFriend.Text = "Add friend";
            this.btnAddFriend.UseSelectable = true;
            this.btnAddFriend.Click += new System.EventHandler(this.btnAddFriend_Click);
            // 
            // metroButton4
            // 
            this.metroButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroButton4.Location = new System.Drawing.Point(265, 511);
            this.metroButton4.Name = "metroButton4";
            this.metroButton4.Size = new System.Drawing.Size(100, 36);
            this.metroButton4.TabIndex = 6;
            this.metroButton4.Text = "Options";
            this.metroButton4.UseSelectable = true;
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewGroup.Location = new System.Drawing.Point(146, 511);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(113, 36);
            this.btnNewGroup.TabIndex = 7;
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
            this.lblUsername.Size = new System.Drawing.Size(102, 19);
            this.lblUsername.TabIndex = 8;
            this.lblUsername.Text = "metroLabel11";
            // 
            // lblUserstatus
            // 
            this.lblUserstatus.AutoSize = true;
            this.lblUserstatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblUserstatus.Location = new System.Drawing.Point(375, 98);
            this.lblUserstatus.Name = "lblUserstatus";
            this.lblUserstatus.Size = new System.Drawing.Size(94, 19);
            this.lblUserstatus.TabIndex = 9;
            this.lblUserstatus.Text = "metroLabel12";
            // 
            // metroButton6
            // 
            this.metroButton6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton6.Location = new System.Drawing.Point(1088, 95);
            this.metroButton6.Name = "metroButton6";
            this.metroButton6.Size = new System.Drawing.Size(75, 23);
            this.metroButton6.TabIndex = 10;
            this.metroButton6.Text = "Send file";
            this.metroButton6.UseSelectable = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::Toxy.Properties.Resources.toxy2;
            this.BackImagePadding = new System.Windows.Forms.Padding(170, 15, 0, 0);
            this.BackMaxSize = 40;
            this.ClientSize = new System.Drawing.Size(1178, 561);
            this.Controls.Add(this.metroButton6);
            this.Controls.Add(this.lblUserstatus);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.metroButton4);
            this.Controls.Add(this.txtToSend);
            this.Controls.Add(this.btnAddFriend);
            this.Controls.Add(this.txtConversation);
            this.Controls.Add(this.tabRequests);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Toxy (Offline)";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabRequests.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel panelRequests;
        private MetroFramework.Controls.MetroPanel panelFriends;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTabControl tabRequests;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroTextBox txtToSend;
        private MetroFramework.Controls.MetroTextBox txtConversation;
        private MetroFramework.Controls.MetroButton metroButton4;
        private MetroFramework.Controls.MetroButton btnAddFriend;
        private MetroFramework.Controls.MetroButton btnNewGroup;
        private MetroFramework.Controls.MetroLabel lblUserstatus;
        private MetroFramework.Controls.MetroLabel lblUsername;
        private MetroFramework.Controls.MetroButton metroButton6;

    }
}

