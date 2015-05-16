using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DataAccessLayer;
using SC.DomainLayer.Model;

namespace SC.BussinessLayer
{
    public class CourseBusiness
    {
        private IUnitOfWork _uow = null;
        public CourseBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IList<Course> GetAllCourses()
        {
            IGenericDataRepository<Course> courseRepo = _uow.RepositoryFor<Course>();
            var courses = courseRepo.GetAll().ToList();
            return courses;
        }

        public bool SaveCourse(Course course)
        {
            IGenericDataRepository<Course> courseRepo = _uow.RepositoryFor<Course>();
            courseRepo.Add(course);
            return true;
        }
        public IList<Course> GetAllCourse()
        {
            IGenericDataRepository<Course> courseRepo = _uow.RepositoryFor<Course>();
            var courseList  = courseRepo.GetAll();
            return courseList;
        }

        public Course GetCourseByCode(string code)
        {
            IGenericDataRepository<Course> courseRepo = _uow.RepositoryFor<Course>();
            var course = courseRepo.GetSingle(p => p.CourseCode.Equals(code));
            return course;
        }

        public bool DeleteCourse(long id)
        {
            IGenericDataRepository<Course> courseRepo = _uow.RepositoryFor<Course>();
            Course course = new Course();
            course.CourseID = id;
            course.EntityState = DomainLayer.EntityState.Deleted;
            courseRepo.Remove(course); ;
            return true;
        }
    }
}
