using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;

namespace DVLD_Project.User
{
    public partial class frmAddUpdateUser : Form
    {
        enum enMode { Add= 0 ,Update = 1 };
        enMode _Mode = enMode.Add;

        int _UserID = -1;
        ClsUser _User;

        public frmAddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.Add;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            _Mode = enMode.Update;
        }
        private void _SetUpDefualtValues()
        {

            if(_Mode == enMode.Add)
            {
                LbMode.Text = "Add New User";
                this.Text = "Add New User";

                _User = new ClsUser();
                TbLoginInfo.Enabled = false;

                ctrPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                LbMode.Text = "Update User";
                this.Text = "Update User";

                TbLoginInfo.Enabled = true;
                BtnSave.Enabled = true;

            }

            TxtUserName.Text = "";
            TxtPassword.Text = "";
            TxtConfirmPassword.Text = "";

            ChboxIsActive.Checked = true;

        }
        private void _LoadData()
        {

            _User = ClsUser.FindByUserID(_UserID);
            ctrPersonCardWithFilter1.FilterEnabled = false;

            if(_User == null)
            {
                MessageBox.Show("No User with ID = " + _User.UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            //the following code will not be executed if the person was not found

            LbUserID.Text = _User.UserID.ToString();

            TxtUserName.Text = _User.UserName;
            TxtPassword.Text = _User.Password;
            TxtConfirmPassword.Text = _User.Password;

            ChboxIsActive.Checked = _User.IsActive;

            ctrPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            _SetUpDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }
        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrPersonCardWithFilter1.FilterFocus();

        }
        private void BtnNext_Click(object sender, EventArgs e)
        {

            if(_Mode == enMode.Update)
            {

                BtnSave.Enabled = true;
                TbLoginInfo.Enabled = true;
                TbCtrAddUpdate.SelectedTab = TbCtrAddUpdate.TabPages["TbLoginInfo"];

                return;
            }

            if(ctrPersonCardWithFilter1.PersonID != -1)
            {
                
                if(ClsUser.isUserExistForPersonID(ctrPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrPersonCardWithFilter1.FilterFocus();

                }
                else
                {
                    BtnSave.Enabled = true;
                    TbLoginInfo.Enabled = true;
                    TbCtrAddUpdate.SelectedTab = TbCtrAddUpdate.TabPages["TbLoginInfo"];
                }

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonCardWithFilter1.FilterFocus();

            }

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

            _User.PersonID = ctrPersonCardWithFilter1.PersonID;
            _User.UserName = TxtUserName.Text.Trim();
            _User.Password = TxtPassword.Text.Trim();
            _User.IsActive = ChboxIsActive.Checked;

            if(_User.Save())
            {

                LbUserID.Text = _User.UserID.ToString();
                LbMode.Text = "Update User";
                _Mode = enMode.Update;
                this.Text = "Update User";

                ctrPersonCardWithFilter1.FilterEnabled = false;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(TxtPassword, null);
            }

        }
        private void TxtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {

            if(TxtConfirmPassword.Text.Trim() != TxtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(TxtConfirmPassword, null);
            }

        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtUserName, "Username cannot be blank");

                return;
            }
            else
            {
                errorProvider1.SetError(TxtUserName, null);
            }

            if(_Mode == enMode.Add)
            {
                if(ClsUser.isUserExist(TxtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(TxtUserName, "Username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(TxtUserName, null);
                }
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != TxtUserName.Text.Trim())
                {
                    if (ClsUser.isUserExist(TxtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(TxtUserName, "Username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(TxtUserName, null);
                    }

                }
            }

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
