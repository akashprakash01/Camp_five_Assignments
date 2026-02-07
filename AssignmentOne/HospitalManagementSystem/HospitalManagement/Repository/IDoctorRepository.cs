using HospitalManagement.Models;

namespace HospitalManagement.Repository
{
    public interface IDoctorRepository
    {
        //list all Docotrs
        IEnumerable<Doctor> GetAllDoctors();
    }
}
