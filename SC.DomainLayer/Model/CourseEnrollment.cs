using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC.DomainLayer.Model
{
    public class Enrollment
    {
        [Key]
        public long EnrollmentID { get; set; }
        public long StudentID { get; set; }
        public long DateOfEnrollment { get; set; }
        public virtual List<EnrollmentDetails> Courses { get; set; }
    }
}
