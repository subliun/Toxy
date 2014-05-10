namespace Toxy
{
    partial class FriendRequest
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAccept = new MetroFramework.Controls.MetroButton();
            this.btnDecline = new MetroFramework.Controls.MetroButton();
            this.lblID = new MetroFramework.Controls.MetroLabel();
            this.lblMessage = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(197, 60);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseSelectable = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnDecline
            // 
            this.btnDecline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecline.Location = new System.Drawing.Point(278, 60);
            this.btnDecline.Name = "btnDecline";
            this.btnDecline.Size = new System.Drawing.Size(75, 23);
            this.btnDecline.TabIndex = 1;
            this.btnDecline.Text = "Decline";
            this.btnDecline.UseSelectable = true;
            this.btnDecline.Click += new System.EventHandler(this.btnDecline_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(14, 10);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(20, 19);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "id";
            this.lblID.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(14, 41);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 19);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "message";
            this.lblMessage.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // FriendRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.btnDecline);
            this.Controls.Add(this.btnAccept);
            this.DoubleBuffered = true;
            this.Name = "FriendRequest";
            this.Size = new System.Drawing.Size(365, 96);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnAccept;
        private MetroFramework.Controls.MetroButton btnDecline;
        private MetroFramework.Controls.MetroLabel lblID;
        private MetroFramework.Controls.MetroLabel lblMessage;
    }
}
