using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsTestType
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }

        public ClsTestType()
        {

            TestTypeID = enTestType.VisionTest;
            TestTypeTitle = "";
            TestTypeDescription = "";
            TestTypeFees = 0;

        }
        private ClsTestType(enTestType TestTypeID, string TestTypeTitle,
            string TestTypeDescription, decimal TestTypeFees)
        {

            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

        }
        public bool UpdateTestType()
        {

            return ClsTestTypeData.UpdateTestTypes((int)this.TestTypeID,
                this.TestTypeTitle, this.TestTypeDescription,
                this.TestTypeFees);
        }
        public static DataTable GetAllTestTypes()
        {

            return ClsTestTypeData.GetAllTestTypes();
        }
        public static ClsTestType Find(enTestType TestTypeID)
        {

            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;

            bool IsFound = ClsTestTypeData.GetTestTypes((int)TestTypeID, ref TestTypeTitle, ref TestTypeDescription,
                ref TestTypeFees);

            if (IsFound)
                return new ClsTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
            else
                return null;

        }

    }

}
