using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SC.DomainLayer.Model
{
    public class Department : IEntity
    {
        [Key]
        public long DepartmentID { get; set; }
        [Required]
        public string DepartmentCode { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
