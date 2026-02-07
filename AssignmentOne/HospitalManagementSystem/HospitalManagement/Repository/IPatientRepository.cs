using HospitalManagement.Models;

namespace HospitalManagement.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();

    }
}
