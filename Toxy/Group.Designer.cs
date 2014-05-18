namespace Toxy
{
    partial class Group
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
            this.lblGroupStatus = new MetroFramework.Controls.MetroLabel();
            this.lblGroupname = new MetroFramework.Controls.MetroLabel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGroupStatus
            // 
            this.lblGroupStatus.AutoSize = true;
            this.lblGroupStatus.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblGroupStatus.Location = new System.Drawing.Point(68, 32);
            this.lblGroupStatus.Name = "lblGroupStatus";
            this.lblGroupStatus.Size = new System.Drawing.Size(46, 19);
            this.lblGroupStatus.TabIndex = 4;
            this.lblGroupStatus.Text = "status";
            this.lblGroupStatus.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // lblGroupname
            // 
            this.lblGroupname.AutoSize = true;
            this.lblGroupname.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblGroupname.Location = new System.Drawing.Point(68, 13);
            this.lblGroupname.Name = "lblGroupname";
            this.lblGroupname.Size = new System.Drawing.Size(87, 19);
            this.lblGroupname.TabIndex = 3;
            this.lblGroupname.Text = "groupname";
            this.lblGroupname.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.Transparent;
            this.picAvatar.Image = global::Toxy.Properties.Resources.noavatar;
            this.picAvatar.Location = new System.Drawing.Point(12, 13);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(50, 50);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 5;
            this.picAvatar.TabStop = false;
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblGroupStatus);
            this.Controls.Add(this.lblGroupname);
            this.DoubleBuffered = true;
            this.Name = "Group";
            this.Size = new System.Drawing.Size(325, 77);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picAvatar;
        private MetroFramework.Controls.MetroLabel lblGroupStatus;
        private MetroFramework.Controls.MetroLabel lblGroupname;
    }
}
