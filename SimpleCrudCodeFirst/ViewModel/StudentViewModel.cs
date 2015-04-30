using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.ViewModel
{
    public class StudentViewModel
    {
        public bool IsNew { get; set; }
        public bool IsFromSave { get; set; }
        [DisplayName("First Name")]  
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "First Name should not be more than 50 charecters")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "Last Name should not be more than 50 charecters")]
        public string LastName { get; set; }
        [DisplayName("Student Code")]
        [Required(ErrorMessage = "Student Code is required")]
        [MaxLength(50, ErrorMessage = "Student Code should not be more than 50 charecters")]
        public string StudentCode { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public int DepartmentID { get; set; }
        [DisplayName("Department")]
        public string DepartmentName { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }

    }
}