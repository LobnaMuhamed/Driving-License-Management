using DVLD_DataAccessLayer;
using System;
using System.Data;
namespace DVLD_BusinessLayer
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public clsPerson()
        {
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.DateOfBirth = new DateTime(2000, 1, 1);
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.NationalityCountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;
        }

        clsPerson(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, byte Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            return (PersonID != -1);
        }

        public bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.NationalNo, this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }

        public static clsPerson Find(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "",
                ImagePath = "";
            byte Gendor = 0;
            DateTime DateOfBirth = new DateTime(2000, 1, 1);
            int NationalityCountryID = -1;
            bool isFound = clsPersonData.GetPersonByPersonID(PersonID, ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);
            if (isFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
                return null;
        }

        public static clsPerson Find(string NationalNo)
        {
            int PersonID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "", Address = "", Phone = "", Email = "",
                ImagePath = "";
            byte Gendor = 0;
            DateTime DateOfBirth = new DateTime(2000, 1, 1);
            int NationalityCountryID = -1;
            bool isFound = clsPersonData.GetPersonByNationalNo(ref PersonID, NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath);
            if (isFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            }
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
                        return false;
                case enMode.Update:
                    return _UpdatePerson();
                default:
                    return false;
            }
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }

        public static DataTable GetPersonByPersonID(int PersonID)
        {
            return clsPersonData.GetPersonByPersonID(PersonID);
        }
        public static DataTable GetPersonByNationalNo(string NationalNo)
        {
            return clsPersonData.GetPersonByNationalNo(NationalNo);
        }

        public static DataTable GetPersonByFirstName(string FirstName)
        {
            return clsPersonData.GetPersonByFirstName(FirstName);
        }

        public static DataTable GetPersonBySecondName(string SecondName)
        {
            return clsPersonData.GetPersonBySecondName(SecondName);
        }

        public static DataTable GetPersonByThirdName(string ThirdName)
        {
            return clsPersonData.GetPersonByThirdName(ThirdName);
        }

        public static DataTable GetPersonByLastName(string LastName)
        {
            return clsPersonData.GetPersonByLastName(LastName);
        }

        public static DataTable GetPersonByEmail(string Email)
        {
            return clsPersonData.GetPersonByEmail(Email);
        }

        public static DataTable GetPersonByPhone(string Phone)
        {
            return clsPersonData.GetPersonByPhone(Phone);
        }

        public static DataTable GetPersonByGendor(byte Gendor)
        {
            return clsPersonData.GetPersonByGendor(Gendor);
        }
        public static DataTable GetPersonByCountryName(string CountryName)
        {
            return clsPersonData.GetPersonByCountryName(CountryName);
        }
        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }



    }
}
