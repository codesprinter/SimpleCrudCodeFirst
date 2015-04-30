using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrudCodeFirst.ViewModel
{
    public class DeptViewModel
    {
        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Department Name is required")]
        [MaxLength(50, ErrorMessage = "Department Name should not be more than 50 charecters")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Code")]  
        [Required(ErrorMessage = "Department Code is required")]
        [MaxLength(50, ErrorMessage = "Course Code should not be more than 50 charecters")]
        public string DepartmentCode { get; set; }
    }
}