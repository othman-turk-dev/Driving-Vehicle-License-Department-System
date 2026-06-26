using System;
using DVLD_BusinessLayer;
using System.Windows.Forms;
using DVLD_Project.Properties;
using DVLD_Project.General_Tools;

namespace DVLD_Project.Tests.Controls
{
    public partial class ctrScheduleTest : UserControl
    {
        public ctrScheduleTest()
        {
            InitializeComponent();
        }

        public enum enMode { AddNew = 0 ,Update = 1 };
        private enMode _Mode = enMode.AddNew;

        public enum enCreateMode { FirstTime = 0, RetakeTest = 1 };
        private enCreateMode _CreateMode = enCreateMode.FirstTime;

        ClsTestType.enTestType _TestTypeID = ClsTestType.enTestType.VisionTest;
        
        private ClsLocalDrivingLicenseApplications _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;

        private ClsTestAppointments _TestAppointments;
        int _TestAppointmentID = -1;

        public ClsTestType.enTestType TestTypeID
        {

            get { return _TestTypeID; }

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
        private bool _HandleActiveTestAppointmentConstraint()
        {

            if (_Mode == enMode.AddNew && ClsLocalDrivingLicenseApplications.
                IsThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, _TestTypeID))
            {

                LbErroreMessage.Text = "Person Already have an active appointment for this test";
                TxtDateTime.Enabled = false;
                BtnSave.Enabled = false;

                return false;
            }

            return true;

        }
        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestAppointments.IsLocked)
            {
                LbErroreMessage.Visible = true;
                LbErroreMessage.Text = "Person already sat for the test, appointment loacked.";
                TxtDateTime.Enabled = false;
                BtnSave.Enabled = false;
                return false;

            }
            else
                LbErroreMessage.Visible = false;

            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            //we need to make sure that this person passed the prvious required test before apply to the new test.
            //person cannno apply for written test unless s/he passes the vision test.
            //person cannot apply for street test unless s/he passes the written test.

