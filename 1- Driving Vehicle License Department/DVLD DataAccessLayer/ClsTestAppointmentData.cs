using System;
using System.Data;
using System.Data.SqlClient;

namespace DVLD_DataAccessLayer
{
    public class ClsTestAppointmentData
    {

        public static int AddNewTestAppointment(
             int TestTypeID, int LocalDrivingLicenseApplicationID,
             DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, int RetakeTestApplicationID)
        {

            int TestAppointmentID = -1;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"Insert Into TestAppointments 
                            (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,
                                PaidFees,CreatedByUserID,IsLocked,RetakeTestApplicationID)
                            Values 
                            (@TestTypeID,@LocalDrivingLicenseApplicationID,@AppointmentDate,
                                @PaidFees,@CreatedByUserID,0,@RetakeTestApplicationID);
                
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            if (RetakeTestApplicationID == -1)

                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestAppointmentID = insertedID;
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


            return TestAppointmentID;

        }

        public static bool GetTestAppointmentsByTestAppointmentID(int TestAppointmentID, ref int TestTypeID,
            ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate, ref decimal PaidFees,
            ref int CreatedByUserID, ref bool IsLocked, ref int RetakeTestApplicationID)
        {

            bool isFound = false;
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = "SELECT * FROM TestAppointments WHERE TestAppointmentID = @TestAppointmentID";
            
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
             
                if (reader.Read())
                {
                
                    isFound = true;
                    
                    TestTypeID = (int)reader["TestTypeID"];
                    LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    AppointmentDate = (DateTime)reader["AppointmentDate"];
                    PaidFees = (decimal)reader["PaidFees"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                    IsLocked = (bool)reader["IsLocked"];

                    if (reader["RetakeTestApplicationID"] == DBNull.Value)
                        RetakeTestApplicationID = -1;
                    else
                        RetakeTestApplicationID = (int)reader["RetakeTestApplicationID"];
                
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

        public static bool UpdateTestAppointments(
        int TestAppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate,
        decimal PaidFees, int CreatedByUserID, bool IsLocked, int RetakeTestApplicationID)
        {

            int rowsAffected = 0;
            
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            
            string query = @"UPDATE TestAppointments 
                            SET
                            TestTypeID = @TestTypeID,
                            LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID,
                            AppointmentDate = @AppointmentDate,
                            PaidFees = @PaidFees,
                            CreatedByUserID = @CreatedByUserID,
                            IsLocked = @IsLocked,
                            RetakeTestApplicationID = @RetakeTestApplicationID
                            WHERE
                            TestAppointmentID = @TestAppointmentID";
            
            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            if (RetakeTestApplicationID == -1)
                command.Parameters.AddWithValue("@RetakeTestApplicationID", DBNull.Value);
            else
                command.Parameters.AddWithValue("@RetakeTestApplicationID", RetakeTestApplicationID);

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
        public static DataTable GetApplicationTestAppointmentsPerTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                            TestAppointments.TestAppointmentID, 
                            TestAppointments.AppointmentDate, 
                            CASE 
                                WHEN Applications.ApplicationTypeID = 7 
                                THEN TestAppointments.PaidFees + Applications.PaidFees
                                ELSE TestAppointments.PaidFees
                            END AS PaidFees,
                            TestAppointments.IsLocked
                        FROM TestAppointments 
                        LEFT JOIN Applications 
                            ON TestAppointments.RetakeTestApplicationID = Applications.ApplicationID
                        WHERE  
                            TestAppointments.TestTypeID =@TestTypeID
                            AND TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                        ORDER BY 
                            TestAppointments.TestAppointmentID DESC;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);


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
        public static int GetTestID(int TestAppointmentID)
        {
            int TestID = -1;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = @"select TestID from Tests where TestAppointmentID=@TestAppointmentID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestID = insertedID;
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


            return TestID;

        }

    }
}
