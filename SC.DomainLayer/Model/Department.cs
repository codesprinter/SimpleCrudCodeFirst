using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SC.DomainLayer.Model
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
