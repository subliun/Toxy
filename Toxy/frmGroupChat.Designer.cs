namespace Toxy
{
    partial class frmGroupChat
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
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.txtConversation = new MetroFramework.Controls.MetroTextBox();
            this.txtToSend = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.lblGroupMembers = new MetroFramework.Controls.MetroLabel();
            this.btnLeave = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // txtConversation
            // 
            this.txtConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversation.Lines = new string[0];
            this.txtConversation.Location = new System.Drawing.Point(23, 63);
            this.txtConversation.MaxLength = 32767;
            this.txtConversation.Multiline = true;
            this.txtConversation.Name = "txtConversation";
            this.txtConversation.PasswordChar = '\0';
            this.txtConversation.ReadOnly = true;
            this.txtConversation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConversation.SelectedText = "";
            this.txtConversation.Size = new System.Drawing.Size(568, 356);
            this.txtConversation.TabIndex = 1;
            this.txtConversation.UseSelectable = true;
            // 
            // txtToSend
            // 
            this.txtToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSend.Lines = new string[0];
            this.txtToSend.Location = new System.Drawing.Point(23, 425);
            this.txtToSend.MaxLength = 32767;
            this.txtToSend.Name = "txtToSend";
            this.txtToSend.PasswordChar = '\0';
            this.txtToSend.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToSend.SelectedText = "";
            this.txtToSend.Size = new System.Drawing.Size(568, 23);
            this.txtToSend.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtToSend.TabIndex = 0;
            this.txtToSend.UseSelectable = true;
            this.txtToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSend_KeyPress);
            // 
            // metroButton1
            // 
            this.metroButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton1.Location = new System.Drawing.Point(488, 34);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(103, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "Invite all friends";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(597, 38);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(72, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Members";
            // 
            // lblGroupMembers
            // 
            this.lblGroupMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroupMembers.AutoSize = true;
            this.lblGroupMembers.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGroupMembers.Location = new System.Drawing.Point(597, 57);
            this.lblGroupMembers.Name = "lblGroupMembers";
            this.lblGroupMembers.Size = new System.Drawing.Size(0, 0);
            this.lblGroupMembers.TabIndex = 4;
            // 
            // btnLeave
            // 
            this.btnLeave.Location = new System.Drawing.Point(407, 34);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(75, 23);
            this.btnLeave.TabIndex = 5;
            this.btnLeave.Text = "Leave group";
            this.btnLeave.UseSelectable = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // frmGroupChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 471);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.lblGroupMembers);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtToSend);
            this.Controls.Add(this.txtConversation);
            this.Name = "frmGroupChat";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Groupchat";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroTextBox txtToSend;
        private MetroFramework.Controls.MetroTextBox txtConversation;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel lblGroupMembers;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnLeave;
    }
}