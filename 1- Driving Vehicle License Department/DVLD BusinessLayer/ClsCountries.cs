using System;
using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class ClsCountries
    {
        public int ID { set; get; }
        public string CountryName { set; get; }
        public ClsCountries()
        {

            this.ID = -1;
            this.CountryName = "";
        }
        private ClsCountries(int ID, string CountryName)
        {

            this.ID = ID;
            this.CountryName = CountryName;
        }
        public static ClsCountries Find(int ID)
        {

            string CountryName = "";

            if (ClsCountriesData.GetCountryInfoByID(ID, ref CountryName))

                return new ClsCountries(ID, CountryName);
            else
                return null;

        }
        public static ClsCountries Find(string CountryName)
        {

            int ID = -1;

            if (ClsCountriesData.GetCountryInfoByName(CountryName, ref ID))

                return new ClsCountries(ID, CountryName);
            else
                return null;

        }
        public static DataTable GetAllCountries()
        {
            return ClsCountriesData.GetAllCountries();

        }

    }
}
