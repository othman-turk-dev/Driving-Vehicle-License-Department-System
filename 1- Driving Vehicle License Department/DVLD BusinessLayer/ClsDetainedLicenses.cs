using System;
using System.Data;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;

public class ClsDetainedLicenses
{

    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int DetainID { set; get; }
    public int LicenseID { set; get; }
    public DateTime DetainDate { set; get; }
    public decimal FineFees { set; get; }
    public int CreatedByUserID { set; get; }
    public ClsUser CreatedByUserInfo { set; get; }
    public bool IsReleased { set; get; }
    public DateTime ReleaseDate { set; get; }
    public int ReleasedByUserID { set; get; }
    public ClsUser ReleasedByUserInfo { set; get; }
    public int ReleaseApplicationID { set; get; }

    public ClsDetainedLicenses()
    {

        this.DetainID = -1;
        this.LicenseID = -1;
        this.DetainDate = DateTime.Now;
        this.FineFees = 0;
        this.CreatedByUserID = -1;
        this.IsReleased = false;
        this.ReleaseDate = DateTime.MaxValue;
        this.ReleasedByUserID = 0;
        this.ReleaseApplicationID = -1;

        Mode = enMode.AddNew;

    }
    public ClsDetainedLicenses(int DetainID,
        int LicenseID, DateTime DetainDate,
        decimal FineFees, int CreatedByUserID,
        bool IsReleased, DateTime ReleaseDate,
        int ReleasedByUserID, int ReleaseApplicationID)
    {

        this.DetainID = DetainID;
        this.LicenseID = LicenseID;
        this.DetainDate = DetainDate;
        this.FineFees = FineFees;
        this.CreatedByUserID = CreatedByUserID;
        this.IsReleased = IsReleased;
        this.ReleaseDate = ReleaseDate;
        this.ReleasedByUserID = ReleasedByUserID;
        this.ReleaseApplicationID = ReleaseApplicationID;

        this.CreatedByUserInfo = ClsUser.FindByUserID(this.CreatedByUserID);
        this.ReleasedByUserInfo = ClsUser.FindByPersonID(this.ReleasedByUserID);
        
        Mode = enMode.Update;

    }

    private bool _AddNewDetainedLicense()
    {

        this.DetainID = ClsDetainLicenseData.AddNewDetainedLicense(
            this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);

        return (this.DetainID != -1);

    }
    private bool _UpdateDetainedLicense()
    {

        return ClsDetainLicenseData.UpdateDetainedLicense(
            this.DetainID, this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID);
    }

    public static ClsDetainedLicenses Find(int DetainID)
    {
        int LicenseID = -1; DateTime DetainDate = DateTime.Now;
        decimal FineFees = 0; int CreatedByUserID = -1;
        bool IsReleased = false; DateTime ReleaseDate = DateTime.MaxValue;
        int ReleasedByUserID = -1; int ReleaseApplicationID = -1;

        if (ClsDetainLicenseData.GetDetainedLicenseInfoByID(DetainID,
        ref LicenseID, ref DetainDate,
        ref FineFees, ref CreatedByUserID,
        ref IsReleased, ref ReleaseDate,
        ref ReleasedByUserID, ref ReleaseApplicationID))

            return new ClsDetainedLicenses(DetainID,
                 LicenseID, DetainDate,
                 FineFees, CreatedByUserID,
                 IsReleased, ReleaseDate,
                 ReleasedByUserID, ReleaseApplicationID);
        else
            return null;

    }
    public static DataTable GetAllDetainedLicenses()
    {
        return ClsDetainLicenseData.GetAllDetainedLicenses();

    }
    public static ClsDetainedLicenses FindByLicenseID(int LicenseID)
    {

        int DetainID = -1, CreatedByUserID = -1, ReleasedByUserID = -1, ReleaseApplicationID = -1;
        DateTime ReleaseDate = DateTime.MaxValue, DetainDate = DateTime.Now;
        decimal FineFees = 0;
        bool IsReleased = false;

        if (ClsDetainLicenseData.GetDetainedLicenseInfoByLicenseID(LicenseID,
        ref DetainID, ref DetainDate,
        ref FineFees, ref CreatedByUserID,
        ref IsReleased, ref ReleaseDate,
        ref ReleasedByUserID, ref ReleaseApplicationID))

            return new ClsDetainedLicenses(DetainID,
                 LicenseID, DetainDate,
                 FineFees, CreatedByUserID,
                 IsReleased, ReleaseDate,
                 ReleasedByUserID, ReleaseApplicationID);
        else
            return null;

    }
    public bool Save()
    {

        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewDetainedLicense())
                {

                    Mode = enMode.Update;
                    return true;
                }
                else
                {
                    return false;
                }

            case enMode.Update:

                return _UpdateDetainedLicense();

        }

        return false;

    }
    public static bool IsLicenseDetained(int LicenseID)
    {
        return ClsDetainLicenseData.IsLicenseDetained(LicenseID);

    }
    public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
    {
        return ClsDetainLicenseData.ReleaseDetainedLicense(this.DetainID,
               ReleasedByUserID, ReleaseApplicationID);

    }

}


