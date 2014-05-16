namespace Toxy
{
    partial class frmConversation
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
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.txtConversation = new MetroFramework.Controls.MetroTextBox();
            this.txtToSend = new MetroFramework.Controls.MetroTextBox();
            this.lblTyping = new MetroFramework.Controls.MetroLabel();
            this.btnSendFile = new MetroFramework.Controls.MetroButton();
            this.btnCall = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(23, 51);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 19);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "status";
            // 
            // txtConversation
            // 
            this.txtConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConversation.Lines = new string[0];
            this.txtConversation.Location = new System.Drawing.Point(23, 88);
            this.txtConversation.MaxLength = 32767;
            this.txtConversation.Multiline = true;
            this.txtConversation.Name = "txtConversation";
            this.txtConversation.PasswordChar = '\0';
            this.txtConversation.ReadOnly = true;
            this.txtConversation.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtConversation.SelectedText = "";
            this.txtConversation.Size = new System.Drawing.Size(613, 281);
            this.txtConversation.TabIndex = 1;
            this.txtConversation.UseSelectable = true;
            // 
            // txtToSend
            // 
            this.txtToSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToSend.Lines = new string[0];
            this.txtToSend.Location = new System.Drawing.Point(23, 375);
            this.txtToSend.MaxLength = 32767;
            this.txtToSend.Name = "txtToSend";
            this.txtToSend.PasswordChar = '\0';
            this.txtToSend.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToSend.SelectedText = "";
            this.txtToSend.Size = new System.Drawing.Size(613, 23);
            this.txtToSend.TabIndex = 2;
            this.txtToSend.UseSelectable = true;
            this.txtToSend.UseStyleColors = true;
            this.txtToSend.TextChanged += new System.EventHandler(this.txtToSend_TextChanged);
            this.txtToSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToSend_KeyPress);
            // 
            // lblTyping
            // 
            this.lblTyping.AutoSize = true;
            this.lblTyping.Location = new System.Drawing.Point(23, 401);
            this.lblTyping.Name = "lblTyping";
            this.lblTyping.Size = new System.Drawing.Size(0, 0);
            this.lblTyping.TabIndex = 3;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(546, 59);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(90, 23);
            this.btnSendFile.TabIndex = 4;
            this.btnSendFile.Text = "Send file";
            this.btnSendFile.UseSelectable = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(465, 59);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 5;
            this.btnCall.Text = "Call";
            this.btnCall.UseSelectable = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // frmConversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 435);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnSendFile);
            this.Controls.Add(this.lblTyping);
            this.Controls.Add(this.txtToSend);
            this.Controls.Add(this.txtConversation);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmConversation";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Undefined";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroTextBox txtToSend;
        private MetroFramework.Controls.MetroTextBox txtConversation;
        private MetroFramework.Controls.MetroLabel lblTyping;
        private MetroFramework.Controls.MetroButton btnSendFile;
        private MetroFramework.Controls.MetroButton btnCall;
    }
}