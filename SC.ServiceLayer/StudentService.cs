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
    public interface IStudentService
    {
        IList<Student> GetAllStudent();
        void SaveStudent(Student student);
        void RemoveStudent(string studentCode);
        Student GetStudentDetails(string studentCode);
    }
    public class StudentService: IStudentService
    {
        private string _contextName;
        public StudentService(string contextName)
        {
            _contextName = contextName;
        }

        public IList<Student> GetAllStudent()
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                StudentBusiness studentBusiness = new StudentBusiness(uow);
                var students = studentBusiness.GetAllStudent();
                return students;
            }
        }
        public void SaveStudent(Student student)
        {}
        public void RemoveStudent(string studentCode)
        {}
        public Student GetStudentDetails(string studentCode)
        {
            SCContext context = new SCContext(_contextName);
            IUnitOfWork uow = new UnitOfWork(context);
            IGenericDataRepository<Student> studentRepo = uow.RepositoryFor<Student>();
            var student = studentRepo.GetSingle(p => p.StudentCode.Equals(studentCode));
            uow.Dispose();
            return student;
        }
    }
}
