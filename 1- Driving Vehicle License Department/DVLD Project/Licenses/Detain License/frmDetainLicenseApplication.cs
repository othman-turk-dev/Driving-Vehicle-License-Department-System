using System;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Licenses.Detain_License
{
    public partial class frmDetainLicenseApplication : Form
    {
        int _LicenseID = -1;
        public frmDetainLicenseApplication()
        {
            InitializeComponent();
        }
        private void TxtFineFees_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(TxtFineFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(TxtFineFees, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(TxtFineFees, null);
            }

        }
        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            LbLicensesID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
            {
                LLbShowLicenseHistory.Visible = false;
                LLbShowLicenseInfo.Visible = false;

                return;
            }

            LLbShowLicenseHistory.Visible = true;
            LLbShowLicenseInfo.Visible = true;

            _LicenseID = SelectedLicenseID;


            if(!ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("This license is not active, license should Active !",
                    "Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return;
            }

            if(ClsDetainedLicenses.IsLicenseDetained(SelectedLicenseID))
            {
                MessageBox.Show("This license is already Detained..!","Not Allowed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
                return;
            }

            TxtFineFees.Focus();
            BtnDetain.Enabled = true;

        }
        private void frmDetainLicenseApplication_Load(object sender, EventArgs e)
        {

            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

            LbDetainDate.Text = DateTime.Now.ToShortDateString();
            LbUsersName.Text = ClsGlobal.GlobalUser.UserName;

        }
        private void TxtFineFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void BtnDetain_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are other required fields", "Not Saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to Detain the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ClsDetainedLicenses DetainLicense =
                ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Detain(Convert.ToDecimal(TxtFineFees.Text), ClsGlobal.GlobalUser.UserID);

            if (DetainLicense == null)
            {
                MessageBox.Show("Faild to Detain the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            
            LbDetainID.Text = DetainLicense.DetainID.ToString();

            MessageBox.Show("Licensed Detain Successfully with ID=" + DetainLicense.DetainID.ToString(), "License Detain", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnDetain.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            TxtFineFees.Enabled = false;

        }
        private void LLbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(_LicenseID);
            frm.ShowDialog();
        }
        private void LLbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void frmDetainLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }

    }

}
