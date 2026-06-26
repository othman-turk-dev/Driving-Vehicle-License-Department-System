namespace DVLD_Project.Appliications.Release_Detained_License
{
    partial class frmListDetainLicense
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
            this.CbRelease = new System.Windows.Forms.ComboBox();
            this.TxtFilterValue = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.CbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVDetainedLicense = new System.Windows.Forms.DataGridView();
            this.CMStripForDetainedApp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showPersonDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseDetailseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClose = new System.Windows.Forms.Button();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.btnAddDetainedLicense = new System.Windows.Forms.Button();
            this.BtnReleaseLicense = new System.Windows.Forms.Button();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicense)).BeginInit();
            this.CMStripForDetainedApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // CbRelease
            // 
            this.CbRelease.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CbRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbRelease.FormattingEnabled = true;
            this.CbRelease.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.CbRelease.Location = new System.Drawing.Point(349, 356);
            this.CbRelease.Name = "CbRelease";
            this.CbRelease.Size = new System.Drawing.Size(133, 24);
            this.CbRelease.TabIndex = 137;
            this.CbRelease.SelectedIndexChanged += new System.EventHandler(this.CbRelease_SelectedIndexChanged);
            // 
            // TxtFilterValue
            // 
            this.TxtFilterValue.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxtFilterValue.Location = new System.Drawing.Point(349, 356);
            this.TxtFilterValue.MaxLength = 50;
            this.TxtFilterValue.Name = "TxtFilterValue";
            this.TxtFilterValue.Size = new System.Drawing.Size(213, 24);
            this.TxtFilterValue.TabIndex = 136;
            this.TxtFilterValue.TextChanged += new System.EventHandler(this.TxtFilterValue_TextChanged);
            this.TxtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFilterValue_KeyPress);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Location = new System.Drawing.Point(382, 268);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(670, 53);
            this.lblTitle.TabIndex = 135;
            this.lblTitle.Text = "List Detained Licenses Applications";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CbFilterBy
            // 
            this.CbFilterBy.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbFilterBy.FormattingEnabled = true;
            this.CbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No.",
            "Full Name",
            "Release Application ID"});
            this.CbFilterBy.Location = new System.Drawing.Point(120, 356);
            this.CbFilterBy.Name = "CbFilterBy";
            this.CbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.CbFilterBy.TabIndex = 130;
            this.CbFilterBy.SelectedIndexChanged += new System.EventHandler(this.CbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 129;
            this.label1.Text = "Filter By:";
            // 
            // DGVDetainedLicense
            // 
            this.DGVDetainedLicense.AllowUserToAddRows = false;
            this.DGVDetainedLicense.AllowUserToDeleteRows = false;
            this.DGVDetainedLicense.AllowUserToOrderColumns = true;
            this.DGVDetainedLicense.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DGVDetainedLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDetainedLicense.ContextMenuStrip = this.CMStripForDetainedApp;
            this.DGVDetainedLicense.Location = new System.Drawing.Point(31, 389);
            this.DGVDetainedLicense.Name = "DGVDetainedLicense";
            this.DGVDetainedLicense.ReadOnly = true;
            this.DGVDetainedLicense.RowHeadersWidth = 51;
            this.DGVDetainedLicense.RowTemplate.Height = 26;
            this.DGVDetainedLicense.Size = new System.Drawing.Size(1258, 340);
            this.DGVDetainedLicense.TabIndex = 128;
            this.DGVDetainedLicense.DoubleClick += new System.EventHandler(this.DGVDetainedLicense_DoubleClick);
            // 
            // CMStripForDetainedApp
            // 
            this.CMStripForDetainedApp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CMStripForDetainedApp.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.CMStripForDetainedApp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPersonDetailsToolStripMenuItem,
            this.showLicenseDetailseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.CMStripForDetainedApp.Name = "contextMenuStrip1";
            this.CMStripForDetainedApp.Size = new System.Drawing.Size(275, 132);
            this.CMStripForDetainedApp.Opening += new System.ComponentModel.CancelEventHandler(this.CMStripForDetainedApp_Opening);
            // 
            // showPersonDetailsToolStripMenuItem
            // 
            this.showPersonDetailsToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.drivers_license;
            this.showPersonDetailsToolStripMenuItem.Name = "showPersonDetailsToolStripMenuItem";
            this.showPersonDetailsToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.showPersonDetailsToolStripMenuItem.Text = "Show Person Details";
            this.showPersonDetailsToolStripMenuItem.Click += new System.EventHandler(this.showPersonDetailsToolStripMenuItem_Click);
            // 
            // showLicenseDetailseToolStripMenuItem
            // 
            this.showLicenseDetailseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.registered_document;
            this.showLicenseDetailseToolStripMenuItem.Name = "showLicenseDetailseToolStripMenuItem";
            this.showLicenseDetailseToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.showLicenseDetailseToolStripMenuItem.Text = "Show License Detailse";
            this.showLicenseDetailseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseDetailseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.history_book;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.growth;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(274, 32);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.ForeColor = System.Drawing.Color.Snow;
            this.BtnClose.Location = new System.Drawing.Point(1140, 739);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(149, 53);
            this.BtnClose.TabIndex = 133;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPersonImage.Image = global::DVLD_Project.Properties.Resources.customer_service;
            this.pbPersonImage.InitialImage = null;
            this.pbPersonImage.Location = new System.Drawing.Point(515, 26);
            this.pbPersonImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(397, 237);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 131;
            this.pbPersonImage.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::DVLD_Project.Properties.Resources.close1;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(1149, 750);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(42, 35);
            this.pictureBox9.TabIndex = 134;
            this.pictureBox9.TabStop = false;
            // 
            // btnAddDetainedLicense
            // 
            this.btnAddDetainedLicense.BackgroundImage = global::DVLD_Project.Properties.Resources.keycard;
            this.btnAddDetainedLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddDetainedLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetainedLicense.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddDetainedLicense.Location = new System.Drawing.Point(1201, 328);
            this.btnAddDetainedLicense.Name = "btnAddDetainedLicense";
            this.btnAddDetainedLicense.Size = new System.Drawing.Size(88, 55);
            this.btnAddDetainedLicense.TabIndex = 132;
            this.btnAddDetainedLicense.UseVisualStyleBackColor = true;
            this.btnAddDetainedLicense.Click += new System.EventHandler(this.btnAddDetainedLicense_Click);
            // 
            // BtnReleaseLicense
            // 
            this.BtnReleaseLicense.BackgroundImage = global::DVLD_Project.Properties.Resources.growth;
            this.BtnReleaseLicense.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnReleaseLicense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReleaseLicense.ForeColor = System.Drawing.Color.Transparent;
            this.BtnReleaseLicense.Location = new System.Drawing.Point(1092, 329);
            this.BtnReleaseLicense.Name = "BtnReleaseLicense";
            this.BtnReleaseLicense.Size = new System.Drawing.Size(88, 55);
            this.BtnReleaseLicense.TabIndex = 139;
            this.BtnReleaseLicense.UseVisualStyleBackColor = true;
            this.BtnReleaseLicense.Click += new System.EventHandler(this.BtnReleaseLicense_Click);
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTotalRecords.Location = new System.Drawing.Point(136, 744);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(22, 18);
            this.lblTotalRecords.TabIndex = 160;
            this.lblTotalRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 739);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 159;
            this.label5.Text = "# Records:";
            // 
            // frmListDetainLicense
            // 
            this.AcceptButton = this.btnAddDetainedLicense;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1310, 802);
            this.Controls.Add(this.lblTotalRecords);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnReleaseLicense);
            this.Controls.Add(this.CbRelease);
            this.Controls.Add(this.TxtFilterValue);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.CbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVDetainedLicense);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.btnAddDetainedLicense);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Detain License";
            this.Load += new System.EventHandler(this.frmListDetainLicense_Load);
            this.Shown += new System.EventHandler(this.frmListDetainLicense_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDetainedLicense)).EndInit();
            this.CMStripForDetainedApp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CbRelease;
        private System.Windows.Forms.TextBox TxtFilterValue;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox CbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVDetainedLicense;
        private System.Windows.Forms.ContextMenuStrip CMStripForDetainedApp;
        private System.Windows.Forms.ToolStripMenuItem showPersonDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseDetailseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button btnAddDetainedLicense;
        private System.Windows.Forms.Button BtnReleaseLicense;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.Label label5;
    }
}