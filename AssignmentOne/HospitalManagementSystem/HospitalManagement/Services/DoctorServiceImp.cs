using HospitalManagement.Models;
using HospitalManagement.Repository;

namespace HospitalManagement.Services
{
    public class DoctorServiceImp : IDoctorServicecs
    {
        //field
        private readonly IDoctorRepository _doctorRepository;

        //DI
        public DoctorServiceImp(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public IEnumerable<Doctor> SelectAllDoctors()
        {
            return _doctorRepository.GetAllDoctors();
        }
    }
}
