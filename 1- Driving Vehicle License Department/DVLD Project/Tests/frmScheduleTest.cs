using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;

namespace DVLD_Project.Tests
{
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1, _TestAppointmentID = -1;
        private ClsTestType.enTestType _TestTypeID = ClsTestType.enTestType.VisionTest;
        public frmScheduleTest(int LocalDrivingLicenseApplicationID, ClsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;

        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {

            ctrScheduleTest1.TestTypeID = _TestTypeID;
            ctrScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _TestAppointmentID);
        }
        private void BtnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        
    }
}
