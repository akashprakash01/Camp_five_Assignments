using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Name should not be empty")]
        [RegularExpression(@"^[A-Za-z][A-Za-z\s]*$",
       ErrorMessage = "Name must start with a letter and contain only alphabets and spaces")]
        public string PatientName { get; set; }

        [Required(ErrorMessage = "Age should not be empty")]
        [Range(50, 100, ErrorMessage = "Age must be above 50")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email should not be Empty")]
        [EmailAddress(ErrorMessage = "Enter valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Address should not be empty")]
        [RegularExpression(@"^[A-Za-z][A-Za-z\s]*$",
       ErrorMessage = "Address must start with a letter and contain only alphabets and spaces")]
        public string Address { get; set; }


    }
}
