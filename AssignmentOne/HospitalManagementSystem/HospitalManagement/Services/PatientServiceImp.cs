using HospitalManagement.Models;
using HospitalManagement.Repository;

namespace HospitalManagement.Services
{
    public class PatientServiceImp : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientServiceImp(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public IEnumerable<Patient> SelectAllPatients()
        {
           return _patientRepository.GetAllPatients(); 
        }
    }
}
