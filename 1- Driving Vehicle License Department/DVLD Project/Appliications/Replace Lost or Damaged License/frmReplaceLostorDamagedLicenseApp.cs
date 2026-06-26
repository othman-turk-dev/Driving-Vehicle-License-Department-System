using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Licenses;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Appliications.Replace_Lost_or_Damaged_License
{
    public partial class frmReplaceLostorDamagedLicenseApp : Form
    {

        int _NewLicenseID = -1;
        public frmReplaceLostorDamagedLicenseApp()
        {
            InitializeComponent();
        }
        private void _LoadDefaultData()
        {

            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

            LbAppDate.Text = DateTime.Now.ToShortDateString();
            LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.ReplaceDamagedDrivingLicense)
                .ApplicationTypeFees.ToString();
            LbCreateBy.Text = ClsGlobal.GlobalUser.UserName;

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
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            LbOldLicenseID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
            {
                LLbShowLicenseHistory.Visible = false;
                LLbShowNewLicenseInfo.Visible = false;

                return;
            }

                LLbShowLicenseHistory.Visible = true;

            //check the license is not not Active..!
            if (!ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnReplaceement.Enabled = false;
                return;
            }

            if(ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is Detained, go to release it first..!"
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnReplaceement.Enabled = false;
                return;
            }

            if(ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("This license need to renew befor becuase it is Expired since " + 
                    ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error); ;

                BtnReplaceement.Enabled = false;
                return;
            }

            BtnReplaceement.Enabled = true;

        }
        private void frmReplaceLostorDamagedLicenseApp_Load(object sender, EventArgs e)
        {

            _LoadDefaultData();
        }
        private void BtnReplaceement_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            bool DamagedIsCheck = RbDamagedLicense.Checked;

            ClsLicenses NewLicense =
                ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReplacementLicense(DamagedIsCheck, ClsGlobal.GlobalUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Replace the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            LbLRAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            LbReplaceLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Replace Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnReplaceement.Enabled = false;
            GbCauseofReplace.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;

            LLbShowNewLicenseInfo.Visible = true;
        }
        private void RbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.ReplaceDamagedDrivingLicense).ApplicationTypeFees.ToString();
            
        }
        private void RbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.ReplaceLostDrivingLicense).ApplicationTypeFees.ToString();

        }
        private void frmReplaceLostorDamagedLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }

    }
}
