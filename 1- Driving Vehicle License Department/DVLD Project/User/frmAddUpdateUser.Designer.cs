namespace DVLD_Project.User
{
    partial class frmAddUpdateUser
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
            this.TbCtrAddUpdate = new System.Windows.Forms.TabControl();
            this.TbPersonalInfo = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.BtnNext = new System.Windows.Forms.Button();
            this.ctrPersonCardWithFilter1 = new DVLD_Project.People.Control.ctrPersonCardWithFilter();
            this.TbLoginInfo = new System.Windows.Forms.TabPage();
            this.ChboxIsActive = new System.Windows.Forms.CheckBox();
            this.TxtConfirmPassword = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LbUserID = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LbMode = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.TbCtrAddUpdate.SuspendLayout();
            this.TbPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.TbLoginInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TbCtrAddUpdate
            // 
            this.TbCtrAddUpdate.Controls.Add(this.TbPersonalInfo);
            this.TbCtrAddUpdate.Controls.Add(this.TbLoginInfo);
            this.TbCtrAddUpdate.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbCtrAddUpdate.Location = new System.Drawing.Point(25, 107);
            this.TbCtrAddUpdate.Name = "TbCtrAddUpdate";
            this.TbCtrAddUpdate.SelectedIndex = 0;
            this.TbCtrAddUpdate.Size = new System.Drawing.Size(994, 532);
            this.TbCtrAddUpdate.TabIndex = 0;
            // 
            // TbPersonalInfo
            // 
            this.TbPersonalInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TbPersonalInfo.Controls.Add(this.pictureBox3);
            this.TbPersonalInfo.Controls.Add(this.BtnNext);
            this.TbPersonalInfo.Controls.Add(this.ctrPersonCardWithFilter1);
            this.TbPersonalInfo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.TbPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.TbPersonalInfo.Name = "TbPersonalInfo";
            this.TbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TbPersonalInfo.Size = new System.Drawing.Size(986, 499);
            this.TbPersonalInfo.TabIndex = 0;
            this.TbPersonalInfo.Text = "Personal Info";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::DVLD_Project.Properties.Resources.right_arrows;
            this.pictureBox3.Location = new System.Drawing.Point(910, 445);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // BtnNext
            // 
            this.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNext.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNext.Location = new System.Drawing.Point(810, 439);
            this.BtnNext.Name = "BtnNext";
            this.BtnNext.Size = new System.Drawing.Size(144, 46);
            this.BtnNext.TabIndex = 1;
            this.BtnNext.Text = "Next";
            this.BtnNext.UseVisualStyleBackColor = true;
            this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // ctrPersonCardWithFilter1
            // 
            this.ctrPersonCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrPersonCardWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ctrPersonCardWithFilter1.FilterEnabled = true;
            this.ctrPersonCardWithFilter1.ForeColor = System.Drawing.Color.Snow;
            this.ctrPersonCardWithFilter1.Location = new System.Drawing.Point(3, 6);
            this.ctrPersonCardWithFilter1.Name = "ctrPersonCardWithFilter1";
            this.ctrPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrPersonCardWithFilter1.Size = new System.Drawing.Size(966, 427);
            this.ctrPersonCardWithFilter1.TabIndex = 0;
            // 
            // TbLoginInfo
            // 
            this.TbLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TbLoginInfo.Controls.Add(this.ChboxIsActive);
            this.TbLoginInfo.Controls.Add(this.TxtConfirmPassword);
            this.TbLoginInfo.Controls.Add(this.TxtPassword);
            this.TbLoginInfo.Controls.Add(this.TxtUserName);
            this.TbLoginInfo.Controls.Add(this.pictureBox7);
            this.TbLoginInfo.Controls.Add(this.pictureBox6);
            this.TbLoginInfo.Controls.Add(this.pictureBox5);
            this.TbLoginInfo.Controls.Add(this.pictureBox4);
            this.TbLoginInfo.Controls.Add(this.label3);
            this.TbLoginInfo.Controls.Add(this.label2);
            this.TbLoginInfo.Controls.Add(this.label1);
            this.TbLoginInfo.Controls.Add(this.LbUserID);
            this.TbLoginInfo.Controls.Add(this.label9);
            this.TbLoginInfo.Font = new System.Drawing.Font("Tahoma", 8F);
            this.TbLoginInfo.Location = new System.Drawing.Point(4, 29);
            this.TbLoginInfo.Name = "TbLoginInfo";
            this.TbLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TbLoginInfo.Size = new System.Drawing.Size(986, 499);
            this.TbLoginInfo.TabIndex = 1;
            this.TbLoginInfo.Text = "Login Info";
            // 
            // ChboxIsActive
            // 
            this.ChboxIsActive.AutoSize = true;
            this.ChboxIsActive.Checked = true;
            this.ChboxIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChboxIsActive.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChboxIsActive.Location = new System.Drawing.Point(291, 324);
            this.ChboxIsActive.Name = "ChboxIsActive";
            this.ChboxIsActive.Size = new System.Drawing.Size(93, 22);
            this.ChboxIsActive.TabIndex = 67;
            this.ChboxIsActive.Text = "Is Active";
            this.ChboxIsActive.UseVisualStyleBackColor = true;
            // 
            // TxtConfirmPassword
            // 
            this.TxtConfirmPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxtConfirmPassword.Font = new System.Drawing.Font("Verdana", 11F);
            this.TxtConfirmPassword.Location = new System.Drawing.Point(291, 258);
            this.TxtConfirmPassword.Name = "TxtConfirmPassword";
            this.TxtConfirmPassword.PasswordChar = '*';
            this.TxtConfirmPassword.Size = new System.Drawing.Size(211, 30);
            this.TxtConfirmPassword.TabIndex = 3;
            this.TxtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtConfirmPassword_Validating);
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxtPassword.Font = new System.Drawing.Font("Verdana", 11F);
            this.TxtPassword.Location = new System.Drawing.Point(291, 209);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(211, 30);
            this.TxtPassword.TabIndex = 2;
            this.TxtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.TxtPassword_Validating);
            // 
            // TxtUserName
            // 
            this.TxtUserName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.TxtUserName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserName.Location = new System.Drawing.Point(291, 150);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(211, 26);
            this.TxtUserName.TabIndex = 1;
            this.TxtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtUserName_Validating);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::DVLD_Project.Properties.Resources.password__2_;
            this.pictureBox7.Location = new System.Drawing.Point(240, 259);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(32, 28);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 66;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::DVLD_Project.Properties.Resources.password__2_;
            this.pictureBox6.Location = new System.Drawing.Point(240, 210);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 28);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 65;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::DVLD_Project.Properties.Resources.user1;
            this.pictureBox5.Location = new System.Drawing.Point(240, 150);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 28);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 64;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::DVLD_Project.Properties.Resources.id__1_;
            this.pictureBox4.Location = new System.Drawing.Point(240, 104);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 28);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 63;
            this.pictureBox4.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(45, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 20);
            this.label3.TabIndex = 62;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(126, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 61;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(123, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 60;
            this.label1.Text = "Username:";
            // 
            // LbUserID
            // 
            this.LbUserID.AutoSize = true;
            this.LbUserID.Font = new System.Drawing.Font("Tahoma", 10F);
            this.LbUserID.Location = new System.Drawing.Point(288, 109);
            this.LbUserID.Name = "LbUserID";
            this.LbUserID.Size = new System.Drawing.Size(48, 21);
            this.LbUserID.TabIndex = 59;
            this.LbUserID.Text = "[???]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(146, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 58;
            this.label9.Text = "User ID:";
            // 
            // LbMode
            // 
            this.LbMode.AutoSize = true;
            this.LbMode.Font = new System.Drawing.Font("Palatino Linotype", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbMode.ForeColor = System.Drawing.Color.SteelBlue;
            this.LbMode.Location = new System.Drawing.Point(363, 30);
            this.LbMode.Name = "LbMode";
            this.LbMode.Size = new System.Drawing.Size(327, 60);
            this.LbMode.TabIndex = 1;
            this.LbMode.Text = "Add New User";
            // 
            // BtnClose
            // 
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.Location = new System.Drawing.Point(701, 661);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(144, 46);
            this.BtnClose.TabIndex = 2;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = true;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSave.Location = new System.Drawing.Point(875, 661);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(144, 46);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DVLD_Project.Properties.Resources.download;
            this.pictureBox2.Location = new System.Drawing.Point(888, 667);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DVLD_Project.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(711, 667);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateUser
            // 
            this.AcceptButton = this.BtnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1065, 733);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.LbMode);
            this.Controls.Add(this.TbCtrAddUpdate);
            this.ForeColor = System.Drawing.Color.Snow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Update User";
            this.Activated += new System.EventHandler(this.frmAddUpdateUser_Activated);
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.TbCtrAddUpdate.ResumeLayout(false);
            this.TbPersonalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.TbLoginInfo.ResumeLayout(false);
            this.TbLoginInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TbCtrAddUpdate;
        private System.Windows.Forms.TabPage TbPersonalInfo;
        private System.Windows.Forms.TabPage TbLoginInfo;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button BtnNext;
        private People.Control.ctrPersonCardWithFilter ctrPersonCardWithFilter1;
        private System.Windows.Forms.Label LbMode;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbUserID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtConfirmPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.CheckBox ChboxIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}