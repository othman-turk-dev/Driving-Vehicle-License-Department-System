using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.All_Operations_in_System
{
    public partial class frmAllRequests : Form
    {

        DataTable _dtAllApplications;
        private void _LoadDefaultData()
        {

            DTPicker.MaxDate = DateTime.Now.AddDays(1);
            DTPicker.MinDate = DateTime.Now.AddDays(-30);

        }
        public frmAllRequests()
        {
            InitializeComponent();
        }
        private void frmAllRequests_Load(object sender, EventArgs e)
        {

            _LoadDefaultData();
            _dtAllApplications = ClsApplication.AllApplications();

            DateTime dtSelected = DTPicker.Value.Date;
            DataTable dtFilter = _dtAllApplications.Clone();

            foreach (DataRow row in _dtAllApplications.Rows)
            {

                if (((DateTime)row["ApplicationDate"]).Date == dtSelected)
                {
                    dtFilter.Rows.Add(row.ItemArray);
                }
            }

            dgViewApplications.DataSource = dtFilter;
            lblRecordsCount.Text = dgViewApplications.Rows.Count.ToString();

            if (dgViewApplications.Rows.Count > 0)
            {

                dgViewApplications.Columns[0].HeaderText = "Application ID";
                dgViewApplications.Columns[0].Width = 80;

                dgViewApplications.Columns[1].HeaderText = "Person Full Name";
                dgViewApplications.Columns[1].Width = 230;

                dgViewApplications.Columns[2].HeaderText = "Application Date";
                dgViewApplications.Columns[2].Width = 150;

                dgViewApplications.Columns[3].HeaderText = "Application Type";
                dgViewApplications.Columns[3].Width = 240;

                dgViewApplications.Columns[4].HeaderText = "Class Name";
                dgViewApplications.Columns[4].Width = 220;

                dgViewApplications.Columns[5].HeaderText = "Status";
                dgViewApplications.Columns[5].Width = 80;

                dgViewApplications.Columns[6].HeaderText = "Application Fees";
                dgViewApplications.Columns[6].Width = 100;

                dgViewApplications.Columns[7].HeaderText = "Created By User";
                dgViewApplications.Columns[7].Width = 90;

            }

        }
        private void frmAllRequests_Shown(object sender, EventArgs e)
        {
            DTPicker.Value = DateTime.Now;
            ClsSettingColore.ColoreForDataGritView(dgViewApplications, null);
            LbTitel.Text = $"Welcom {ClsGlobal.GlobalUser.UserName} !";

        }
        private void DTPicker_ValueChanged(object sender, EventArgs e)
        {
            frmAllRequests_Load(dgViewApplications, null);

        }

    }
}
