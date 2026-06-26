namespace DVLD_Project.Licenses.Control
{
    partial class ctrDriverLicenses
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TbCtrDriverLicenses = new System.Windows.Forms.TabControl();
            this.TbLocal = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.LbLRecord = new System.Windows.Forms.Label();
            this.DataGVLocal = new System.Windows.Forms.DataGridView();
            this.CMStripForLLHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.label2 = new System.Windows.Forms.Label();
            this.TbInternational = new System.Windows.Forms.TabPage();
            this.LbIRecord = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DataGVInternational = new System.Windows.Forms.DataGridView();
            this.CMStripForILHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternationalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.TbCtrDriverLicenses.SuspendLayout();
            this.TbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVLocal)).BeginInit();
            this.CMStripForLLHistory.SuspendLayout();
            this.TbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVInternational)).BeginInit();
            this.CMStripForILHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TbCtrDriverLicenses);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1171, 413);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TbCtrDriverLicenses
            // 
            this.TbCtrDriverLicenses.Controls.Add(this.TbLocal);
            this.TbCtrDriverLicenses.Controls.Add(this.TbInternational);
            this.TbCtrDriverLicenses.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbCtrDriverLicenses.Location = new System.Drawing.Point(15, 23);
            this.TbCtrDriverLicenses.Name = "TbCtrDriverLicenses";
            this.TbCtrDriverLicenses.SelectedIndex = 0;
            this.TbCtrDriverLicenses.Size = new System.Drawing.Size(1138, 371);
            this.TbCtrDriverLicenses.TabIndex = 2;
            // 
            // TbLocal
            // 
            this.TbLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TbLocal.Controls.Add(this.label3);
            this.TbLocal.Controls.Add(this.LbLRecord);
            this.TbLocal.Controls.Add(this.DataGVLocal);
            this.TbLocal.Controls.Add(this.label2);
            this.TbLocal.Font = new System.Drawing.Font("Tahoma", 8F);
            this.TbLocal.Location = new System.Drawing.Point(4, 29);
            this.TbLocal.Name = "TbLocal";
            this.TbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.TbLocal.Size = new System.Drawing.Size(1130, 338);
            this.TbLocal.TabIndex = 0;
            this.TbLocal.Text = "Local";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 23);
            this.label3.TabIndex = 112;
            this.label3.Text = "# Records:";
            // 
            // LbLRecord
            // 
            this.LbLRecord.AutoSize = true;
            this.LbLRecord.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLRecord.Location = new System.Drawing.Point(136, 306);
            this.LbLRecord.Name = "LbLRecord";
            this.LbLRecord.Size = new System.Drawing.Size(27, 20);
            this.LbLRecord.TabIndex = 111;
            this.LbLRecord.Text = "??";
            // 
            // DataGVLocal
            // 
            this.DataGVLocal.AllowUserToAddRows = false;
            this.DataGVLocal.AllowUserToDeleteRows = false;
            this.DataGVLocal.AllowUserToOrderColumns = true;
            this.DataGVLocal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVLocal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGVLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVLocal.ContextMenuStrip = this.CMStripForLLHistory;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGVLocal.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGVLocal.Location = new System.Drawing.Point(19, 45);
            this.DataGVLocal.Name = "DataGVLocal";
            this.DataGVLocal.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVLocal.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DataGVLocal.RowHeadersWidth = 51;
            this.DataGVLocal.RowTemplate.Height = 26;
            this.DataGVLocal.Size = new System.Drawing.Size(1092, 251);
            this.DataGVLocal.TabIndex = 110;
            // 
            // CMStripForLLHistory
            // 
            this.CMStripForLLHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CMStripForLLHistory.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.CMStripForLLHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.CMStripForLLHistory.Name = "contextMenuStrip1";
            this.CMStripForLLHistory.Size = new System.Drawing.Size(207, 48);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.id_card;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(206, 32);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(203, 6);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Local License History:";
            // 
            // TbInternational
            // 
            this.TbInternational.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TbInternational.Controls.Add(this.LbIRecord);
            this.TbInternational.Controls.Add(this.label1);
            this.TbInternational.Controls.Add(this.DataGVInternational);
            this.TbInternational.Controls.Add(this.label4);
            this.TbInternational.Font = new System.Drawing.Font("Tahoma", 8F);
            this.TbInternational.Location = new System.Drawing.Point(4, 29);
            this.TbInternational.Name = "TbInternational";
            this.TbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.TbInternational.Size = new System.Drawing.Size(1130, 338);
            this.TbInternational.TabIndex = 1;
            this.TbInternational.Text = "International";
            // 
            // LbIRecord
            // 
            this.LbIRecord.AutoSize = true;
            this.LbIRecord.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbIRecord.Location = new System.Drawing.Point(138, 307);
            this.LbIRecord.Name = "LbIRecord";
            this.LbIRecord.Size = new System.Drawing.Size(27, 20);
            this.LbIRecord.TabIndex = 116;
            this.LbIRecord.Text = "??";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 23);
            this.label1.TabIndex = 115;
            this.label1.Text = "# Records:";
            // 
            // DataGVInternational
            // 
            this.DataGVInternational.AllowUserToAddRows = false;
            this.DataGVInternational.AllowUserToDeleteRows = false;
            this.DataGVInternational.AllowUserToOrderColumns = true;
            this.DataGVInternational.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVInternational.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGVInternational.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGVInternational.ContextMenuStrip = this.CMStripForILHistory;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGVInternational.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataGVInternational.Location = new System.Drawing.Point(21, 45);
            this.DataGVInternational.Name = "DataGVInternational";
            this.DataGVInternational.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGVInternational.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DataGVInternational.RowHeadersWidth = 51;
            this.DataGVInternational.RowTemplate.Height = 26;
            this.DataGVInternational.Size = new System.Drawing.Size(1092, 251);
            this.DataGVInternational.TabIndex = 114;
            // 
            // CMStripForILHistory
            // 
            this.CMStripForILHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CMStripForILHistory.ImageScalingSize = new System.Drawing.Size(26, 26);
            this.CMStripForILHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternationalLicenseHistorytoolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripSeparator4});
            this.CMStripForILHistory.Name = "contextMenuStrip1";
            this.CMStripForILHistory.Size = new System.Drawing.Size(207, 48);
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            this.InternationalLicenseHistorytoolStripMenuItem.Image = global::DVLD_Project.Properties.Resources.id_card;
            this.InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            this.InternationalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(206, 32);
            this.InternationalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            this.InternationalLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.InternationalLicenseHistorytoolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(203, 6);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 20);
            this.label4.TabIndex = 113;
            this.label4.Text = "International License History:";
            // 
            // ctrDriverLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.Name = "ctrDriverLicenses";
            this.Size = new System.Drawing.Size(1192, 432);
            this.groupBox1.ResumeLayout(false);
            this.TbCtrDriverLicenses.ResumeLayout(false);
            this.TbLocal.ResumeLayout(false);
            this.TbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVLocal)).EndInit();
            this.CMStripForLLHistory.ResumeLayout(false);
            this.TbInternational.ResumeLayout(false);
            this.TbInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGVInternational)).EndInit();
            this.CMStripForILHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl TbCtrDriverLicenses;
        private System.Windows.Forms.TabPage TbLocal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LbLRecord;
        private System.Windows.Forms.DataGridView DataGVLocal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage TbInternational;
        private System.Windows.Forms.Label LbIRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DataGVInternational;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip CMStripForLLHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip CMStripForILHistory;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}
