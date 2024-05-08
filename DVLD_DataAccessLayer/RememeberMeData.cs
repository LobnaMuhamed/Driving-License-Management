using System;
using System.Data.SqlClient;



namespace DVLD_DataAccessLayer
{
    public class clsRememeberMeData
    {


        public static int GetRemeberUser()
        {
            int UserID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT UserID From RememberMe";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    UserID = InsertedID;
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return UserID;
        }
        public static int AddRememberUser(int UserID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(
                clsDataAccessSettings.ConnectionString);
            string query = @"DELETE FROM RememberMe;
                             INSERT INTO RememberMe (UserID)
                             VALUES (@UserID)
                             SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                    ID = InsertedID;
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return ID;
        }

        public static bool DeleteUser()
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"DELETE FROM RememberMe";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally { connection.Close(); };
            return (rowsAffected > 0);
        }


    }
}
