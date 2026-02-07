using ClassLibraryDatabaseConnection;
using HospitalManagement.Models;
using Microsoft.Data.SqlClient;

namespace HospitalManagement.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string connectionString;

        public PatientRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnStringMVC");
        }

        #region get all patients
        public IEnumerable<Patient> GetAllPatients()
        {
            List<Patient> result = new List<Patient>();
            using (SqlConnection connection = ConnectionManager.OpenConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllPatients", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Patient patient = new Patient();
                        patient.PatientId = Convert.ToInt32(reader["PatientId"]);
                        patient.PatientName = reader["PatientName"].ToString();
                        patient.Age = Convert.ToInt32(reader["Age"]);
                        patient.Email = reader["email"].ToString();
                        patient.Address = reader["Address"].ToString();

                        result.Add(patient);
                    }
                }
                connection.Close();
            }
            return result;
        }
        #endregion

    }
}
