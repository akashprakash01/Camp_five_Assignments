using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Name should not be empty")]
        [RegularExpression(@"^[A-Za-z][A-Za-z\s]*$",
        ErrorMessage = "Name must start with a letter and contain only alphabets and spaces")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Age should not be empty")]
        [Range(18, 60, ErrorMessage = "Age must between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Specialization should not be empty")]
        [RegularExpression(@"^[A-Za-z][A-Za-z\s]*$",
          ErrorMessage = "Name must start with a letter and contain only alphabets and spaces")]
        public string Specialization { get; set; }

    }
}
