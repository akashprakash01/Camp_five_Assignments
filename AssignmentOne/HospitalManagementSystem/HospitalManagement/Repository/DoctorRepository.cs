using ClassLibraryDatabaseConnection;
using HospitalManagement.Models;
using Microsoft.Data.SqlClient;

namespace HospitalManagement.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly string connectionString;

        public DoctorRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnStringMVC");
        }

        #region get all doctors

        public IEnumerable<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();
            using (SqlConnection connection = ConnectionManager.OpenConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllDoctors", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Doctor doctor = new Doctor();
                        doctor.DoctorId = Convert.ToInt32(reader["DoctorId"]);
                        doctor.DoctorName = reader["DoctorName"].ToString();
                        doctor.Age = Convert.ToInt32(reader["Age"]);
                        doctor.Specialization = reader["Specialization"].ToString();

                        doctors.Add(doctor);
                    }
                }
                connection.Close();
            }
            return doctors;
        }
        #endregion
    }
}
