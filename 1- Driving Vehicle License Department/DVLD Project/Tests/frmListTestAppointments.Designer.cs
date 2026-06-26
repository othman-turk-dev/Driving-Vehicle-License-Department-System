namespace DVLD_Project.Tests
{
    partial class frmListTestAppointments
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
            this.LbTitle = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVForTestAppointments = new System.Windows.Forms.DataGridView();
            this.CMStripForTestAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.PicBoxTestType = new System.Windows.Forms.PictureBox();
            this.ctrDrivingLicenseApplicationInfo1 = new DVLD_Project.Appliications.Local_Driving_License.Control.ctrDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.DGVForTestAppointments)).BeginInit();
            this.CMStripForTestAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTestType)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Times New Roman", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitle.ForeColor = System.Drawing.Color.SteelBlue;
            this.LbTitle.Location = new System.Drawing.Point(191, 56);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(222, 49);
            this.LbTitle.TabIndex = 59;
            this.LbTitle.Text = "Vision Test";
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.ForeColor = System.Drawing.Color.Snow;
            this.BtnClose.Location = new System.Drawing.Point(1304, 513);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(149, 53);
            this.BtnClose.TabIndex = 62;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(787, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 23);
            this.label2.TabIndex = 61;
            this.label2.Text = "Appointments:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRecordsCount.Location = new System.Drawing.Point(895, 514);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 24);
            this.lblRecordsCount.TabIndex = 103;
            this.lblRecordsCount.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(786, 513);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 102;
            this.label1.Text = "# Records:";
            // 
            // DGVForTestAppointments
            // 
            this.DGVForTestAppointments.AllowUserToAddRows = false;
            this.DGVForTestAppointments.AllowUserToDeleteRows = false;
            this.DGVForTestAppointments.AllowUserToOrderColumns = true;
            this.DGVForTestAppointments.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.DGVForTestAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVForTestAppointments.ContextMenuStrip = this.CMStripForTestAppointment;
            this.DGVForTestAppointments.Location = new System.Drawing.Point(791, 209);
            this.DGVForTestAppointments.Name = "DGVForTestAppointments";
            this.DGVForTestAppointments.ReadOnly = true;
            this.DGVForTestAppointments.RowHeadersWidth = 51;
            this.DGVForTestAppointments.RowTemplate.Height = 26;
            this.DGVForTestAppointments.Size = new System.Drawing.Size(662, 296);
            this.DGVForTestAppointments.TabIndex = 101;
            // 
            // CMStripForTestAppointment
            // 
            this.CMStripForTestAppointment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CMStripForTestAppointment.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.CMStripForTestAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.editToolStripMenuItem,
            this.TakeTestToolStripMenuItem,
            this.toolStripMenuItem2});
            this.CMStripForTestAppointment.Name = "contextMenuStrip1";
            this.CMStripForTestAppointment.Size = new System.Drawing.Size(148, 80);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(144, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(147, 32);
            this.editToolStripMenuItem.Text = "Edit Test";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // TakeTestToolStripMenuItem
            // 
            this.TakeTestToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.check_list;
            this.TakeTestToolStripMenuItem.Name = "TakeTestToolStripMenuItem";
            this.TakeTestToolStripMenuItem.Size = new System.Drawing.Size(147, 32);
            this.TakeTestToolStripMenuItem.Text = "Take Test";
            this.TakeTestToolStripMenuItem.Click += new System.EventHandler(this.TakeTestToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(144, 6);
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.BackgroundImage = global::DVLD_Project.Properties.Resources.add;
            this.btnAddTestAppointment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTestAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTestAppointment.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddTestAppointment.Location = new System.Drawing.Point(1382, 160);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(71, 43);
            this.btnAddTestAppointment.TabIndex = 104;
            this.btnAddTestAppointment.UseVisualStyleBackColor = true;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::DVLD_Project.Properties.Resources.close;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(1313, 521);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(42, 35);
            this.pictureBox9.TabIndex = 63;
            this.pictureBox9.TabStop = false;
            // 
            // PicBoxTestType
            // 
            this.PicBoxTestType.Image = global::DVLD_Project.Properties.Resources.eye_recognition;
            this.PicBoxTestType.Location = new System.Drawing.Point(968, 12);
            this.PicBoxTestType.Name = "PicBoxTestType";
            this.PicBoxTestType.Size = new System.Drawing.Size(351, 171);
            this.PicBoxTestType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBoxTestType.TabIndex = 60;
            this.PicBoxTestType.TabStop = false;
            // 
            // ctrDrivingLicenseApplicationInfo1
            // 
            this.ctrDrivingLicenseApplicationInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ctrDrivingLicenseApplicationInfo1.ForeColor = System.Drawing.Color.Snow;
            this.ctrDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 144);
            this.ctrDrivingLicenseApplicationInfo1.Name = "ctrDrivingLicenseApplicationInfo1";
            this.ctrDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(773, 423);
            this.ctrDrivingLicenseApplicationInfo1.TabIndex = 0;
            // 
            // frmListTestAppointments
            // 
            this.AcceptButton = this.btnAddTestAppointment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1479, 600);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVForTestAppointments);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PicBoxTestType);
            this.Controls.Add(this.LbTitle);
            this.Controls.Add(this.ctrDrivingLicenseApplicationInfo1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Test Appointments";
            this.Load += new System.EventHandler(this.frmListTestAppointments_Load);
            this.Shown += new System.EventHandler(this.frmListTestAppointments_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DGVForTestAppointments)).EndInit();
            this.CMStripForTestAppointment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxTestType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Appliications.Local_Driving_License.Control.ctrDrivingLicenseApplicationInfo ctrDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.PictureBox PicBoxTestType;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVForTestAppointments;
        private System.Windows.Forms.ContextMenuStrip CMStripForTestAppointment;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}