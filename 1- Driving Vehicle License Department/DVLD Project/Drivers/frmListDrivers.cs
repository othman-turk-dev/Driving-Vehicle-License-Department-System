using System;
using System.Data;
using DVLD_Project.People;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses;

namespace DVLD_Project.Drivers
{
    public partial class frmListDrivers : Form
    {

        private DataTable _dtAllDrivers;
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmListDrivers_Load(object sender, EventArgs e)
        {

            CbFilterBy.SelectedIndex = 0;

            _dtAllDrivers = ClsDriver.GetAllDrivers();
            DataGVDrivers.DataSource = _dtAllDrivers;

            LbRecord.Text = DataGVDrivers.Rows.Count.ToString();

            if (DataGVDrivers.Rows.Count > 0)
            {
                DataGVDrivers.Columns[0].HeaderText = "Driver ID";
                DataGVDrivers.Columns[0].Width = 80;

                DataGVDrivers.Columns[1].HeaderText = "Person ID";
                DataGVDrivers.Columns[1].Width = 90;

                DataGVDrivers.Columns[2].HeaderText = "National No.";
                DataGVDrivers.Columns[2].Width = 110;

                DataGVDrivers.Columns[3].HeaderText = "Full Name";
                DataGVDrivers.Columns[3].Width = 290;

                DataGVDrivers.Columns[4].HeaderText = "Date";
                DataGVDrivers.Columns[4].Width = 130;

                DataGVDrivers.Columns[5].HeaderText = "Active Licenses";
                DataGVDrivers.Columns[5].Width = 120;
            }

        }
        private void CbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtFilterValue.Visible = (CbFilterBy.Text != "None");


            if (CbFilterBy.Text == "None")
            {
                TxtFilterValue.Enabled = false;
            }
            else
                TxtFilterValue.Enabled = true;

            TxtFilterValue.Text = "";
            TxtFilterValue.Focus();

        }
        private void TxtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (CbFilterBy.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (TxtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                LbRecord.Text = DataGVDrivers.Rows.Count.ToString();

                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "NationalNo")
                //in this case we deal with numbers not string.
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, TxtFilterValue.Text.Trim());
            else
                _dtAllDrivers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, TxtFilterValue.Text.Trim());

            LbRecord.Text = DataGVDrivers.Rows.Count.ToString();

        }
        private void TxtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id or user id is selected.
            if (CbFilterBy.Text == "Driver ID" || CbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            if (CbFilterBy.Text == "Full Name")
                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DataGVDrivers.CurrentRow.Cells[1].Value;
            Form frm = new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
            frmListDrivers_Load(null, null);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DataGVDrivers.CurrentRow.Cells[1].Value;

            Form form = new frmShowPersonLicenseHistory(PersonID);
            form.ShowDialog();

            frmListDrivers_Load(null, null);
        }
        private void frmListDrivers_Shown(object sender, EventArgs e)
        {

            ClsSettingColore.ColoreForDataGritView(DataGVDrivers, CMStripForDrivers);
        }
        private void DataGVDrivers_DoubleClick(object sender, EventArgs e)
        {
            int PersonID = (int)DataGVDrivers.CurrentRow.Cells[1].Value;
            Form frm = new frmShowPersonInfo(PersonID);

            frm.ShowDialog();
            frmListDrivers_Load(null, null);
        }

    }
}