            switch (TestTypeID)
            {
                case ClsTestType.enTestType.VisionTest:
                    //in this case no required prvious test to pass.
                    LbErroreMessage.Visible = false;

                    return true;

                case ClsTestType.enTestType.WrittenTest:
                    //Written Test, you cannot sechdule it before person passes the vision test.
                    //we check if pass visiontest 1.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(ClsTestType.enTestType.VisionTest))
                    {
                        LbErroreMessage.Visible = true;
                        LbErroreMessage.Text = "Cannot Sechule, Vision Test should be passed first";
                        TxtDateTime.Enabled = false;
                        BtnSave.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LbErroreMessage.Visible = false;
                        TxtDateTime.Enabled = true;
                        BtnSave.Enabled = true;
                    }


                    return true;

                case ClsTestType.enTestType.StreetTest:

                    //Street Test, you cannot sechdule it before person passes the written test.
                    //we check if pass Written 2.
                    if (!_LocalDrivingLicenseApplication.DoesPassTestType(ClsTestType.enTestType.WrittenTest))
                    {
                        LbErroreMessage.Text = "Cannot Sechule, Written Test should be passed first";
                        LbErroreMessage.Visible = true;
                        TxtDateTime.Enabled = false;
                        BtnSave.Enabled = false;
                        return false;
                    }
                    else
                    {
                        LbErroreMessage.Visible = false;
                        TxtDateTime.Enabled = true;
                        BtnSave.Enabled = true;
                    }


                    return true;

            }
            return true;

        }
        private bool _LoadTestAppointmentData()
        {

            _TestAppointments = ClsTestAppointments.FindByTestAppointmentID(_TestAppointmentID);

            if (_TestAppointments == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestAppointmentID.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                BtnSave.Enabled = false;
                return false;
            }

            LbFees.Text = _TestAppointments.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestAppointments.AppointmentDate) < 0)
                TxtDateTime.MinDate = DateTime.Now;
            else
                TxtDateTime.MinDate = _TestAppointments.AppointmentDate;

            TxtDateTime.Value = _TestAppointments.AppointmentDate;

            if (_TestAppointments.RetakeTestApplicationID == -1)
            {
                LbRTestAppID.Text = "N/A";
                LbRAppFees.Text = "0";
            }
            else
            {
                GbRetakeTest.Enabled = true;
                LbRTestAppID.Text = _TestAppointments.RetakeTestApplicationID.ToString();
                LbTitle.Text = "Schedule Retake Test";
                LbRAppFees.Text = _TestAppointments.RetakeTestApplicationInfo.PaidFees.ToString();

            }

            return true;

        }
        private bool _HandleRetakeApplication()
        {
            //this will decide to create a seperate application for retake test or not.
            // and will create it if needed , then it will linkit to the appoinment.
            if (_Mode == enMode.AddNew && _CreateMode == enCreateMode.RetakeTest)
            {
                //incase the mode is add new and creation mode is retake test we should create a seperate application for it.
                //then we linke it with the appointment.

                //First Create Applicaiton 
                ClsApplication Application = new ClsApplication();

                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)ClsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
                Application.LastStatusDate = DateTime.Now;
                Application.PaidFees = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.RetakeTest).ApplicationTypeFees;
                Application.CreatedByUserID = ClsGlobal.GlobalUser.UserID;

                if (!Application.Save())
                {
                    _TestAppointments.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return false;
                }

                _TestAppointments.RetakeTestApplicationID = Application.ApplicationID;
                LbRTestAppID.Text = _TestAppointments.RetakeTestApplicationID.ToString();
            }

            return true;

        }
        public  void LoadInfo(int LocalDrivingLicenseApplicationID,int TestAppointmentID)
        {

            if (TestAppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;

            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestAppointmentID = TestAppointmentID;
            _LocalDrivingLicenseApplication = ClsLocalDrivingLicenseApplications.FindByLocalDrivingLicenseApplicationByLocalID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                BtnSave.Enabled = false;
                return;
            }

            //decide if the createion mode is retake test or not based if the person attended this test before
            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
                _CreateMode = enCreateMode.RetakeTest;
            else
                _CreateMode = enCreateMode.FirstTime;


            if (_CreateMode == enCreateMode.RetakeTest)
            {
                GbRetakeTest.Enabled = true;
                LbRTestAppID.Text = "0";
                LbTitle.Text = "Schedule Retake Test";
                LbRAppFees.Text = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.RetakeTest).ApplicationTypeFees.ToString();
            }
            else
            {
                LbRTestAppID.Text = "N/A";
                LbRAppFees.Text = "0";
                LbTitle.Text = "Schedule Test";
                GbRetakeTest.Enabled = false;
            }

            LbDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            LbDClass.Text = _LocalDrivingLicenseApplication.LicenseClassesInfo.ClassName;
            LbName.Text = _LocalDrivingLicenseApplication.PersonFullName;

            LbTrial.Text = _LocalDrivingLicenseApplication.TotalTrialsPerTest(_TestTypeID).ToString();

            if(_Mode == enMode.Update)
            {
                if (!_LoadTestAppointmentData()) 
                    return;
            }
            else
            {

                TxtDateTime.MinDate = DateTime.Now;
                LbFees.Text = ClsTestType.Find(_TestTypeID).TestTypeFees.ToString();
                LbRTestAppID.Text = "N/A";

                _TestAppointments = new ClsTestAppointments();

            }

            LbTotalFees.Text = (Convert.ToDecimal(LbFees.Text) + Convert.ToDecimal(LbRAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;

            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;

        }
        private void BtnSave_Click(object sender, EventArgs e)
        {

            if (!_HandleRetakeApplication())
                return;

            _TestAppointments.TestTypID = _TestTypeID;
            _TestAppointments.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestAppointments.AppointmentDate = TxtDateTime.Value;
            _TestAppointments.PaidFees = Convert.ToDecimal(LbFees.Text);
            _TestAppointments.CreatedByUserID = ClsGlobal.GlobalUser.UserID;

            if (_TestAppointments.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

    }
}
