using System;
using System.Data;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;

public class ClsLicenses
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;
    public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

    public int LicenseID { get; set; }
    public int ApplicationID { get; set; }
    public int DriverID { get; set; }

    public ClsDriver DriverInfo;
    public int LicenseClass { get; set; }

    public ClsLicenseClasses LicenseClassInfo;
    public DateTime IssueDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string Notes { get; set; }
    public decimal PaidFees { get; set; }
    public bool IsActive { get; set; }
    public enIssueReason IssueReason { get; set; }
    public string IssueReasonText
    {
        get { return GetIssueReasonText(this.IssueReason); }
    }
    public int CreatedByUserID { get; set; }
    public ClsDetainedLicenses DetainedInfo { set; get; }
    public bool IsDetained
    {
        get { return ClsDetainedLicenses.IsLicenseDetained(this.LicenseID); }
    }

    public ClsLicenses()
    {

        this.LicenseID = -1;
        this.ApplicationID = -1;
        this.DriverID = -1;
        this.LicenseClass = -1;
        this.CreatedByUserID = -1;

        this.IssueDate = DateTime.Now;
        this.ExpirationDate = DateTime.Now;

        this.Notes = "";
        this.PaidFees = 0;
        this.IsActive = true;

        this.IssueReason = enIssueReason.FirstTime;

        Mode = enMode.AddNew;

    }

    private ClsLicenses(int LicenseID, int ApplicationID, int DriverID, int LicenseClass,
        DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive,
        enIssueReason IssueReason, int CreatedByUserID)
    {

        this.LicenseID = LicenseID;
        this.ApplicationID = ApplicationID;
        this.DriverID = DriverID;
        this.LicenseClass = LicenseClass;
        this.IssueDate = IssueDate;
        this.ExpirationDate = ExpirationDate;
        this.Notes = Notes;
        this.PaidFees = PaidFees;
        this.IsActive = IsActive;
        this.IssueReason = IssueReason;
        this.CreatedByUserID = CreatedByUserID;

        this.DriverInfo = ClsDriver.FindByDriverID(DriverID);
        this.LicenseClassInfo = ClsLicenseClasses.FindByLicenseClassID(LicenseClass);
        this.DetainedInfo = ClsDetainedLicenses.FindByLicenseID(this.LicenseID);

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

        this.LicenseID = ClsLicensesData.AddNewLicenses(this.ApplicationID, this.DriverID,
            this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes,
            this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID);

        return this.LicenseID != -1;

    }
    private bool _Update()
    {

        return ClsLicensesData.UpdateLicenses(this.LicenseID, this.ApplicationID, this.DriverID, this.LicenseClass, this.IssueDate,
            this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive, (int)this.IssueReason, this.CreatedByUserID);
    }
    public static ClsLicenses FindByLicenseID(int LicenseID)
    {

        int ApplicationID = -1, DriverID = -1, LicenseClass = -1, CreatedByUserID = -1,
            IssueReason = 1;
        
        DateTime IssueDate = DateTime.Now, ExpirationDate = DateTime.Now;
        
        string Notes = "";
        decimal PaidFees = 0;
        bool IsActive = true;

        bool IsFound = ClsLicensesData.GetLicensesByLicenseID(LicenseID, ref ApplicationID,
            ref DriverID, ref LicenseClass, ref IssueDate, ref ExpirationDate, ref Notes,
            ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

        if (IsFound)
            return new ClsLicenses(LicenseID, ApplicationID, DriverID,
                LicenseClass, IssueDate, ExpirationDate, Notes,
                PaidFees, IsActive, (enIssueReason)IssueReason, CreatedByUserID);

        else
            return null;

    }
    public static bool IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
    {

        return (GetActiveLicenseIDByPersonID(PersonID, LicenseClassID) != -1);
    }
    public static int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
    {

        return ClsLicensesData.GetActiveLicenseIDByPersonID(PersonID, LicenseClassID);
    }
    public static DataTable GetDriverLicenses(int DriverID)
    {

        return ClsLicensesData.GetDriverLicenses(DriverID);
    }
    public static string GetIssueReasonText(enIssueReason IssueReason)
    {

        switch (IssueReason)
        {
            case enIssueReason.FirstTime:
                return "First Time";
            case enIssueReason.Renew:
                return "Renew";
            case enIssueReason.DamagedReplacement:
                return "Replacement for Damaged";
            case enIssueReason.LostReplacement:
                return "Replacement for Lost";
            default:
                return "First Time";
        }

    }
    public bool DeactivateCurrentLicense()
    {

        return (ClsLicensesData.DeactivateLicense(this.LicenseID));
    }
    public bool IsLicenseExpired()
    {

        return (this.ExpirationDate < DateTime.Now);
    }
    public ClsLicenses RenewLicense(string Notes, int CreatedByUserID)
    {

        //First Create Applicaiton 
        ClsApplication Application = new ClsApplication();

        Application.ApplicantPersonID = this.DriverInfo.PersonID;
        Application.ApplicationDate = DateTime.Now;
        Application.ApplicationTypeID = (int)ClsApplication.enApplicationType.RenewDrivingLicense;
        Application.ApplicationStatus = ClsApplication.enApplicationStatus.New;
        Application.LastStatusDate = DateTime.Now;
        Application.PaidFees = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.RenewDrivingLicense).ApplicationTypeFees;
        Application.CreatedByUserID = CreatedByUserID;

        if (!Application.Save())
        {

            return null;
        }

        ClsLicenses NewLicense = new ClsLicenses();

        NewLicense.ApplicationID = Application.ApplicationID;
        NewLicense.DriverID = this.DriverID;
        NewLicense.LicenseClass = this.LicenseClass;
        NewLicense.IssueDate = DateTime.Now;

        int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

        NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
        NewLicense.Notes = Notes;
        NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
        NewLicense.IsActive = true;
        NewLicense.IssueReason = ClsLicenses.enIssueReason.Renew;
        NewLicense.CreatedByUserID = CreatedByUserID;


        if (!NewLicense.Save())
        {

            return null;
        }

        Application.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
        Application.Save();

        //we need to deactivate the old License.
        DeactivateCurrentLicense();

        return NewLicense;

    }
    public ClsLicenses ReplacementLicense(bool DamagedIsCheck, int CreatedByUserID)
    {

        //First Create Applicaiton 
        ClsApplication Application = new ClsApplication();

        Application.ApplicantPersonID = this.DriverInfo.PersonID;
        Application.ApplicationDate = DateTime.Now;

        if(DamagedIsCheck)
            Application.ApplicationTypeID = (int)ClsApplication.enApplicationType.ReplaceDamagedDrivingLicense;
        else
            Application.ApplicationTypeID = (int)ClsApplication.enApplicationType.ReplaceLostDrivingLicense;

        Application.PaidFees = ClsApplicationTypes.Find(Application.ApplicationTypeID).ApplicationTypeFees;
        Application.ApplicationStatus = ClsApplication.enApplicationStatus.New;
        Application.LastStatusDate = DateTime.Now;
        Application.CreatedByUserID = CreatedByUserID;

        if (!Application.Save())
        {

            return null;
        }

        ClsLicenses NewLicense = new ClsLicenses();

        NewLicense.ApplicationID = Application.ApplicationID;
        NewLicense.DriverID = this.DriverID;
        NewLicense.LicenseClass = this.LicenseClass;
        NewLicense.IssueDate = DateTime.Now;

        int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

        NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
        NewLicense.Notes = Notes;
        NewLicense.PaidFees = 0; // no fees for the license because it's a replacement.
        NewLicense.IsActive = true;

        if(DamagedIsCheck) 
            NewLicense.IssueReason = ClsLicenses.enIssueReason.DamagedReplacement;
        else
            NewLicense.IssueReason = ClsLicenses.enIssueReason.LostReplacement;

        NewLicense.CreatedByUserID = CreatedByUserID;


        if (!NewLicense.Save())
        {

            return null;
        }

        Application.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
        Application.Save();

        //we need to deactivate the old License.
        DeactivateCurrentLicense();

        return NewLicense;

    }
    public ClsDetainedLicenses Detain(decimal FineFees, int CreatedByUserID)
    {

        ClsDetainedLicenses clsDetained = new ClsDetainedLicenses();
        clsDetained.LicenseID = this.LicenseID;
        clsDetained.DetainDate = DateTime.Now;
        clsDetained.FineFees = FineFees;
        clsDetained.CreatedByUserID = CreatedByUserID;

        if(!clsDetained.Save())
        {

            return null;
        }

        return clsDetained;

    }
    public bool ReleaseDetainedLicense(int ReleasedByUserID, ref int ApplicationID)
    {

        //First Create Applicaiton 
        ClsApplication Application = new ClsApplication();

        Application.ApplicantPersonID = this.DriverInfo.PersonID;
        Application.ApplicationDate = DateTime.Now;
        Application.ApplicationTypeID = (int)ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
        Application.ApplicationStatus = ClsApplication.enApplicationStatus.New;
        Application.LastStatusDate = DateTime.Now;
        Application.PaidFees = ClsApplicationTypes.Find((int)ClsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).ApplicationTypeFees;
        Application.CreatedByUserID = ReleasedByUserID;

        if (!Application.Save())
        {

            ApplicationID = -1;
            return false;
        }

        Application.ApplicationStatus = ClsApplication.enApplicationStatus.Completed;
        Application.Save();

        ApplicationID = Application.ApplicationID;


        return this.DetainedInfo.ReleaseDetainedLicense(ReleasedByUserID, Application.ApplicationID);

    }

}