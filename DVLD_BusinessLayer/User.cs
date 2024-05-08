using DVLD_DataAccessLayer;
using System;
using System.Data;

namespace DVLD_BusinessLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.IsActive = false;
            Mode = enMode.AddNew;
        }

        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(PersonID, UserName, Password, IsActive);
            return (UserID != -1);
        }

        public bool _UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
        }

        public static clsUser Find(string UserName, string Password)
        {
            int PersonID = -1, UserID = -1;
            bool IsActive = false;

            bool isFound = clsUserData.GetUserByUserNameAndPassword(ref UserID, ref PersonID, UserName, Password, ref IsActive);
            if (isFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser Find(int UserID)
        {
            string UserName = "", Password = "";
            int PersonID = -1;
            bool IsActive = false;

            bool isFound = clsUserData.GetUserByUserID(UserID, ref PersonID, ref UserName, ref Password, ref IsActive);
            if (isFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public static clsUser FindByPersonID(int PersonID)
        {
            string UserName = "", Password = "";
            int UserID = -1;
            bool IsActive = false;

            bool isFound = clsUserData.GetUserByPersonID(ref UserID, PersonID, ref UserName, ref Password, ref IsActive);
            if (isFound)
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateUser();
                default:
                    return false;
            }
        }


        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }


        public static DataTable GetUserByPersonID(int PersonID)
        {
            return clsUserData.GetUserByPersonID(PersonID);
        }

        public static DataTable GetUserByUserID(int UserID)
        {
            return clsUserData.GetUserByUserID(UserID);
        }

        public static DataTable GetUserByUserName(string UserName)
        {
            return clsUserData.GetUserByUserName(UserName);
        }
        public static DataTable GetUserIsActive()
        {
            return clsUserData.GetUserIsActive();
        }

        public static DataTable GetUserIsNotActive()
        {
            return clsUserData.GetUserIsNotActive();
        }
        public static bool AddUserToRememberMeLog(int UserID)
        {
            return (clsRememeberMeData.AddRememberUser(UserID) != -1);
        }

        static public int GetRememberUser()
        {
            return clsRememeberMeData.GetRemeberUser();
        }
        static public bool DeleteRememberUser()
        {
            return clsRememeberMeData.DeleteUser();
        }

        static public bool IsUserExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
    }
}
