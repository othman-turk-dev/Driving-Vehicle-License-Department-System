using System;
using System.Data;
using DVLD_Project.People;
using System.Windows.Forms;
using System.ComponentModel;
using DVLD_Project.Licenses;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.LocalLicenses;
using DVLD_Project.Licenses.Detain_License;

namespace DVLD_Project.Appliications.Release_Detained_License
{
    public partial class frmListDetainLicense : Form
    {
        private DataTable _dtDetainedLicenses;
        public frmListDetainLicense()
        {
            InitializeComponent();
        }
        private void BtnReleaseLicense_Click(object sender, EventArgs e)
        {
            Form form = new frmReleaseDetainedLicenseApp();
            form.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }
        private void frmListDetainLicense_Load(object sender, EventArgs e)
        {

            _dtDetainedLicenses = ClsDetainedLicenses.GetAllDetainedLicenses();

            DGVDetainedLicense.DataSource = _dtDetainedLicenses;
            lblTotalRecords.Text = DGVDetainedLicense.Rows.Count.ToString();

            if (DGVDetainedLicense.Rows.Count > 0)
            {
                DGVDetainedLicense.Columns[0].HeaderText = "Detain ID";
                DGVDetainedLicense.Columns[0].Width = 80;

                DGVDetainedLicense.Columns[1].HeaderText = "License ID";
                DGVDetainedLicense.Columns[1].Width = 90;

                DGVDetainedLicense.Columns[2].HeaderText = "Detained Date";
                DGVDetainedLicense.Columns[2].Width = 110;

                DGVDetainedLicense.Columns[3].HeaderText = "Is Released";
                DGVDetainedLicense.Columns[3].Width = 80;

                DGVDetainedLicense.Columns[4].HeaderText = "Fine Fees";
                DGVDetainedLicense.Columns[4].Width = 100;

                DGVDetainedLicense.Columns[5].HeaderText = "Release Date";
                DGVDetainedLicense.Columns[5].Width = 130;

                DGVDetainedLicense.Columns[6].HeaderText = "National No.";
                DGVDetainedLicense.Columns[6].Width = 100;

                DGVDetainedLicense.Columns[7].HeaderText = "Full Name";
                DGVDetainedLicense.Columns[7].Width = 250;

                DGVDetainedLicense.Columns[8].HeaderText = "Rlease App.ID";
                DGVDetainedLicense.Columns[8].Width = 110;

            }

            CbFilterBy.SelectedIndex = 0;

        }
        private void btnAddDetainedLicense_Click(object sender, EventArgs e)
        {
            Form form = new frmDetainLicenseApplication();
            form.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicense.CurrentRow.Cells[1].Value;
            int PersonID = ClsLicenses.FindByLicenseID(LicenseID).DriverInfo.PersonID;

            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void _ResetFilter()
        {
            _dtDetainedLicenses.DefaultView.RowFilter = "";
            lblTotalRecords.Text = _dtDetainedLicenses.Rows.Count.ToString();

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {
                case "Detain ID":
                    FilterColumn = "DetainID";
                    break;
                case "Is Released":
                    {
                        FilterColumn = "IsReleased";
                        break;
                    };

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }


            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtDetainedLicenses.DefaultView.RowFilter = "";
                lblTotalRecords.Text = DGVDetainedLicense.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

            lblTotalRecords.Text = DGVDetainedLicense.Rows.Count.ToString();

        }
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            _ResetFilter();

            if (CbFilterBy.Text == "Is Released")
            {
                TxtFilterValue.Visible = false;
                CbRelease.Visible = true;
                CbRelease.Focus();
                CbRelease.SelectedIndex = 0;
            }

            else

            {

                TxtFilterValue.Visible = (CbFilterBy.Text != "None");
                CbRelease.Visible = false;

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
        private void CbRelease_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "IsReleased";
            string FilterValue = CbRelease.Text;

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
                _dtDetainedLicenses.DefaultView.RowFilter = "";
            else
                //in this case we deal with numbers not string.
                _dtDetainedLicenses.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

            lblTotalRecords.Text = DGVDetainedLicense.Rows.Count.ToString();

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (CbFilterBy.Text == "Detain ID" || CbFilterBy.Text == "Release Application ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (CbFilterBy.Text == "Full Name")
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicense.CurrentRow.Cells[1].Value;
            int PersonID = ClsLicenses.FindByLicenseID(LicenseID).DriverInfo.PersonID;
            
            Form  frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }
        private void showLicenseDetailseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicense.CurrentRow.Cells[1].Value;

            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }
        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicense.CurrentRow.Cells[1].Value;

            Form frm = new frmReleaseDetainedLicenseApp(LicenseID);
            frm.ShowDialog();
            //refresh
            frmListDetainLicense_Load(null, null);
        }
        private void CMStripForDetainedApp_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled = !(bool)DGVDetainedLicense.CurrentRow.Cells[3].Value;

        }
        private void frmListDetainLicense_Shown(object sender, EventArgs e)
        {

            ClsSettingColore.ColoreForDataGritView(DGVDetainedLicense, CMStripForDetainedApp);
        }
        private void DGVDetainedLicense_DoubleClick(object sender, EventArgs e)
        {
            int LicenseID = (int)DGVDetainedLicense.CurrentRow.Cells[1].Value;

            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();

            frmListDetainLicense_Load(null, null);
        }

    }
}
