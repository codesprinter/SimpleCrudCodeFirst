using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SC.DomainLayer;

namespace SC.DomainLayer.Model
{
    public class Student: IEntity
    {
        [Key]
        public long StudentID { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string StudentCode { get; set; }
        [Required, MaxLength(20), EmailAddress]
        public string Email { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        public DateTime Dob { get; set; }
        [NotMapped]
        public EntityState EntityState { get; set; }

    }
}
