using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class ClsDriverData
    {
        public static int AddNewDrivers(int PersonID, int CreatedByUserID)
        {

            int DriverID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"INSERT INTO Drivers
                                  (PersonID, CreatedByUserID, CreatedDate)
                            VALUES 
                                  (@PersonID, @CreatedByUserID, @CreatedDate)

                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
            
            try
            {
                connection.Open();
            
                object result = command.ExecuteScalar();
                
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    DriverID = insertedID;
                
                }
            }
            catch (Exception ex)
            {
                // Handle error
            }
            finally
            {
                connection.Close();
            }
            
            return DriverID;
        
        }
        public static bool GetDriversByDriverID(int DriverID, ref int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
           
            string query = "SELECT * FROM Drivers WHERE DriverID = @DriverID";
           
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@DriverID", DriverID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    
                    isFound = true;
                    
                    PersonID = (int)reader["PersonID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                
                }
                else
                {

                    isFound = false;
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {

                isFound = false;
            }
            finally
            {

                connection.Close();
            }

            return isFound;

        }
        public static bool GetDriversByPersonID(ref int DriverID, int PersonID, ref int CreatedByUserID, ref DateTime CreatedDate)
        {
            
            bool isFound = false;
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = "SELECT * FROM Drivers WHERE PersonID = @PersonID";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@PersonID", PersonID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
            
                if (reader.Read())
                {
                
                    isFound = true;
                    
                    DriverID = (int)reader["DriverID"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    CreatedDate = (DateTime)reader["CreatedDate"];
                
                }
                else
                {
                
                    isFound = false;
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                
                isFound = false;
            }
            finally
            {
                
                connection.Close();
            }
            
            return isFound;

        }
        public static bool UpdateDrivers(int DriverID, int PersonID, int CreatedByUserID)
        {
            
            int rowsAffected = 0;
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"UPDATE Drivers 
                            SET
                            PersonID = @PersonID,
                            CreatedByUserID = @CreatedByUserID,
                            CreatedDate = @CreatedDate
                            WHERE 
                            DriverID = @DriverID";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                connection.Open();
            
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                return false;
            }
            finally
            {
                connection.Close();
            }
            
            return rowsAffected > 0;

        }
        public static DataTable GetAllDrivers()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Drivers_View order by FullName";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

    }

}
