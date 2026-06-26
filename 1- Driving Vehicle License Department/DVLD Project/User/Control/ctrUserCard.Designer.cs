namespace DVLD_Project.User.Control
{
    partial class ctrUserCard
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
            this.ctrPersonCard1 = new DVLD_Project.People.Control.ctrPersonCard();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LbIsActve = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LbUserName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LbLbUserID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrPersonCard1
            // 
            this.ctrPersonCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ctrPersonCard1.ForeColor = System.Drawing.Color.Snow;
            this.ctrPersonCard1.Location = new System.Drawing.Point(4, -6);
            this.ctrPersonCard1.Name = "ctrPersonCard1";
            this.ctrPersonCard1.Size = new System.Drawing.Size(928, 308);
            this.ctrPersonCard1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbIsActve);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.LbUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.LbLbUserID);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(4, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(928, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // LbIsActve
            // 
            this.LbIsActve.AutoSize = true;
            this.LbIsActve.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbIsActve.Location = new System.Drawing.Point(779, 26);
            this.LbIsActve.Name = "LbIsActve";
            this.LbIsActve.Size = new System.Drawing.Size(44, 23);
            this.LbIsActve.TabIndex = 63;
            this.LbIsActve.Text = "[???]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(673, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 62;
            this.label4.Text = "Is Active:";
            // 
            // LbUserName
            // 
            this.LbUserName.AutoSize = true;
            this.LbUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbUserName.Location = new System.Drawing.Point(501, 27);
            this.LbUserName.Name = "LbUserName";
            this.LbUserName.Size = new System.Drawing.Size(44, 23);
            this.LbUserName.TabIndex = 61;
            this.LbUserName.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(388, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "Username:";
            // 
            // LbLbUserID
            // 
            this.LbLbUserID.AutoSize = true;
            this.LbLbUserID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbLbUserID.Location = new System.Drawing.Point(276, 27);
            this.LbLbUserID.Name = "LbLbUserID";
            this.LbLbUserID.Size = new System.Drawing.Size(44, 23);
            this.LbLbUserID.TabIndex = 59;
            this.LbLbUserID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(186, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "User ID:";
            // 
            // ctrUserCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrPersonCard1);
            this.ForeColor = System.Drawing.Color.Snow;
            this.Name = "ctrUserCard";
            this.Size = new System.Drawing.Size(935, 361);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private People.Control.ctrPersonCard ctrPersonCard1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LbLbUserID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LbIsActve;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LbUserName;
        private System.Windows.Forms.Label label2;
    }
}
