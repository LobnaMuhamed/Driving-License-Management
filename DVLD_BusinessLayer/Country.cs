using System.Data;
using DVLD_DataAccessLayer;

namespace DVLD_BusinessLayer
{
    public class clsCountry
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }

        clsCountry(int CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;
        }
        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }


        public static clsCountry Find(int ID)
        {

            string CountryName = "";

            if (clsCountryDataAccess.GetCountryByID(ID, ref CountryName))
            {

                return (new clsCountry(ID, CountryName));
            }
            else
                return null;

        }
        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;

            if (clsCountryDataAccess.GetCountryByName(ref CountryID, CountryName))
            {

                return (new clsCountry(CountryID, CountryName));
            }
            else
                return null;

        }

    }
}
