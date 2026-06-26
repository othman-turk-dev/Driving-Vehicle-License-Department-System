using DVLD_BusinessLayer;
using DVLD_Project.General_Tools;
using DVLD_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmListTestAppointments : Form
    {
        private DataTable _dtLicenseTestAppointments;

        private int _LocalDrivingLicenseApplicationID;
        private ClsTestType.enTestType _TestType = ClsTestType.enTestType.VisionTest;

        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, ClsTestType.enTestType TestType)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestType = TestType;
        }
        private void _SetupImage()
        {

            switch (_TestType)
            {

                case ClsTestType.enTestType.VisionTest:
                    {
                        LbTitle.Text = "Vision Test Appointments";
                        this.Text = "Vision Test Appointments";
                        PicBoxTestType.Image = Resources.eye_recognition;
                        break;
                    }

                case ClsTestType.enTestType.WrittenTest:
                    {
                        LbTitle.Text = "Written Test Appointments";
                        this.Text = "Written Test Appointments";
                        PicBoxTestType.Image = Resources.examination;
                        break;
                    }
                case ClsTestType.enTestType.StreetTest:
                    {
                        LbTitle.Text = "Street Test Appointments";
                        this.Text = "Street Test Appointments";
                        PicBoxTestType.Image = Resources.roundabout;
                        break;
                    }
            }

        }
        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {

            _SetupImage();

            ctrDrivingLicenseApplicationInfo1.LoadDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);
            _dtLicenseTestAppointments = ClsTestAppointments.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestType);

            DGVForTestAppointments.DataSource = _dtLicenseTestAppointments;
            lblRecordsCount.Text = DGVForTestAppointments.Rows.Count.ToString();

            if (DGVForTestAppointments.Rows.Count > 0)
            {
                DGVForTestAppointments.Columns[0].HeaderText = "Appointment ID";
                DGVForTestAppointments.Columns[0].Width = 130;

                DGVForTestAppointments.Columns[1].HeaderText = "Appointment Date";
                DGVForTestAppointments.Columns[1].Width = 210;

                DGVForTestAppointments.Columns[2].HeaderText = "Paid Fees";
                DGVForTestAppointments.Columns[2].Width = 100;

                DGVForTestAppointments.Columns[3].HeaderText = "Is Locked";
                DGVForTestAppointments.Columns[3].Width = 100;
            }


        }
        private void btnAddTestAppointment_Click(object sender, EventArgs e)
        {

            ClsLocalDrivingLicenseApplications LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(_LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ClsTest LastTest = LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                Form form = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType);
                form.ShowDialog();

                frmListTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Form frm = new frmScheduleTest(LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm.ShowDialog();

            frmListTestAppointments_Load(null, null);

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)DGVForTestAppointments.CurrentRow.Cells[0].Value;

            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestType, TestAppointmentID);
            frm.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }
        private void TakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = (int)DGVForTestAppointments.CurrentRow.Cells[0].Value;
            Form form = new frmTakeTest(TestAppointmentID, _TestType);
            form.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }
        private void frmListTestAppointments_Shown(object sender, EventArgs e)
        {

            ClsSettingColore.ColoreForDataGritView(DGVForTestAppointments, CMStripForTestAppointment);
        }

    }
}
