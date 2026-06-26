using System;
using System.Data;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.General_Tools;

namespace DVLD_Project.All_Operations_in_System
{
    public partial class frmAllTests : Form
    {
        public frmAllTests()
        {
            InitializeComponent();
        }

        DataTable _dtAllTest;
        private void _LoadDefaultData()
        {

            DTPicker.MaxDate = DateTime.Now.AddDays(1);
            DTPicker.MinDate = DateTime.Now.AddDays(-30);

        }
        private void frmAllTests_Load(object sender, EventArgs e)
        {

            _LoadDefaultData();
            _dtAllTest = ClsTest.AllTests();

            DateTime dtSelected = DTPicker.Value.Date;
            DataTable dtFilter = _dtAllTest.Clone();

            foreach(DataRow row in _dtAllTest.Rows)
            {

                if(((DateTime)row["AppointmentDate"]).Date == dtSelected)
                {
                    dtFilter.Rows.Add(row.ItemArray);
                }
            }

            dgViewTests.DataSource = dtFilter;
            lblRecordsCount.Text = dgViewTests.Rows.Count.ToString();

            if(dgViewTests.Rows.Count > 0)
            {

                dgViewTests.Columns[0].HeaderText = "Test ID";
                dgViewTests.Columns[0].Width = 60;

                dgViewTests.Columns[1].HeaderText = "Person Full Name";
                dgViewTests.Columns[1].Width = 230;

                dgViewTests.Columns[2].HeaderText = "Class Name";
                dgViewTests.Columns[2].Width = 230;

                dgViewTests.Columns[3].HeaderText = "Test Type";
                dgViewTests.Columns[3].Width = 160;

                dgViewTests.Columns[4].HeaderText = "Test Result";
                dgViewTests.Columns[4].Width = 60;

                dgViewTests.Columns[5].HeaderText = "Appointment Date";
                dgViewTests.Columns[5].Width = 150;

                dgViewTests.Columns[6].HeaderText = "Notes";
                dgViewTests.Columns[6].Width = 100;

                dgViewTests.Columns[7].HeaderText = "Created By User";
                dgViewTests.Columns[7].Width = 90;

            }

        }
        private void frmAllTests_Shown(object sender, EventArgs e)
        {
            ClsSettingColore.ColoreForDataGritView(dgViewTests, null);
            LbTitel.Text = $"Welcom {ClsGlobal.GlobalUser.UserName} !";
            DTPicker.Value = DateTime.Now;

        }
        private void DTPicker_ValueChanged(object sender, EventArgs e)
        {
            frmAllTests_Load(null, null);

        }
    
    }
}
