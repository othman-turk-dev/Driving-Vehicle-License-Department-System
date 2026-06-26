using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Project.General_Tools;
using DVLD_Project.Licenses.International_License;
using DVLD_Project.Licenses.LocalLicenses;

namespace DVLD_Project.Licenses.Control
{
    public partial class ctrDriverLicenses : UserControl
    {

        private int _DriverID = -1;
        private ClsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrDriverLicenses()
        {
            InitializeComponent();
        }

        private void _LoadLocalLicenseInfo()
        {

            ClsSettingColore.ColoreForDataGritView(DataGVLocal, CMStripForLLHistory);
            _dtDriverLocalLicensesHistory = ClsDriver.GetLicenses(_DriverID);


            DataGVLocal.DataSource = _dtDriverLocalLicensesHistory;
            LbLRecord.Text = DataGVLocal.Rows.Count.ToString();

            if (DataGVLocal.Rows.Count > 0)
            {
                DataGVLocal.Columns[0].HeaderText = "License ID";
                DataGVLocal.Columns[0].Width = 100;

                DataGVLocal.Columns[1].HeaderText = "Application ID";
                DataGVLocal.Columns[1].Width = 110;

                DataGVLocal.Columns[2].HeaderText = "Class Name";
                DataGVLocal.Columns[2].Width = 240;

                DataGVLocal.Columns[3].HeaderText = "Issue Date";
                DataGVLocal.Columns[3].Width = 170;

                DataGVLocal.Columns[4].HeaderText = "Expiration Date";
                DataGVLocal.Columns[4].Width = 170;

                DataGVLocal.Columns[5].HeaderText = "Is Active";
                DataGVLocal.Columns[5].Width = 110;

            }
        }
        private void _LoadInternationalLicenseInfo()
        {

            ClsSettingColore.ColoreForDataGritView(DataGVInternational, CMStripForILHistory);
            _dtDriverInternationalLicensesHistory =  ClsDriver.GetInternationalLicenses(_DriverID);

            DataGVInternational.DataSource = _dtDriverInternationalLicensesHistory;
            LbIRecord.Text = DataGVInternational.Rows.Count.ToString();

            if (DataGVInternational.Rows.Count > 0)
            {
                DataGVInternational.Columns[0].HeaderText = "Int.License ID";
                DataGVInternational.Columns[0].Width = 160;

                DataGVInternational.Columns[1].HeaderText = "Application ID";
                DataGVInternational.Columns[1].Width = 130;

                DataGVInternational.Columns[2].HeaderText = "L.License ID";
                DataGVInternational.Columns[2].Width = 130;

                DataGVInternational.Columns[3].HeaderText = "Issue Date";
                DataGVInternational.Columns[3].Width = 180;

                DataGVInternational.Columns[4].HeaderText = "Expiration Date";
                DataGVInternational.Columns[4].Width = 180;

                DataGVInternational.Columns[5].HeaderText = "Is Active";
                DataGVInternational.Columns[5].Width = 120;

            }

        }
        public void LoadData(int PersonID)
        {
            _Driver = ClsDriver.FindByPersonID(PersonID);

            if (_Driver == null)
            {
                MessageBox.Show("There is not driver with person id = " + PersonID, "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                return;
            }

            _DriverID = _Driver.DriverID;

            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();

        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)DataGVLocal.CurrentRow.Cells[0].Value;

            Form form = new frmShowLicenseInfo(LicenseID);
            form.ShowDialog();

        }
        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = (int)DataGVInternational.CurrentRow.Cells[0].Value;
            Form frm = new frmShowInternationalLicenseInfo(InternationalLicenseID);

            frm.ShowDialog();
        }
        public void Clear()
        {
            _dtDriverLocalLicensesHistory.Clear();
            _dtDriverInternationalLicensesHistory.Clear();

        }

    }
}
