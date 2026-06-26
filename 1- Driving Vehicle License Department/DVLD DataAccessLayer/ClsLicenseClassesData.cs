using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class ClsLicenseClassesData
    {
        public static int AddNewLicenseClasses(string ClassName, string ClassDescription,
            byte MinimumAllowedAge, byte DefaultValidityLength, decimal ClassFees)
        {

            int LicenseClassID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO LicenseClasses 

                            (ClassName, ClassDescription,
                            MinimumAllowedAge, DefaultValidityLength,
                            ClassFees)
                            VALUES 
                            (@ClassName, @ClassDescription,
                            @MinimumAllowedAge, @DefaultValidityLength,
                            @ClassFees);

                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LicenseClassID = insertedID;
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

            return LicenseClassID;

        }
        public static bool GetLicenseClassesByLicenseClassID(int LicenseClassID, ref string ClassName,
            ref string ClassDescription, ref byte MinimumAllowedAge,
            ref byte DefaultValidityLength, ref decimal ClassFees)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    
                    isFound = true;
                    
                    ClassName = (string)reader["ClassName"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];
               
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

        public static bool GetLicenseClassInfoByClassName(string ClassName, ref int LicenseClassID,
            ref string ClassDescription, ref byte MinimumAllowedAge,
           ref byte DefaultValidityLength, ref decimal ClassFees)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM LicenseClasses WHERE ClassName = @ClassName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClassName", ClassName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;

                    LicenseClassID = (int)reader["LicenseClassID"];
                    ClassDescription = (string)reader["ClassDescription"];
                    MinimumAllowedAge = (byte)reader["MinimumAllowedAge"];
                    DefaultValidityLength = (byte)reader["DefaultValidityLength"];
                    ClassFees = (decimal)reader["ClassFees"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;

        }

        public static bool UpdateLicenseClasses(int LicenseClassID, string ClassName,
            string ClassDescription, byte MinimumAllowedAge,
            byte DefaultValidityLength, decimal ClassFees)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"UPDATE LicenseClasses 
                            SET
                            ClassName = @ClassName,
                            ClassDescription = @ClassDescription,
                            MinimumAllowedAge = @MinimumAllowedAge,
                            DefaultValidityLength = @DefaultValidityLength,
                            ClassFees = @ClassFees
                            WHERE
                            LicenseClassID = @LicenseClassID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            command.Parameters.AddWithValue("@ClassName", ClassName);
            command.Parameters.AddWithValue("@ClassDescription", ClassDescription);
            command.Parameters.AddWithValue("@MinimumAllowedAge", MinimumAllowedAge);
            command.Parameters.AddWithValue("@DefaultValidityLength", DefaultValidityLength);
            command.Parameters.AddWithValue("@ClassFees", ClassFees);
            
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

    }

}
