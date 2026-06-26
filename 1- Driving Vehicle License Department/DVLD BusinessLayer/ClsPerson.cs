using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { set; get; }
        public string FirstName { set; get; }
        public string SecondName { set; get; }
        public string ThirdName { set; get; }
        public string LastName { set; get; }
        public string FullName 
        { 
            get { return FirstName + " " + SecondName + " " + ((ThirdName != "") ? ThirdName + " " + LastName : LastName); } 

        }
        public string NationalNo { set; get; }
        public DateTime DateOfBirth { set; get; }
        public short Gendor { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public int NationalityCountryID { set; get; }

        public ClsCountries CountryInfo;
        public string ImagePath { set; get; }

        public ClsPerson()
        {

            this.PersonID = -1;
            this.NationalityCountryID = -1;

            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.ImagePath = "";

            this.DateOfBirth = DateTime.Now;

            Mode = enMode.AddNew;
        }
        private ClsPerson(int PersonID, string FirstName, string SecondName, string ThirdName,
            string LastName, string NationalNo, DateTime DateOfBirth, short Gendor,
             string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)

        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.NationalNo = NationalNo;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            this.CountryInfo = ClsCountries.Find(NationalityCountryID);
            
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {

            this.PersonID = ClsPersonData.AddNewPerson(
                this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo,
                this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,
                this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);

        }
        private bool _UpdatePerson()
        {

            return ClsPersonData.UpdatePerson(
                this.PersonID, this.FirstName, this.SecondName, this.ThirdName,
                this.LastName, this.NationalNo, this.DateOfBirth, this.Gendor,
                this.Address, this.Phone, this.Email,
                  this.NationalityCountryID, this.ImagePath);

        }
        public static ClsPerson Find(int PersonID)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", NationalNo = "",
                Email = "", Phone = "", Address = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;
            int NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = ClsPersonData.GetPersonInfoByID
                                    (PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                //we return new object of that person with the right data
                return new ClsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone,
                          Email, NationalityCountryID, ImagePath);
            else
                return null;

        }
        public static ClsPerson Find(string NationalNo)
        {

            string FirstName = "", SecondName = "", ThirdName = "", LastName = "",
                Email = "", Phone = "", Address = "", ImagePath = "";

            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1, NationalityCountryID = -1;
            short Gendor = 0;

            bool IsFound = ClsPersonData.GetPersonInfoByNationalNo
                                    (NationalNo, ref PersonID, ref FirstName, ref SecondName,
                                    ref ThirdName, ref LastName, ref DateOfBirth,
                                    ref Gendor, ref Address, ref Phone, ref Email,
                                    ref NationalityCountryID, ref ImagePath);

            if (IsFound)
                //we return new object of that person with the right data
                return new ClsPerson(PersonID, FirstName, SecondName, ThirdName, LastName,
                          NationalNo, DateOfBirth, Gendor, Address, Phone,
                          Email, NationalityCountryID, ImagePath);
            else
                return null;

        }
        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdatePerson();

            }

            return false;

        }
        public static DataTable GetAllPeople()
        {
            return ClsPersonData.GetAllPeople();

        }
        public static bool DeletePerson(int PersonID)
        {
            return ClsPersonData.DeletePerson(PersonID);

        }
        public static bool isPersonExist(int PersonID)
        {
            return ClsPersonData.IsPersonExist(PersonID);

        }
        public static bool isPersonExist(string NationlNo)
        {
            return ClsPersonData.IsPersonExist(NationlNo);

        }

    }

}
