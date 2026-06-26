namespace DVLD_Project.Licenses.Detain_License
{
    partial class frmDetainLicenseApplication
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
            this.ctrDriverLicenseInfoWithFilter1 = new DVLD_Project.Licenses.LocalLicenses.Controls.ctrDriverLicenseInfoWithFilter();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.BtnDetain = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LLbShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.LLbShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbUsersName = new System.Windows.Forms.Label();
            this.LbLicensesID = new System.Windows.Forms.Label();
            this.TxtFineFees = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LbCreateBy = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.LbLicenseID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbDetainDate = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LbDetainID = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ctrDriverLicenseInfoWithFilter1
            // 
            this.ctrDriverLicenseInfoWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrDriverLicenseInfoWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ctrDriverLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrDriverLicenseInfoWithFilter1.ForeColor = System.Drawing.Color.Snow;
            this.ctrDriverLicenseInfoWithFilter1.Location = new System.Drawing.Point(0, 57);
            this.ctrDriverLicenseInfoWithFilter1.Name = "ctrDriverLicenseInfoWithFilter1";
            this.ctrDriverLicenseInfoWithFilter1.Size = new System.Drawing.Size(1024, 397);
            this.ctrDriverLicenseInfoWithFilter1.TabIndex = 0;
            this.ctrDriverLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrDriverLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::DVLD_Project.Properties.Resources.close;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(690, 649);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(42, 35);
            this.pictureBox9.TabIndex = 141;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::DVLD_Project.Properties.Resources.keycard__1_;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Location = new System.Drawing.Point(873, 649);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(42, 35);
            this.pictureBox11.TabIndex = 140;
            this.pictureBox11.TabStop = false;
            // 
            // BtnDetain
            // 
            this.BtnDetain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnDetain.Enabled = false;
            this.BtnDetain.ForeColor = System.Drawing.Color.Snow;
            this.BtnDetain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDetain.Location = new System.Drawing.Point(863, 641);
            this.BtnDetain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnDetain.Name = "BtnDetain";
            this.BtnDetain.Size = new System.Drawing.Size(149, 53);
            this.BtnDetain.TabIndex = 138;
            this.BtnDetain.Text = "Detain";
            this.BtnDetain.UseVisualStyleBackColor = false;
            this.BtnDetain.Click += new System.EventHandler(this.BtnDetain_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.ForeColor = System.Drawing.Color.Snow;
            this.BtnClose.Location = new System.Drawing.Point(681, 641);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(149, 53);
            this.BtnClose.TabIndex = 139;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // LLbShowLicenseInfo
            // 
            this.LLbShowLicenseInfo.ActiveLinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LLbShowLicenseInfo.AutoSize = true;
            this.LLbShowLicenseInfo.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbShowLicenseInfo.LinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.LLbShowLicenseInfo.Location = new System.Drawing.Point(260, 655);
            this.LLbShowLicenseInfo.Name = "LLbShowLicenseInfo";
            this.LLbShowLicenseInfo.Size = new System.Drawing.Size(166, 20);
            this.LLbShowLicenseInfo.TabIndex = 137;
            this.LLbShowLicenseInfo.TabStop = true;
            this.LLbShowLicenseInfo.Text = "Show License Info";
            this.LLbShowLicenseInfo.Visible = false;
            this.LLbShowLicenseInfo.VisitedLinkColor = System.Drawing.SystemColors.AppWorkspace;
            this.LLbShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbShowLicenseInfo_LinkClicked);
            // 
            // LLbShowLicenseHistory
            // 
            this.LLbShowLicenseHistory.ActiveLinkColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LLbShowLicenseHistory.AutoSize = true;
            this.LLbShowLicenseHistory.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLbShowLicenseHistory.LinkColor = System.Drawing.SystemColors.InactiveCaption;
            this.LLbShowLicenseHistory.Location = new System.Drawing.Point(48, 655);
            this.LLbShowLicenseHistory.Name = "LLbShowLicenseHistory";
            this.LLbShowLicenseHistory.Size = new System.Drawing.Size(192, 20);
            this.LLbShowLicenseHistory.TabIndex = 136;
            this.LLbShowLicenseHistory.TabStop = true;
            this.LLbShowLicenseHistory.Text = "Show License History";
            this.LLbShowLicenseHistory.Visible = false;
            this.LLbShowLicenseHistory.VisitedLinkColor = System.Drawing.SystemColors.AppWorkspace;
            this.LLbShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLbShowLicenseHistory_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbUsersName);
            this.groupBox1.Controls.Add(this.LbLicensesID);
            this.groupBox1.Controls.Add(this.TxtFineFees);
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LbCreateBy);
            this.groupBox1.Controls.Add(this.pictureBox8);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.LbLicenseID);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LbDetainDate);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LbDetainID);
            this.groupBox1.Location = new System.Drawing.Point(0, 451);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1012, 172);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            // 
            // LbUsersName
            // 
            this.LbUsersName.AutoSize = true;
            this.LbUsersName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUsersName.Location = new System.Drawing.Point(741, 81);
            this.LbUsersName.Name = "LbUsersName";
            this.LbUsersName.Size = new System.Drawing.Size(46, 18);
            this.LbUsersName.TabIndex = 152;
            this.LbUsersName.Text = "[???]";
            // 
            // LbLicensesID
            // 
            this.LbLicensesID.AutoSize = true;
            this.LbLicensesID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLicensesID.Location = new System.Drawing.Point(741, 37);
            this.LbLicensesID.Name = "LbLicensesID";
            this.LbLicensesID.Size = new System.Drawing.Size(46, 18);
            this.LbLicensesID.TabIndex = 151;
            this.LbLicensesID.Text = "[???]";
            // 
            // TxtFineFees
            // 
            this.TxtFineFees.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TxtFineFees.Location = new System.Drawing.Point(464, 129);
            this.TxtFineFees.Name = "TxtFineFees";
            this.TxtFineFees.Size = new System.Drawing.Size(158, 24);
            this.TxtFineFees.TabIndex = 150;
            this.TxtFineFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFineFees_KeyPress);
            this.TxtFineFees.Validating += new System.ComponentModel.CancelEventHandler(this.TxtFineFees_Validating);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Project.Properties.Resources.user;
            this.pictureBox4.Location = new System.Drawing.Point(702, 72);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 32);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 149;
            this.pictureBox4.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(589, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 147;
            this.label2.Text = "Create By:";
            // 
            // LbCreateBy
            // 
            this.LbCreateBy.AutoSize = true;
            this.LbCreateBy.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbCreateBy.Location = new System.Drawing.Point(650, 81);
            this.LbCreateBy.Name = "LbCreateBy";
            this.LbCreateBy.Size = new System.Drawing.Size(46, 18);
            this.LbCreateBy.TabIndex = 148;
            this.LbCreateBy.Text = "[???]";
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::DVLD_Project.Properties.Resources.id__1_;
            this.pictureBox8.Location = new System.Drawing.Point(702, 28);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 32);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 140;
            this.pictureBox8.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(580, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 20);
            this.label11.TabIndex = 138;
            this.label11.Text = "License ID:";
            // 
            // LbLicenseID
            // 
            this.LbLicenseID.AutoSize = true;
            this.LbLicenseID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLicenseID.Location = new System.Drawing.Point(650, 37);
            this.LbLicenseID.Name = "LbLicenseID";
            this.LbLicenseID.Size = new System.Drawing.Size(46, 18);
            this.LbLicenseID.TabIndex = 139;
            this.LbLicenseID.Text = "[???]";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Project.Properties.Resources.hand;
            this.pictureBox3.Location = new System.Drawing.Point(423, 124);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 137;
            this.pictureBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(318, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 135;
            this.label6.Text = "Fine Fees:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.date;
            this.pictureBox1.Location = new System.Drawing.Point(282, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 129;
            this.label1.Text = "Detain Date:";
            // 
            // LbDetainDate
            // 
            this.LbDetainDate.AutoSize = true;
            this.LbDetainDate.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDetainDate.Location = new System.Drawing.Point(319, 81);
            this.LbDetainDate.Name = "LbDetainDate";
            this.LbDetainDate.Size = new System.Drawing.Size(46, 18);
            this.LbDetainDate.TabIndex = 130;
            this.LbDetainDate.Text = "[???]";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Project.Properties.Resources.id__1_;
            this.pictureBox6.Location = new System.Drawing.Point(282, 28);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 128;
            this.pictureBox6.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(173, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 126;
            this.label3.Text = "Detain ID:";
            // 
            // LbDetainID
            // 
            this.LbDetainID.AutoSize = true;
            this.LbDetainID.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbDetainID.Location = new System.Drawing.Point(319, 37);
            this.LbDetainID.Name = "LbDetainID";
            this.LbDetainID.Size = new System.Drawing.Size(46, 18);
            this.LbDetainID.TabIndex = 127;
            this.LbDetainID.Text = "[???]";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(242, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(588, 45);
            this.lblTitle.TabIndex = 179;
            this.lblTitle.Text = "Detain License";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDetainLicenseApplication
            // 
            this.AcceptButton = this.BtnDetain;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1036, 715);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.pictureBox11);
            this.Controls.Add(this.BtnDetain);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.LLbShowLicenseInfo);
            this.Controls.Add(this.LLbShowLicenseHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrDriverLicenseInfoWithFilter1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicenseApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detain License Application";
            this.Activated += new System.EventHandler(this.frmDetainLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.frmDetainLicenseApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LocalLicenses.Controls.ctrDriverLicenseInfoWithFilter ctrDriverLicenseInfoWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Button BtnDetain;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.LinkLabel LLbShowLicenseInfo;
        private System.Windows.Forms.LinkLabel LLbShowLicenseHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtFineFees;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LbCreateBy;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label LbLicenseID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbDetainDate;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbDetainID;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label LbUsersName;
        private System.Windows.Forms.Label LbLicensesID;
    }
}