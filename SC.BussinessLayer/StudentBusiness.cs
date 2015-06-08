using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DataAccessLayer;
using SC.DomainLayer;
using SC.DomainLayer.Model;

namespace SC.BussinessLayer
{
    public class StudentBusiness
    {
        private IUnitOfWork _uow = null;
        public StudentBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IList<Student> GetAllStudent()
        {
            IGenericDataRepository<Student> studentRepo = _uow.RepositoryFor<Student>();
            var students = studentRepo.GetAll().ToList();
            return students;
        }
        public bool SaveStudent(Student student)
        {
            IGenericDataRepository<Student> studentRepo = _uow.RepositoryFor<Student>();
            studentRepo.Add(student);
            return true;
        }
    }
}
