using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Licenses;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Appliications.Renew_Local_License
{
    public partial class frmRenewLocalDrivingLicenseApp : Form
    {
        int _NewLicenseID = -1;
        public frmRenewLocalDrivingLicenseApp()
        {
            InitializeComponent();
        }
        private void _LoadDefaultData()
        {

            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

            LbExpritionDate.Text = "???";

            LbAppDate.Text = DateTime.Now.ToShortDateString();
            LbIssueDate.Text = DateTime.Now.ToShortDateString();
            LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeFees.ToString();
            LbCreateBy.Text = ClsGlobal.GlobalUser.UserName;

        }
        private void frmRenewLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            _LoadDefaultData();
            
        }
        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            LbOldLicenseID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
            {
                LLbShowNewLicenseInfo.Visible = false;

                return;
            }

                LLbShowLicenseHistory.Visible = true;

            int DefaultValidityLength = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            LbExpritionDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            LbLicenseFees.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            LbTotalFees.Text = (Convert.ToDecimal(LbAppFees.Text) + Convert.ToDecimal(LbLicenseFees.Text)).ToString();
            TxtNotes.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            //check the license is not Expired.
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " + ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnRenew.Enabled = false;
                return;
            }

            //check the license is not Active.
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                BtnRenew.Enabled = false;
                return;
            }

            BtnRenew.Enabled = true;
        }
        private void LLbShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowLicenseInfo(_NewLicenseID);
            form.ShowDialog();

        }
        private void LLbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowPersonLicenseHistory
                (ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            form.ShowDialog();

        }
        private void BtnRenew_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            ClsLicenses NewLicense =
                ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(TxtNotes.Text.Trim(),
                ClsGlobal.GlobalUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LbRLAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            LbRenewLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnRenew.Enabled = false;

            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            LLbShowNewLicenseInfo.Visible = true;

        }
        private void frmRenewLocalDrivingLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }

    }
}
