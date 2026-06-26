using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsLocalDrivingLicenseApplications : ClsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public ClsLicenseClasses LicenseClassesInfo;
        public string PersonFullName
        {
            get { return ClsPerson.Find(ApplicantPersonID).FullName; }
        }
        public ClsLocalDrivingLicenseApplications()
        {

            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;

            Mode = enMode.AddNew;
        
        }
        private ClsLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID,
            int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID, int LicenseClassID)
        {

            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.LicenseClassID = LicenseClassID;

            this.LicenseClassesInfo = ClsLicenseClasses.FindByLicenseClassID(LicenseClassID);

            Mode = enMode.Update;

        }

        public bool Save()
        {

            base.Mode = (ClsApplication.enMode)Mode;

            if (!base.Save())
                return false;

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

            this.LocalDrivingLicenseApplicationID = 
                ClsLocalDrivingLicenseApplicationsData.AddNewLocalDrivingLicenseApplications(this.ApplicationID, this.LicenseClassID);
            
            return this.LocalDrivingLicenseApplicationID != -1;
        }
        private bool _Update()
        {

            return ClsLocalDrivingLicenseApplicationsData.UpdateLocalDrivingLicenseApplications
                (this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
        }
        public static ClsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationByLocalID(int LocalDrivingLicenseApplicationID)
        {

            int ApplicationID = -1, LicenseClassID = -1;

            bool IsFound = ClsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsByLocalDrivingLicenseApplicationID
                (LocalDrivingLicenseApplicationID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                ClsApplication application = ClsApplication.FindBaseApplication(ApplicationID);

                return new ClsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID, application.ApplicantPersonID,
                    application.ApplicationDate, application.ApplicationID, application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID, LicenseClassID);
            }
            else
                return null;

        }
        public static ClsLocalDrivingLicenseApplications FindByLocalDrivingLicenseApplicationByApplicationID(int ApplicationID)
        {

            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;

            bool IsFound = ClsLocalDrivingLicenseApplicationsData.GetLocalDrivingLicenseApplicationsByApplicationID(
                ref LocalDrivingLicenseApplicationID, ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                //now we find the base application
                ClsApplication application = ClsApplication.FindBaseApplication(ApplicationID);

                //we return new object of that person with the right data
                return new ClsLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID, ApplicationID,
                    application.ApplicantPersonID, application.ApplicationDate, application.ApplicationID,
                    (enApplicationStatus)application.ApplicationStatus, application.LastStatusDate,
                    application.PaidFees, application.CreatedByUserID, LicenseClassID);

            }
            else
                return null;

        }
        public static DataTable GetAllLocalDrivingLicenseApplicationss()
        {

            return ClsLocalDrivingLicenseApplicationsData.GetAllLocalDrivingLicenseApplications();
        }
        public bool Delete()
        {

            bool IsLocalDrivingApplicationDeleted = false;
            bool IsBaseApplicationDeleted = false;
            //First we delete the Local Driving License Application
            IsLocalDrivingApplicationDeleted = ClsLocalDrivingLicenseApplicationsData.DeleteLocalDrivingLicenseApplications(this.LocalDrivingLicenseApplicationID);

            if (!IsLocalDrivingApplicationDeleted)
                return false;

            //Then we delete the base Application
            IsBaseApplicationDeleted = base.Delete();
            return IsBaseApplicationDeleted;

        }
        public bool DoesPassTestType(ClsTestType.enTestType TestTypeID)
        {

            return ClsLocalDrivingLicenseApplicationsData.DoesPassTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool DoesAttendTestType(ClsTestType.enTestType TestTypeID)
        {

            return ClsLocalDrivingLicenseApplicationsData.DoesAttendTestType(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public int TotalTrialsPerTest(ClsTestType.enTestType TestTypeID)
        {

            return ClsLocalDrivingLicenseApplicationsData.TotalTrialsPerTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, ClsTestType.enTestType TestTypeID)
        {

            return ClsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public bool IsThereAnActiveScheduledTest(ClsTestType.enTestType TestTypeID)
        {

            return ClsLocalDrivingLicenseApplicationsData.IsThereAnActiveScheduledTest(this.LocalDrivingLicenseApplicationID, (int)TestTypeID);
        }
        public ClsTest GetLastTestPerTestType(ClsTestType.enTestType TestTypeID)
        {

            return ClsTest.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }
        public int GetPassedTestCount()
        {

            return ClsTest.GetPassedTestCount(this.LocalDrivingLicenseApplicationID);
        }
        public bool PassedAllTests()
        {

            return ClsTest.PassedAllTests(this.LocalDrivingLicenseApplicationID);
        }
        public int IssueLicenseForTheFirtTime(string Notes, int CreatedByUserID)
        {

            int DriverID = -1;

            ClsDriver Driver = ClsDriver.FindByPersonID(this.ApplicantPersonID);

            if (Driver == null)
            {
                //we check if the driver already there for this person.
                Driver = new ClsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreateByUserID = CreatedByUserID;

                if (Driver.Save())
                {
                    DriverID = Driver.DriverID;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                DriverID = Driver.DriverID;
            }
            //now we diver is there, so we add new licesnse

            ClsLicenses License = new ClsLicenses();
            License.ApplicationID = this.ApplicationID;
            License.DriverID = DriverID;
            License.LicenseClass = this.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = DateTime.Now.AddYears(this.LicenseClassesInfo.DefaultValidityLength);
            License.Notes = Notes;
            License.PaidFees = this.LicenseClassesInfo.ClassFees;
            License.IsActive = true;
            License.IssueReason = ClsLicenses.enIssueReason.FirstTime;
            License.CreatedByUserID = CreatedByUserID;

            if (License.Save())
            {
                //now we should set the application status to complete.
                this.SetComplete();

                return License.LicenseID;
            }

            else
                return -1;

        }
        public bool IsLicenseIssued()
        {

            return (GetActiveLicenseID() != -1);
        }
        public int GetActiveLicenseID()
        {
            //this will get the license id that belongs to this application
            return ClsLicenses.GetActiveLicenseIDByPersonID(this.ApplicantPersonID, this.LicenseClassID);
        }
        public bool IsPersonHaveAnyLicense()
        {

            return ClsLicensesData.IsPersonHaveAnyLicense(this.ApplicantPersonID);
        }

    }

}
