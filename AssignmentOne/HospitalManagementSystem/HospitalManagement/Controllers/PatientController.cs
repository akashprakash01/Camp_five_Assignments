using HospitalManagement.Models;
using HospitalManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class PatientController : Controller
    {
        //in Memory Database
        public static List<Patient> ListOfPatients = new();

        public IActionResult Index()
        {
            return View(ListOfPatients);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {

            if (ModelState.IsValid)
            {
                patient.PatientId = ListOfPatients.Count + 1;
                ListOfPatients.Add(patient);

                //Message
                TempData["Message"] = "Patient Added Successfully";

                //Redirect to Doctor List
                return RedirectToAction("Index");
            }
            return View(patient);
        }


        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        #region get all Patients
        public ActionResult FetchPatients()
        {

            List<Patient> patients = _patientService.SelectAllPatients().ToList();
            return View(patients);
        }
        #endregion
    }
}
