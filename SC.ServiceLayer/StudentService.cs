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
        List<Student> GetAllStudent();
        bool SaveStudent(Student student);
        bool DeleteStudent(long id);
        Student GetStudentByCode(string code);
    }
    public class StudentService: IStudentService
    {
        private string _contextName;
        public StudentService(string contextName)
        {
            _contextName = contextName;
        }

        public List<Student> GetAllStudent()
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                StudentBusiness studentBusiness = new StudentBusiness(uow);
                var students = studentBusiness.GetAllStudent();
                return students.ToList();
            }
        }
        public bool SaveStudent(Student student)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                StudentBusiness studentBusiness = new StudentBusiness(uow);
                bool saved = studentBusiness.SaveStudent(student);
                uow.SaveChanges();
                return saved;
            }
        }
        public bool DeleteStudent(long id)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                StudentBusiness studentBusiness = new StudentBusiness(uow);
                bool saved = studentBusiness.SaveStudent(new Student { StudentID = id, EntityState = EntityState.Deleted });
                uow.SaveChanges();
                return saved;
            }
        }
        public Student GetStudentByCode(string code)
        {
            SCContext context = new SCContext(_contextName);
            IUnitOfWork uow = new UnitOfWork(context);
            IGenericDataRepository<Student> studentRepo = uow.RepositoryFor<Student>();
            var student = studentRepo.GetSingle(p => p.StudentCode.Equals(code));
            uow.Dispose();
            return student;
        }
    }
}
