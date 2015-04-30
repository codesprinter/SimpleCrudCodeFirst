using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SC.DomainLayer;

namespace SC.DomainLayer.Model
{
    public class EnrollmentDetails
    {
        [Key]
        public long EnrollmentDetailID { get; set; }
        public long EnrollmentID { get; set; }
        public long CourseID { get; set; }
        [ForeignKey("EnrollmentID")]
        public virtual Enrollment Enrollment { get; set; }
        public EntityState EntityState { get; set; }
        
    }
}
