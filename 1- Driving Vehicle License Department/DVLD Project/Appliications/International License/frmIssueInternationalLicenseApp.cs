using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.International_License;
using DVLD_Project.Licenses;

namespace DVLD_Project.Appliications.International_License
{
    public partial class frmIssueInternationalLicenseApp : Form
    {
        int _InternationalLicenseID = -1;
        public frmIssueInternationalLicenseApp()
        {
            InitializeComponent();
        }
        private void _DefaultData()
        {
            LbAppDate.Text = DateTime.Now.ToShortDateString();
            LbCreateBy.Text = ClsGlobal.GlobalUser.UserName;
            LbExpritionDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            LbFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees.ToString();
            LbIssueDate.Text = DateTime.Now.ToShortDateString();

            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
        private void frmIssueInternationalLicenseApp_Load(object sender, EventArgs e)
        {

            _DefaultData();
        }
        private void ctrDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;
            LbLocalLicenseID.Text = SelectedLicenseID.ToString();

            if (SelectedLicenseID == -1)
            {
                LLbShowLicenseHistory.Visible = false;
                LLbShowLicenseInfo.Visible = false;

                return;
            }

            LLbShowLicenseHistory.Visible = true;

            ClsLicenses license = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (license.LicenseClass != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

                BtnIssue.Enabled = false;
                return;
            }

            if (!license.IsActive)
            {
                MessageBox.Show("This License is not active, select another one..!", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();

                BtnIssue.Enabled = false;
                return;
            }

            int ActiveInternaionalLicenseID = ClsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(license.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
                
                
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                LLbShowLicenseInfo.Visible = true;
                BtnIssue.Enabled = false; 

                return;
            }

            BtnIssue.Enabled = true;

        }
        private void BtnIssue_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            ClsInternationalLicense InternationalLicense = new ClsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicantPersonID = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            InternationalLicense.ApplicationDate = DateTime.Now;
            InternationalLicense.ApplicationStatus = ClsApplication.enApplicationStatus.New;
            InternationalLicense.LastStatusDate = DateTime.Now;
            InternationalLicense.PaidFees = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.NewInternationalLicense).ApplicationTypeFees;
            InternationalLicense.CreatedByUserID = ClsGlobal.GlobalUser.UserID;


            InternationalLicense.DriverID = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(ClsGlobal.AmountExpirationInternationalDate);

            InternationalLicense.CreatedByUserID = ClsGlobal.GlobalUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            InternationalLicense.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
            InternationalLicense.Save(); //Update Mode

            LbILAppID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            LbILLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnIssue.Enabled = false;

            ctrDriverLicenseInfoWithFilter1.FilterEnabled = false;
            LLbShowLicenseInfo.Visible = true;

        }
        private void LLbShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            form.ShowDialog();

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LLbShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new frmShowPersonLicenseHistory(ctrDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            form.ShowDialog();

        }
        private void frmIssueInternationalLicenseApp_Activated(object sender, EventArgs e)
        {
            ctrDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

    }
}
