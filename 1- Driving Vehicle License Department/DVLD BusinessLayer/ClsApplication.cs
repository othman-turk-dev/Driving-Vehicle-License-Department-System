using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enum enApplicationType
        {
            NewDrivingLicense = 1, RenewDrivingLicense = 2, ReplaceLostDrivingLicense = 3,
            ReplaceDamagedDrivingLicense = 4, ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 6, RetakeTest = 7
        };

        public enMode Mode = enMode.AddNew;
        public enum enApplicationStatus { New = 1, Cancelled = 2, Completed = 3 };

        public int ApplicationID { set; get; }
        public int ApplicantPersonID { set; get; }
        public string ApplicantFullName
        {
            get
            {
                return ClsPerson.Find(ApplicantPersonID).FullName;
            }
        }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }

        public ClsApplicationTypes ApplicationTypeInfo;
        public enApplicationStatus ApplicationStatus { set; get; }
        public string StatusText
        {

            get
            {

                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }

        }
        public DateTime LastStatusDate { set; get; }
        public decimal PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public ClsUser CreatedByUserInfo;

        public ClsApplication()
        {
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = -1;

            Mode = enMode.AddNew;

        }
        private ClsApplication(int ApplicationID, int ApplicantPersonID,
            DateTime ApplicationDate, int ApplicationTypeID,
             enApplicationStatus ApplicationStatus, DateTime LastStatusDate,
             decimal PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;

            this.ApplicationTypeInfo = ClsApplicationTypes.Find(ApplicationTypeID);
            this.CreatedByUserInfo = ClsUser.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {

            this.ApplicationID = ClsApplicationData.AddNewApplication(
                this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);

        }
        private bool _UpdateApplication()
        {

            return ClsApplicationData.UpdateApplication(this.ApplicationID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, (byte)this.ApplicationStatus,
                this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

        }
        public static ClsApplication FindBaseApplication(int ApplicationID)
        {

            int ApplicantPersonID = -1, CreatedByUserID = -1, ApplicationTypeID = -1;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            byte ApplicationStatus = 1;
            decimal PaidFees = 0;

            bool IsFound = ClsApplicationData.GetApplicationInfoByID
                                    (ApplicationID, ref ApplicantPersonID,
                                    ref ApplicationDate, ref ApplicationTypeID,
                                    ref ApplicationStatus, ref LastStatusDate,
                                    ref PaidFees, ref CreatedByUserID);

            if (IsFound)

                return new ClsApplication(ApplicationID, ApplicantPersonID,
                                     ApplicationDate, ApplicationTypeID,
                                    (enApplicationStatus)ApplicationStatus, LastStatusDate,
                                     PaidFees, CreatedByUserID);
            else
                return null;

        }
        public bool Cancel()
        {
            return ClsApplicationData.UpdateStatus(ApplicationID, 2);

        }
        public bool SetComplete()
        {
            return ClsApplicationData.UpdateStatus(ApplicationID, 3);

        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;

        }
        public bool Delete()
        {
            return ClsApplicationData.DeleteApplication(this.ApplicationID);

        }
        public static int GetActiveApplicationIDForLicenseClass(int PersonID, enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return ClsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }
        public static DataTable AllApplications()
        {
            return ClsApplicationData.GetAllApplication();

        }

    }

}
