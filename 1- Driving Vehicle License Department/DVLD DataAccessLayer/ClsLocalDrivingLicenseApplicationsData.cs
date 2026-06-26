using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class ClsLocalDrivingLicenseApplicationsData
    {
        public static int AddNewLocalDrivingLicenseApplications(int ApplicationID, int LicenseClassID)
        {

            int LocalDrivingLicenseApplicationID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"INSERT INTO LocalDrivingLicenseApplications 
                                (ApplicationID, LicenseClassID)
                                VALUES 
                                (@ApplicationID, @LicenseClassID);

                                SELECT SCOPE_IDENTITY();";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    LocalDrivingLicenseApplicationID = insertedID;
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

            return LocalDrivingLicenseApplicationID;

        }
        public static bool GetLocalDrivingLicenseApplicationsByLocalDrivingLicenseApplicationID(
            int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseClassID)
        {

            bool isFound = false;
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                            WHERE   
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    isFound = true;
                    
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
                
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
        public static bool GetLocalDrivingLicenseApplicationsByApplicationID(ref int LocalDrivingLicenseApplicationID
            , int ApplicationID, ref int LicenseClassID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"SELECT * FROM LocalDrivingLicenseApplications
                            WHERE 
                            ApplicationID = @ApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                
                    isFound = true;
                    
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    LicenseClassID = (int)reader["LicenseClassID"];
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
        public static bool UpdateLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"UPDATE LocalDrivingLicenseApplications 
                             SET
                             ApplicationID = @ApplicationID,
                             LicenseClassID = @LicenseClassID
                             WHERE
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            
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
        public static bool DeleteLocalDrivingLicenseApplications(int LocalDrivingLicenseApplicationID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"DELETE FROM LocalDrivingLicenseApplications
                             WHERE
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            try
            {
            
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        
        }
        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"SELECT * From LocalDrivingLicenseApplications_View
                                order by ApplicationDate Desc";

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
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications 
                            INNER JOIN
                            TestAppointments
                            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            INNER JOIN
                            Tests
                            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND (TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool IsFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications
                            INNER JOIN
                            TestAppointments
                            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            INNER JOIN
                            Tests
                            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND (TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return IsFound;

        }
        public static int TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications 
                            INNER JOIN
                            TestAppointments
                            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            INNER JOIN
                            Tests 
                            ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND (TestAppointments.TestTypeID = @TestTypeID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications
                            INNER JOIN
                            TestAppointments
                            ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND (TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

    }
}
