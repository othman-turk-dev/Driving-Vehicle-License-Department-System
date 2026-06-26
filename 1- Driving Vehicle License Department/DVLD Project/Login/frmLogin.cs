using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Login
{
    public partial class frmLogin : Form
    {
        private ClsUser _User;
        public frmLogin()
        {

            InitializeComponent();
        }
        private void _Login()
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }

            _User = ClsUser.FindByUsernameAndPassword(TxtUserName.Text.Trim(),
                TxtPassword.Text.Trim());

            if (_User == null)
            {
                MessageBox.Show("Password is not Correct!");
                return;
            }

            if (!_User.IsActive)
            {
                MessageBox.Show("This user is not Active, Contact Admin.");

                return;
            }

            ClsGlobal.GlobalUser = _User;

            if (ChBoxRememberMe.Checked)
                ClsGlobal.UploadDataToFile(_User.UserName, _User.Password);
            else
                ClsGlobal.UploadDataToFile();


            this.Hide();

            Form form = new FrmMain(this);
            form.ShowDialog();

        }
        private void frmLogin_Load(object sender, EventArgs e)
        {

            ChBoxRememberMe.Checked = true;

            string UserName="", Password="";
            ClsGlobal.DownloadDataFromFile(ref UserName, ref Password);

            TxtUserName.Text = UserName;
            TxtPassword.Text = Password;

        }
        private void frmLogin_Activated(object sender, EventArgs e)
        {

            TxtUserName.Focus();
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {

            _Login();
        }
        private void PicLogin_Click(object sender, EventArgs e)
        {

            _Login();
        }
        private void TxtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtUserName, "This field is required!");
                return;
            }
            else if(!ClsUser.isUserExist(TxtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtUserName, "There is no user with this username!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtUserName, null);
            }

        }
        private void TxtPassword_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtPassword, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtPassword, null);
            }

        }
        private void PicExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
