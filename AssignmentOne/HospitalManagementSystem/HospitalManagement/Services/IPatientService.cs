using HospitalManagement.Models;

namespace HospitalManagement.Services
{
    public interface IPatientService
    {
        //list of doctors
        IEnumerable<Patient> SelectAllPatients();
    }
}
