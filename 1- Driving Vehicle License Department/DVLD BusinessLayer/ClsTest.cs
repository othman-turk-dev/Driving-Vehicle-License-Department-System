using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsTest
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }

        public ClsTestAppointments TestAppointmentInfo;
        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }

        public ClsUser UserInfo;
        public ClsTest()
        {

            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = false;
            this.Notes = "";
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }
        private ClsTest(int TestID, int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {

            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;

            this.UserInfo = ClsUser.FindByUserID(CreatedByUserID);
            this.TestAppointmentInfo = ClsTestAppointments.FindByTestAppointmentID(TestAppointmentID);

            Mode = enMode.Update;

        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNew())
                    {
                        Mode = enMode.Update;

                        return true;
                    }
                    else return false;

                case enMode.Update:

                    return _Update();
            }

            return false;

        }
        private bool _AddNew()
        {

            this.TestID = ClsTestData.AddNewTests(this.TestAppointmentID, this.TestResult,
                this.Notes, this.CreatedByUserID);
            return this.TestID != -1;
        }
        private bool _Update()
        {

            return ClsTestData.UpdateTests(this.TestID, this.TestAppointmentID, this.TestResult,
                this.Notes, this.CreatedByUserID);
        }
        public static ClsTest FindByTestID(int TestID)
        {

            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            bool IsFound = ClsTestData.GetTestsByTestID(TestID, ref TestAppointmentID,
                    ref TestResult, ref Notes, ref CreatedByUserID);

            if (IsFound)
                return new ClsTest(TestID, TestAppointmentID,
                    TestResult, Notes, CreatedByUserID);
            else
                return null;

        }
        public static ClsTest FindLastTestPerPersonAndLicenseClass
            (int PersonID, int LicenseClassID, ClsTestType.enTestType TestTypeID)
        {

            int TestID = -1, TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = false;
            string Notes = "";

            if (ClsTestData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID))

                return new ClsTest(TestID,TestAppointmentID, TestResult, Notes, CreatedByUserID);
            else
                return null;

        }

        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {

            return ClsTestData.GetPassedTestCount(LocalDrivingLicenseApplicationID);
        }
        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            //if total passed test less than 3 it will return false otherwise will return true
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }
        public static DataTable AllTests()
        {
            return ClsTestData.GetAllTests();

        }

    }
}

