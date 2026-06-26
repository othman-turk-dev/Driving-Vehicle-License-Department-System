using System;
using System.Data;
using DVLD_BusinessLayer;
using DVLD_DataAccessLayer;

public class ClsTestAppointments
{

    public enum enMode { AddNew = 0, Update = 1 };
    public enMode Mode = enMode.AddNew;

    public int TestAppointmentID { get; set; }
    public ClsTestType.enTestType TestTypID { get; set; }
    public int LocalDrivingLicenseApplicationID { get; set; }
    public DateTime AppointmentDate { get; set; }
    public decimal PaidFees { get; set; }
    public int CreatedByUserID { get; set; }
    public bool IsLocked { get; set; }
    public int RetakeTestApplicationID { get; set; }

    public ClsApplication RetakeTestApplicationInfo;
    public int TestID
    {
        get { return ClsTestAppointmentData.GetTestID(TestAppointmentID); }

    }

    public ClsTestAppointments()
    {

        this.TestAppointmentID = -1;
        this.TestTypID = ClsTestType.enTestType.VisionTest;
        this.AppointmentDate = DateTime.Now;
        this.PaidFees = -1;
        this.CreatedByUserID = -1;
        this.RetakeTestApplicationID = -1;

        Mode = enMode.AddNew;
    }
    private ClsTestAppointments(int TestAppointmentID, ClsTestType.enTestType TestTypID, int LocalDrivingLicenseApplicationID,
        DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
    {

        this.TestAppointmentID = TestAppointmentID;
        this.TestTypID = TestTypID;
        this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        this.AppointmentDate = AppointmentDate;
        this.PaidFees = PaidFees;
        this.CreatedByUserID = CreatedByUserID;
        this.IsLocked = IsLocked;
        this.RetakeTestApplicationID = RetakeTestApplicationID;
        this.RetakeTestApplicationInfo = ClsApplication.FindBaseApplication(RetakeTestApplicationID);

        Mode = enMode.Update;
    }

    public static ClsTestAppointments FindByTestAppointmentID(int TestAppointmentID)
    {

        int TestTypID = 1, LocalDrivingLicenseApplicationID = -1, CreatedByUserID = -1, RetakeTestApplicationID = -1;
        DateTime AppointmentDate = DateTime.Now;
        decimal PaidFees = 0;
        bool IsLocked = false;

        bool IsFound = ClsTestAppointmentData.GetTestAppointmentsByTestAppointmentID(
            TestAppointmentID, ref TestTypID, ref LocalDrivingLicenseApplicationID, ref AppointmentDate,
            ref PaidFees, ref CreatedByUserID, ref IsLocked, ref RetakeTestApplicationID);

        if (IsFound)
            return new ClsTestAppointments(TestAppointmentID,(ClsTestType.enTestType)
                TestTypID, LocalDrivingLicenseApplicationID, AppointmentDate,
                PaidFees, CreatedByUserID, IsLocked, RetakeTestApplicationID);
        else
            return null;

    }
    public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, ClsTestType.enTestType TestTypeID)
    {

        return ClsTestAppointmentData.GetApplicationTestAppointmentsPerTestType(LocalDrivingLicenseApplicationID, (int)TestTypeID);
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

        this.TestAppointmentID = ClsTestAppointmentData.AddNewTestAppointment((int)this.TestTypID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees,
            this.CreatedByUserID, this.RetakeTestApplicationID);
        
        return this.TestAppointmentID != -1;
    }
    private bool _Update()
    {

        return ClsTestAppointmentData.UpdateTestAppointments(this.TestAppointmentID,(int) this.TestTypID,this.LocalDrivingLicenseApplicationID,
            this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked, this.RetakeTestApplicationID);
    }

}