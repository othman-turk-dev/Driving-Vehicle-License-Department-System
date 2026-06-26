using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Licenses;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Appliications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicenseApp : Form
    {
        int _LicenseID = -1;
        public frmReleaseDetainedLicenseApp(int LicenseID)
        {
            InitializeComponent();

            _LicenseID = LicenseID;
            ctrDriverLicenseInfoWithFilter1.LoadLicenseInfo(_LicenseID);
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;

        }
        public frmReleaseDetainedLicenseApp()
        {
            InitializeComponent();
        }
        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;

            LbLicenseID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
            {
                LLbShowLicenseHistory.Visible = false;
                LLbShowLicenseInfo.Visible = false;
                return;
            }

            LLbShowLicenseHistory.Visible = true;
            LLbShowLicenseInfo.Visible = true;

            _LicenseID = SelectedLicenseID;

            if (!ClsDetainedLicenses.IsLicenseDetained(SelectedLicenseID))
            {
                MessageBox.Show("This license is not Detained..!", "Not Allowed", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            LbAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationTypeFees.ToString();
            LbCreateBy.Text = ClsGlobal.GlobalUser.UserName;

            LbDetainID.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            LbLicenseID.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            LbDetainDate.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate.ToShortDateString();
            LbFineFees.Text = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            LbTotalFees.Text = (Convert.ToDecimal(LbAppFees.Text) + Convert.ToDecimal(LbFineFees.Text)).ToString();

            BtnRelease.Enabled = true;

        }
        private void BtnRelease_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(ClsGlobal.GlobalUser.UserID, ref ApplicationID); ;

            LbApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnRelease.Enabled = false;
            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;

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
        private void frmReleaseDetainedLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

        }
    
    }
}
