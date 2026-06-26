using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;

namespace DVLD_Project.User
{
    public partial class frmChangePassword : Form
    {
        private int _UserID;
        private ClsUser _User;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }
        private void _ResetDefualtValues()
        {

            TxtCurrentPassword.Text = "";
            TxtNewPassword.Text = "";
            TxtConfirmPassword.Text = "";

            TxtCurrentPassword.Focus();

        }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            _User = ClsUser.FindByUserID(_UserID);

            if(_User == null)
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
                return;
            }

            ctrUserCard1.LoadUserData(_UserID);

        }
        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            TxtCurrentPassword.Focus();

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if(!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            if(ClsUser.ChangePassword(_UserID,TxtNewPassword.Text.Trim()))
            {

                MessageBox.Show("Password Changed Successfully.",
                   "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TxtCurrentPassword.Enabled = false;
                TxtNewPassword.Enabled = false;
                TxtConfirmPassword.Enabled = false;

            }

            else
            {

                MessageBox.Show("An Erro Occured, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void TxtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(TxtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtCurrentPassword, "Current password cannot be blank");
                return;
            }
            else if(TxtCurrentPassword.Text.Trim() != _User.Password)
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
                errorProvider1.SetError(TxtCurrentPassword, null);

        }
        private void TxtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtNewPassword, "New Password cannot be blank");

                return;
            }
            else if(TxtCurrentPassword.Text.Trim() == TxtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtNewPassword, "This Password is the same as the original!");

                return;
            }
            else
            {
                errorProvider1.SetError(TxtNewPassword, null);
            }

        }
        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if(TxtConfirmPassword.Text.Trim() != TxtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(TxtConfirmPassword, null);
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
    }
}
