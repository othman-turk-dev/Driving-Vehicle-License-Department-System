using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Tests;
using DVLD_Project.Licenses.LocalLicenses;
using DVLD_Project.Licenses;

namespace DVLD_Project.Appliications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApp : Form
    {
        public frmListLocalDrivingLicenseApp()
        {
            InitializeComponent();
        }

        private DataTable _DataTAllLocalLApp;
        
        private void frmListLocalDrivingLicenseApp_Load(object sender, EventArgs e)
        {

            _DataTAllLocalLApp = ClsLocalDrivingLicenseApplications.GetAllLocalDrivingLicenseApplicationss();
            dgViewLDLApp.DataSource = _DataTAllLocalLApp;

            lblRecordsCount.Text = dgViewLDLApp.Rows.Count.ToString();

            if (dgViewLDLApp.Rows.Count > 0)
            {

                dgViewLDLApp.Columns[0].HeaderText = "L.D.L.AppID";
                dgViewLDLApp.Columns[0].Width = 88;

                dgViewLDLApp.Columns[1].HeaderText = "Driving Class";
                dgViewLDLApp.Columns[1].Width = 240;

                dgViewLDLApp.Columns[2].HeaderText = "National No.";
                dgViewLDLApp.Columns[2].Width = 120;

                dgViewLDLApp.Columns[3].HeaderText = "Full Name";
                dgViewLDLApp.Columns[3].Width = 300;

                dgViewLDLApp.Columns[4].HeaderText = "Application Date";
                dgViewLDLApp.Columns[4].Width = 170;

                dgViewLDLApp.Columns[5].HeaderText = "Passed Tests";
                dgViewLDLApp.Columns[5].Width = 100;

                dgViewLDLApp.Columns[6].HeaderText = "Status";
                dgViewLDLApp.Columns[6].Width = 100;

            }

            CbFilterBy.SelectedIndex = 0;

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtFilterValue.Visible = (CbFilterBy.Text != "None");

            if (TxtFilterValue.Visible)
            {
                TxtFilterValue.Text = "";
                TxtFilterValue.Focus();
            }

            _DataTAllLocalLApp.DefaultView.RowFilter = "";
            lblRecordsCount.Text = dgViewLDLApp.Rows.Count.ToString();

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _DataTAllLocalLApp.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgViewLDLApp.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _DataTAllLocalLApp.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _DataTAllLocalLApp.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

            lblRecordsCount.Text = dgViewLDLApp.Rows.Count.ToString();

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (CbFilterBy.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if(CbFilterBy.Text == "Full Name" || CbFilterBy.Text == "Status")
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowLocalDrivingLicenseApp((int)dgViewLDLApp.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void btnAddLDLApp_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateLocalDrivingLicenseApp();
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmAddUpdateLocalDrivingLicenseApp((int)dgViewLDLApp.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            ClsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicenseApp_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            ClsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicenseApp_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not cancel applicatoin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            Form form = new frmListTestAppointments(LocalDrivingLicenseApplicationID, ClsTestType.enTestType.VisionTest);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            Form form = new frmListTestAppointments(LocalDrivingLicenseApplicationID, ClsTestType.enTestType.WrittenTest);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            Form form = new frmListTestAppointments(LocalDrivingLicenseApplicationID, ClsTestType.enTestType.StreetTest);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            Form form = new frmIssueDriverLicenseFirstTime(LocalDrivingLicenseApplicationID);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;

            int LicenseID = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void CMStripForApp_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            int LocalDrivingLicenseApplicationID = (int)dgViewLDLApp.CurrentRow.Cells[0].Value;
            ClsLocalDrivingLicenseApplications LocalDrivingLicenseApplication =
                    ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(LocalDrivingLicenseApplicationID);

            int TotalPassedTests = (int)dgViewLDLApp.CurrentRow.Cells[5].Value;

            bool LicenseExists = LocalDrivingLicenseApplication.IsLicenseIssued();
            bool IsPersonHaveAnyLicense = LocalDrivingLicenseApplication.IsPersonHaveAnyLicense();

            //Enabled only if person passed all tests and Does not have license. 
            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = (TotalPassedTests == 3) && !LicenseExists;


            showPersonLicenseHistoryToolStripMenuItem.Enabled = IsPersonHaveAnyLicense;
            showLicenseToolStripMenuItem.Enabled = LicenseExists;

            editToolStripMenuItem.Enabled = !LicenseExists && (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New) && (TotalPassedTests == 0);
            sechduleTestsToolStripMenuItem.Enabled = !LicenseExists;

            //Enable/Disable Cancel Menue Item
            //We only canel the applications with status=new.
            cancelApplicationToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);

            //Enable/Disable Delete Menue Item
            //We only allow delete incase the application status is new not complete or Cancelled.
            deleteToolStripMenuItem.Enabled = (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New) && (TotalPassedTests == 0);

            //Enable Disable Schedule menue and it's sub menue
            bool PassedVisionTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestType.enTestType.VisionTest); ;
            bool PassedWrittenTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = LocalDrivingLicenseApplication.DoesPassTestType(ClsTestType.enTestType.StreetTest);

            sechduleTestsToolStripMenuItem.Enabled = (!PassedVisionTest || !PassedWrittenTest || !PassedStreetTest) && (LocalDrivingLicenseApplication.ApplicationStatus == ClsApplication.enApplicationStatus.New);

            if (sechduleTestsToolStripMenuItem.Enabled)
            {
                //To Allow Schdule vision test, Person must not passed the same test before.
                scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;

                //To Allow Schdule written test, Person must pass the vision test and must not passed the same test before.
                scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;

                //To Allow Schdule steet test, Person must pass the vision * written tests, and must not passed the same test before.
                scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;

            }

        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new frmShowPersonLicenseHistory(ClsPerson.Find((string)dgViewLDLApp.CurrentRow.Cells[2].Value).PersonID);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
        private void frmListLocalDrivingLicenseApp_Shown(object sender, EventArgs e)
        {

            ClsSettingColore.ColoreForDataGritView(dgViewLDLApp, CMStripForApp);
        }
        private void dgViewLDLApp_DoubleClick(object sender, EventArgs e)
        {
            Form form = new frmShowLocalDrivingLicenseApp((int)dgViewLDLApp.CurrentRow.Cells[0].Value);
            form.ShowDialog();

            frmListLocalDrivingLicenseApp_Load(null, null);
        }
    
    }

}
