using HospitalManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalManagement.Controllers
{
    public class DoctorController : Controller
    {
        //In memory databse
        public static  List<Doctor> ListOfDoctors = new();

        private List<string> GetSpecialization()
        {
            return new List<string>
            {
                "Cardiology",
                "Neurology",
                "Orthopedics",
                "Pediatrics",
                "Dermatology",
                "General Medicine"
            };
        }
        public IActionResult Index(string specialization)
        {
            var doctors = ListOfDoctors;

            if (!string.IsNullOrWhiteSpace(specialization))
            {
             

                doctors = ListOfDoctors
                       .Where(d => d.Specialization
                        .Contains(specialization, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.SearchValue = specialization;
            return View(doctors);
        }


        //Create a new Doctor
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Specializations = GetSpecialization();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            ViewBag.Specializations = GetSpecialization();

            if (ModelState.IsValid)
            {
                doctor.DoctorId = ListOfDoctors.Count+1;
                ListOfDoctors.Add(doctor);

                //Message
                TempData["Message"] = "Doctor Added Successfully";

                //Redirect to Doctor List
                return RedirectToAction("Index");
            }
            return View(doctor);
        }
    }
}
