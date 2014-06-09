namespace Toxy
{
    partial class frmOptions
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
            this.btnCopyID = new MetroFramework.Controls.MetroButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtStatusMessage = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.toggleTypeDetection = new MetroFramework.Controls.MetroToggle();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.comboStyle = new MetroFramework.Controls.MetroComboBox();
            this.comboColor = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.toggleCloseTray = new MetroFramework.Controls.MetroToggle();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.comboInput = new MetroFramework.Controls.MetroComboBox();
            this.comboOutput = new MetroFramework.Controls.MetroComboBox();
            this.txtNospam = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopyID
            // 
            this.btnCopyID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyID.Location = new System.Drawing.Point(507, 185);
            this.btnCopyID.Name = "btnCopyID";
            this.btnCopyID.Size = new System.Drawing.Size(140, 23);
            this.btnCopyID.TabIndex = 8;
            this.btnCopyID.Text = "Copy ID";
            this.btnCopyID.UseSelectable = true;
            this.btnCopyID.Click += new System.EventHandler(this.btnCopyID_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(734, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(653, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Lines = new string[0];
            this.txtUsername.Location = new System.Drawing.Point(112, 91);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(139, 23);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.UseSelectable = true;
            // 
            // txtStatusMessage
            // 
            this.txtStatusMessage.Lines = new string[0];
            this.txtStatusMessage.Location = new System.Drawing.Point(112, 120);
            this.txtStatusMessage.MaxLength = 32767;
            this.txtStatusMessage.Name = "txtStatusMessage";
            this.txtStatusMessage.PasswordChar = '\0';
            this.txtStatusMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtStatusMessage.SelectedText = "";
            this.txtStatusMessage.Size = new System.Drawing.Size(139, 23);
            this.txtStatusMessage.TabIndex = 1;
            this.txtStatusMessage.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(23, 120);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(47, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Status";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel2.Location = new System.Drawing.Point(23, 91);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(71, 19);
            this.metroLabel2.TabIndex = 6;
            this.metroLabel2.Text = "Username";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(23, 187);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(111, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Typing detection";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel5.Location = new System.Drawing.Point(23, 60);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(78, 25);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "General";
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // toggleTypeDetection
            // 
            this.toggleTypeDetection.AutoSize = true;
            this.toggleTypeDetection.Location = new System.Drawing.Point(171, 189);
            this.toggleTypeDetection.Name = "toggleTypeDetection";
            this.toggleTypeDetection.Size = new System.Drawing.Size(80, 17);
            this.toggleTypeDetection.TabIndex = 2;
            this.toggleTypeDetection.Text = "Off";
            this.toggleTypeDetection.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel7.Location = new System.Drawing.Point(280, 60);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(134, 25);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Customization";
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel8.Location = new System.Drawing.Point(280, 91);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(38, 19);
            this.metroLabel8.TabIndex = 14;
            this.metroLabel8.Text = "Style";
            // 
            // comboStyle
            // 
            this.comboStyle.FormattingEnabled = true;
            this.comboStyle.ItemHeight = 23;
            this.comboStyle.Items.AddRange(new object[] {
            "Light",
            "Dark"});
            this.comboStyle.Location = new System.Drawing.Point(343, 88);
            this.comboStyle.Name = "comboStyle";
            this.comboStyle.Size = new System.Drawing.Size(121, 29);
            this.comboStyle.TabIndex = 3;
            this.comboStyle.UseSelectable = true;
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
            this.comboColor.Location = new System.Drawing.Point(343, 123);
            this.comboColor.Name = "comboColor";
            this.comboColor.Size = new System.Drawing.Size(121, 29);
            this.comboColor.TabIndex = 4;
            this.comboColor.UseSelectable = true;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel10.Location = new System.Drawing.Point(280, 125);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(42, 19);
            this.metroLabel10.TabIndex = 16;
            this.metroLabel10.Text = "Color";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(280, 165);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(87, 19);
            this.metroLabel3.TabIndex = 18;
            this.metroLabel3.Text = "Close to tray";
            // 
            // toggleCloseTray
            // 
            this.toggleCloseTray.AutoSize = true;
            this.toggleCloseTray.Location = new System.Drawing.Point(379, 167);
            this.toggleCloseTray.Name = "toggleCloseTray";
            this.toggleCloseTray.Size = new System.Drawing.Size(80, 17);
            this.toggleCloseTray.TabIndex = 5;
            this.toggleCloseTray.Text = "Off";
            this.toggleCloseTray.UseSelectable = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(507, 60);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(63, 25);
            this.metroLabel6.TabIndex = 20;
            this.metroLabel6.Text = "Audio";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(507, 91);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(38, 19);
            this.metroLabel9.TabIndex = 21;
            this.metroLabel9.Text = "Input";
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(507, 125);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(50, 19);
            this.metroLabel11.TabIndex = 22;
            this.metroLabel11.Text = "Output";
            // 
            // comboInput
            // 
            this.comboInput.FormattingEnabled = true;
            this.comboInput.ItemHeight = 23;
            this.comboInput.Location = new System.Drawing.Point(586, 88);
            this.comboInput.Name = "comboInput";
            this.comboInput.Size = new System.Drawing.Size(221, 29);
            this.comboInput.TabIndex = 6;
            this.comboInput.UseSelectable = true;
            // 
            // comboOutput
            // 
            this.comboOutput.FormattingEnabled = true;
            this.comboOutput.ItemHeight = 23;
            this.comboOutput.Location = new System.Drawing.Point(586, 123);
            this.comboOutput.Name = "comboOutput";
            this.comboOutput.Size = new System.Drawing.Size(221, 29);
            this.comboOutput.TabIndex = 7;
            this.comboOutput.UseSelectable = true;
            // 
            // txtNospam
            // 
            this.txtNospam.Lines = new string[0];
            this.txtNospam.Location = new System.Drawing.Point(112, 149);
            this.txtNospam.MaxLength = 32767;
            this.txtNospam.Name = "txtNospam";
            this.txtNospam.PasswordChar = '\0';
            this.txtNospam.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtNospam.SelectedText = "";
            this.txtNospam.Size = new System.Drawing.Size(139, 23);
            this.txtNospam.TabIndex = 23;
            this.txtNospam.UseSelectable = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(23, 151);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(59, 19);
            this.metroLabel12.TabIndex = 24;
            this.metroLabel12.Text = "Nospam";
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 231);
            this.Controls.Add(this.metroLabel12);
            this.Controls.Add(this.txtNospam);
            this.Controls.Add(this.comboOutput);
            this.Controls.Add(this.comboInput);
            this.Controls.Add(this.metroLabel11);
            this.Controls.Add(this.metroLabel9);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.toggleCloseTray);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.comboColor);
            this.Controls.Add(this.metroLabel10);
            this.Controls.Add(this.comboStyle);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.toggleTypeDetection);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.txtStatusMessage);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCopyID);
            this.Name = "frmOptions";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Text = "Options";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnCopyID;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnSave;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtStatusMessage;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroToggle toggleTypeDetection;
        private MetroFramework.Controls.MetroComboBox comboStyle;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroComboBox comboColor;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroToggle toggleCloseTray;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox comboOutput;
        private MetroFramework.Controls.MetroComboBox comboInput;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox txtNospam;
    }
}