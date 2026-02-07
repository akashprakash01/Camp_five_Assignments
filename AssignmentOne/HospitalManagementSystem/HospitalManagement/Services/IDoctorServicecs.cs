using HospitalManagement.Models;
using System.Collections;

namespace HospitalManagement.Services
{
    public interface IDoctorServicecs
    {
        //list of doctors
        IEnumerable<Doctor> SelectAllDoctors();
    }
}
