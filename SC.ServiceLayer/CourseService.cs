using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DomainLayer.Model;
using SC.DomainLayer;
using SC.BussinessLayer;
using SC.DataAccessLayer;


namespace SC.ServiceLayer
{
    public interface ICourseService
    {
        bool SaveCourse(Course course);
        List<Course> GetAllCourse();
        Course GetCourseByCode(string code);
        bool DeleteCourse(long id);
    }
    public class CourseService: ICourseService  
    {
        private string _contextName;
        public CourseService(string contextName)
        {
            _contextName = contextName;
        }
        public bool SaveCourse(Course course)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                CourseBusiness courseBusiness = new CourseBusiness(uow);
                bool saved = courseBusiness.SaveCourse(course);
                uow.SaveChanges();
                return saved;
            }
        }
        public List<Course> GetAllCourse()
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                CourseBusiness courseBusiness = new CourseBusiness(uow);
                var courseList = courseBusiness.GetAllCourse();
                return courseList.ToList();
            }
        }
        public Course GetCourseByCode(string code) 
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                CourseBusiness courseBusiness = new CourseBusiness(uow);
                var course = courseBusiness.GetCourseCodeByCode(code);
                return course;
            }
        }
        public bool DeleteCourse(long id)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                CourseBusiness courseBusiness = new CourseBusiness(uow);
                var course = courseBusiness.DeleteCourse(id);
                uow.SaveChanges();
                return true;
            }
        }
    }
}
