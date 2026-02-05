using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagement.Controllers
{
    public class AppointmentController : Controller
    {
        //In memory Database
        public static List<Appointment> ListOfAppointment = new();

        public IActionResult Index()
        {
            var today = DateTime.Today;

            var todaysAppointments = ListOfAppointment
                .Where(a => a.AppointmentDate.Date == today)
                .ToList();

            return View(todaysAppointments);
        }


        //function to load patients and doctors
        public void LoadData()
        {
            ViewBag.Doctors = new SelectList(
                DoctorController.ListOfDoctors ?? new List<Doctor>(),
                "DoctorId",
                "DoctorName"
            );

            ViewBag.Patients = new SelectList(
                PatientController.ListOfPatients ?? new List<Patient>(),
                "PatientId",
                "PatientName"
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            LoadData();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Appointment appointment)
        {
            LoadData();
            if(ModelState.IsValid)
            {
                appointment.AppointmentId = ListOfAppointment.Count + 1;
                ListOfAppointment.Add(appointment); 

                //redirect to Appointment List
                return RedirectToAction("Index");
            }
            return View(appointment);
        }
    }
}
