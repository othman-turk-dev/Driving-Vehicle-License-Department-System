using System;
using System.Windows.Forms;
using DVLD_BusinessLayer;
using DVLD_Project.Properties;

namespace DVLD_Project.Tests.Controls
{
    public partial class ctrScheduledTest : UserControl
    {
        public ctrScheduledTest()
        {
            InitializeComponent();
        }

        private ClsTestType.enTestType _TestTypeID;
        private int _TestID = -1;

        private ClsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        public ClsTestType.enTestType TestTypeID
        {

            get
            {
                return _TestTypeID;
            }
            set
            {

                _TestTypeID = value;

                switch (_TestTypeID)
                {

                    case ClsTestType.enTestType.VisionTest:
                        {
                            PicImage.Image = Resources.eye_recognition;
                            break;
                        }
                    case ClsTestType.enTestType.WrittenTest:
                        {
                            PicImage.Image = Resources.examination;
                            break;
                        }
                    case ClsTestType.enTestType.StreetTest:
                        {
                            PicImage.Image = Resources.roundabout;
                            break;

                        }
                }
            }

        }
        public int TestAppointmentID
        {
            get
            {
                return _TestAppointmentID;
            }
        }
        public int TestID
        {

            get { return _TestID; }
        }

        private int _TestAppointmentID = -1;
        private int _LocalDrivingLicenseApplicationID = -1;
        private ClsTestAppointments _TestAppointment;
        public void LoadInfo(int TestAppointmentID)
        {

            _TestAppointmentID = TestAppointmentID;

            _TestAppointment = ClsTestAppointments.FindByTestAppointmentID(_TestAppointmentID);

            //incase we did not find any appointment .
            if (_TestAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                _TestAppointmentID = -1;
                return;
            }

            _TestID = _TestAppointment.TestID;

            _LocalDrivingLicenseApplicationID = _TestAppointment.LocalDrivingLicenseApplicationID;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            LbDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LbDClass.Text = _LocalDrivingLicenseApplication.LicenseClassesInfo.ClassName;
            LbName.Text = _LocalDrivingLicenseApplication.PersonFullName;


            //this will show the trials for this test before 
            LbTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            LbDate.Text = _TestAppointment.AppointmentDate.ToShortDateString();
            LbFees.Text = _TestAppointment.PaidFees.ToString();
            LbTestID.Text = (_TestAppointment.TestID == -1) ? "Not Taken Yet" : _TestAppointment.TestID.ToString();

        }

    }
}
