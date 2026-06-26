namespace DVLD_Project.All_Operations_in_System
{
    partial class frmAllTests
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgViewTests = new System.Windows.Forms.DataGridView();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.DTPicker = new System.Windows.Forms.DateTimePicker();
            this.LbTitel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.ForeColor = System.Drawing.Color.Snow;
            this.BtnClose.Location = new System.Drawing.Point(1218, 724);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(149, 53);
            this.BtnClose.TabIndex = 109;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblRecordsCount.Location = new System.Drawing.Point(164, 724);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(28, 24);
            this.lblRecordsCount.TabIndex = 106;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 723);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 105;
            this.label2.Text = "# Records:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 104;
            this.label1.Text = "Filter By:";
            // 
            // dgViewTests
            // 
            this.dgViewTests.AllowUserToAddRows = false;
            this.dgViewTests.AllowUserToDeleteRows = false;
            this.dgViewTests.AllowUserToOrderColumns = true;
            this.dgViewTests.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dgViewTests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewTests.Location = new System.Drawing.Point(56, 139);
            this.dgViewTests.Name = "dgViewTests";
            this.dgViewTests.ReadOnly = true;
            this.dgViewTests.RowHeadersWidth = 51;
            this.dgViewTests.RowTemplate.Height = 26;
            this.dgViewTests.Size = new System.Drawing.Size(1311, 579);
            this.dgViewTests.TabIndex = 103;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::DVLD_Project.Properties.Resources.close1;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(1227, 735);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(42, 35);
            this.pictureBox9.TabIndex = 110;
            this.pictureBox9.TabStop = false;
            // 
            // DTPicker
            // 
            this.DTPicker.Location = new System.Drawing.Point(155, 95);
            this.DTPicker.MinDate = new System.DateTime(2025, 8, 18, 17, 39, 57, 0);
            this.DTPicker.Name = "DTPicker";
            this.DTPicker.Size = new System.Drawing.Size(200, 24);
            this.DTPicker.TabIndex = 111;
            this.DTPicker.Value = new System.DateTime(2025, 8, 18, 18, 50, 52, 0);
            this.DTPicker.ValueChanged += new System.EventHandler(this.DTPicker_ValueChanged);
            // 
            // LbTitel
            // 
            this.LbTitel.AutoSize = true;
            this.LbTitel.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitel.ForeColor = System.Drawing.Color.SteelBlue;
            this.LbTitel.Location = new System.Drawing.Point(493, 25);
            this.LbTitel.Name = "LbTitel";
            this.LbTitel.Size = new System.Drawing.Size(199, 48);
            this.LbTitel.TabIndex = 112;
            this.LbTitel.Text = "Welcom";
            // 
            // frmAllTests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1401, 789);
            this.Controls.Add(this.LbTitel);
            this.Controls.Add(this.DTPicker);
            this.Controls.Add(this.pictureBox9);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgViewTests);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAllTests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "All Tests";
            this.Load += new System.EventHandler(this.frmAllTests_Load);
            this.Shown += new System.EventHandler(this.frmAllTests_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgViewTests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgViewTests;
        private System.Windows.Forms.DateTimePicker DTPicker;
        private System.Windows.Forms.Label LbTitel;
    }
}