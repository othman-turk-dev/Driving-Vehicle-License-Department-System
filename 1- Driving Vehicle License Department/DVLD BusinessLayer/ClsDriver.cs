using System;
using System.Data;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;

public class ClsDriver
{
    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int DriverID { get; set; }
    public int PersonID { get; set; }

    public ClsPerson PersonInfo;
    public int CreateByUserID { get; set; }
    public DateTime CreatedDate { get; set; }

    public ClsDriver()
    {

        this.DriverID = -1;
        this.PersonID = -1;
        this.CreateByUserID = -1;
        this.CreatedDate = DateTime.Now;

        Mode = enMode.AddNew;
    }
    private ClsDriver(int DriverID, int PersonID, int CreateByUserID, DateTime CreatedDate)
    {

        this.DriverID = DriverID;
        this.PersonID = PersonID;
        this.CreateByUserID = CreateByUserID;
        this.CreatedDate = CreatedDate;

        this.PersonInfo = ClsPerson.Find(PersonID);

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

        this.DriverID = ClsDriverData.AddNewDrivers(this.PersonID, this.CreateByUserID);
        return this.DriverID != -1;

    }
    private bool _Update()
    {

        return ClsDriverData.UpdateDrivers(this.DriverID, this.PersonID,
            this.CreateByUserID);
    }
    public static ClsDriver FindByDriverID(int DriverID)
    {

        int PersonID = -1, CreateByUserID = -1;
        DateTime CreatedDate = DateTime.Now;

        bool IsFound = ClsDriverData.GetDriversByDriverID(DriverID, ref PersonID,
            ref CreateByUserID, ref CreatedDate);

        if (IsFound)
            return new ClsDriver(DriverID, PersonID,
                CreateByUserID, CreatedDate);
        else
            return null;

    }
    public static ClsDriver FindByPersonID(int PersonID)
    {
        int DriverID = -1, CreateByUserID = -1;
        DateTime CreatedDate = DateTime.Now;

        bool IsFound = ClsDriverData.GetDriversByPersonID(ref DriverID, PersonID,
            ref CreateByUserID, ref CreatedDate);

        if (IsFound)
            return new ClsDriver(DriverID, PersonID,
                CreateByUserID, CreatedDate);
        else
            return null;

    }
    public static DataTable GetAllDrivers()
    {

        return ClsDriverData.GetAllDrivers();
    }
    public static DataTable GetLicenses(int DriverID)
    {

        return ClsLicenses.GetDriverLicenses(DriverID);
    }
    public static DataTable GetInternationalLicenses(int DriverID)
    {

        return ClsInternationalLicense.GetDriverInternationalLicenses(DriverID);
    }

}
