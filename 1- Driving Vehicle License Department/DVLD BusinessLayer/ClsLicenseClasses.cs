using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsLicenseClasses
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimumAllowedAge { get; set; }
        public byte DefaultValidityLength { get; set; }
        public decimal ClassFees { get; set; }
        public ClsLicenseClasses()
        {

            this.LicenseClassID = -1;
            this.ClassName = "";
            this.ClassDescription = "";
            this.MinimumAllowedAge = 18;
            this.DefaultValidityLength = 10;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }
        private ClsLicenseClasses(int LicenseClassID, string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {

            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

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
            
            this.LicenseClassID = ClsLicenseClassesData.AddNewLicenseClasses(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
            return (this.LicenseClassID != -1);
        
        }
        private bool _Update()
        {
            
            return ClsLicenseClassesData.UpdateLicenseClasses(this.LicenseClassID, this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }
        public static ClsLicenseClasses FindByLicenseClassID(int LicenseClassID)
        {

            string ClassName = "";
            string ClassDescription = "";
            byte MinimumAllowedAge = 18;
            byte DefaultValidityLength = 10;
            decimal ClassFees = 0;

            bool IsFound = ClsLicenseClassesData.GetLicenseClassesByLicenseClassID(LicenseClassID, ref ClassName,
                ref ClassDescription, ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);

            if (IsFound)
                return new ClsLicenseClasses(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public static ClsLicenseClasses FindByClassName(string ClassName)
        {

            int LicenseClassID = -1; string ClassDescription = "";
            byte MinimumAllowedAge = 18; byte DefaultValidityLength = 10; decimal ClassFees = 0;

            if (ClsLicenseClassesData.GetLicenseClassInfoByClassName(ClassName, ref LicenseClassID, ref ClassDescription,
                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees))

                return new ClsLicenseClasses(LicenseClassID, ClassName, ClassDescription,
                    MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;

        }

    }

}
