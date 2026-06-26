using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsApplicationTypes
    {
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal ApplicationTypeFees { get; set; }

        public ClsApplicationTypes()
        {

            ApplicationTypeID = -1;
            ApplicationTypeFees = 0;
            ApplicationTypeTitle = "";

        }
        private ClsApplicationTypes(int ApplicationTypeID, string ApplicationTypeTitle,
            decimal ApplicationTypeFees)
        {

            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;

        }
        public bool UpdateApplicationType()
        {

            return ClsApplicationTypesData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle,
                this.ApplicationTypeFees);
        }
        public static DataTable GetAllApplicationTypes()
        {

            return ClsApplicationTypesData.GetAllApplicationTypes();
        }
        public static ClsApplicationTypes Find(int ApplicationTypeID)
        {

            string ApplicationTypeTitle = "";
            decimal ApplicationTypeFees = 0;

            bool IsFound = ClsApplicationTypesData.GetApplicationType(ApplicationTypeID, ref ApplicationTypeTitle,
                ref ApplicationTypeFees);

            if (IsFound)
                return new ClsApplicationTypes(ApplicationTypeID, ApplicationTypeTitle,
                    ApplicationTypeFees);
            else
                return null;

        }

    }

}
