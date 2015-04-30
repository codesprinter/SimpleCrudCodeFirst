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
    public class Course: IEntity
    {
        [Key]
        public long CourseID { get; set; }
        [Required,  MaxLength(10)]
        public string CourseCode { get; set; }
        [Required, MaxLength(100)]
        public string CourseTitle { get; set; }
        [MaxLength(500)]
        public string CourseDescription { get; set; }
        [Required]
        public int Credit { get; set; }
        [NotMapped]
        public EntityState EntityState { get; set; }
    }
}
