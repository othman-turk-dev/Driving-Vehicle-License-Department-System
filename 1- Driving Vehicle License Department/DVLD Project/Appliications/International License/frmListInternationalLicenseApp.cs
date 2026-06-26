using System;
using System.Data;
using DVLD_BusinessLayer;
using DVLD_Project.People;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.International_License;
using DVLD_Project.Licenses;

namespace DVLD_Project.Appliications.International_License
{
    public partial class frmListInternationalLicenseApp : Form
    {
        private DataTable _dtInternationalLicenseApplications;
        public frmListInternationalLicenseApp()
        {
            InitializeComponent();
        }

        private void frmListInternationalLicenseApp_Load(object sender, EventArgs e)
        {

            _dtInternationalLicenseApplications = ClsInternationalLicense.GetAllInternationalLicenses();
            DGVInternationalLicense.DataSource = _dtInternationalLicenseApplications;
            
            lblRecordsCount.Text = DGVInternationalLicense.Rows.Count.ToString();

            if (DGVInternationalLicense.Rows.Count > 0)
            {
                DGVInternationalLicense.Columns[0].HeaderText = "Int.License ID";
                DGVInternationalLicense.Columns[0].Width = 100;

                DGVInternationalLicense.Columns[1].HeaderText = "Application ID";
                DGVInternationalLicense.Columns[1].Width = 100;

                DGVInternationalLicense.Columns[2].HeaderText = "Driver ID";
                DGVInternationalLicense.Columns[2].Width = 80;

                DGVInternationalLicense.Columns[3].HeaderText = "L.License ID";
                DGVInternationalLicense.Columns[3].Width = 100;

                DGVInternationalLicense.Columns[4].HeaderText = "Issue Date";
                DGVInternationalLicense.Columns[4].Width = 150;

                DGVInternationalLicense.Columns[5].HeaderText = "Expiration Date";
                DGVInternationalLicense.Columns[5].Width = 150;

                DGVInternationalLicense.Columns[6].HeaderText = "Is Active";
                DGVInternationalLicense.Columns[6].Width = 100;

            }

            CbFilterBy.SelectedIndex = 0;

        }
        private void btnAddApplication_Click(object sender, EventArgs e)
        {
            Form frm = new frmIssueInternationalLicenseApp();
            frm.ShowDialog();

            frmListInternationalLicenseApp_Load(null, null);
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int DriverID = (int)DGVInternationalLicense.CurrentRow.Cells[2].Value;
            int PersonID = ClsDriver.FindByDriverID(DriverID).PersonID;

            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

            frmListInternationalLicenseApp_Load(null, null);
        }
        private void showLicenseDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int InternationalLicenseID = (int)DGVInternationalLicense.CurrentRow.Cells[0].Value;
            Form frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);

            frm.ShowDialog();
            frmListInternationalLicenseApp_Load(null, null);
        }
        private void _ResetFilter()
        {

            _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            lblRecordsCount.Text = _dtInternationalLicenseApplications.Rows.Count.ToString();
        }
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _ResetFilter();

            if (CbFilterBy.Text == "Is Active")
            {
                TxtFilterValue.Visible = false;
                CbIsActive.Visible = true;
                CbIsActive.Focus();
                CbIsActive.SelectedIndex = 0;
            }

            else

            {

                TxtFilterValue.Visible = (CbFilterBy.Text != "None");
                CbIsActive.Visible = false;

                if (CbFilterBy.Text == "None")
                {
                    TxtFilterValue.Enabled = false;
                    //_dtDetainedLicenses.DefaultView.RowFilter = "";
                    //lblTotalRecords.Text = dgvDetainedLicenses.Rows.Count.ToString();

                }
                else
                    TxtFilterValue.Enabled = true;

                TxtFilterValue.Text = "";
                TxtFilterValue.Focus();

            }

        }
        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsActive";
            string FilterValue = CbIsActive.Text;

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }


            if (FilterValue == "All")
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblRecordsCount.Text = DGVInternationalLicense.Rows.Count.ToString();

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;
                case "Application ID":
                    {
                        FilterColumn = "ApplicationID";
                        break;
                    };

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "IssuedUsingLocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInternationalLicenseApplications.DefaultView.RowFilter = "";
                lblRecordsCount.Text = DGVInternationalLicense.Rows.Count.ToString();
                return;
            }



            _dtInternationalLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());

            lblRecordsCount.Text = DGVInternationalLicense.Rows.Count.ToString();

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow numbers only becasue all fiters are numbers.
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)DGVInternationalLicense.CurrentRow.Cells[2].Value;
            int PersonID = ClsDriver.FindByDriverID(DriverID).PersonID;

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();

            frmListInternationalLicenseApp_Load(null, null);
        }
        private void frmListInternationalLicenseApp_Shown(object sender, EventArgs e)
        {

            ClsSettingColore.ColoreForDataGritView(DGVInternationalLicense, CMStripForApp);
        }
        private void DGVInternationalLicense_DoubleClick(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)DGVInternationalLicense.CurrentRow.Cells[0].Value;
            Form frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);

            frm.ShowDialog();
            frmListInternationalLicenseApp_Load(null, null);
        }
   
    }
}
