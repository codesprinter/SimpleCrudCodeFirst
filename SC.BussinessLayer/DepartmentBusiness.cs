using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DomainLayer.Model;
using SC.DataAccessLayer;

namespace SC.BussinessLayer
{
    public class DepartmentBusiness
    {
        private IUnitOfWork _uow = null;
        public DepartmentBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IList<Department> GetAllDepartment()
        {
            IGenericDataRepository<Department> deptRepo = _uow.RepositoryFor<Department>();
            var departments = deptRepo.GetAll().ToList();
            return departments;
        }

        public bool SaveDepartment(Department department)
        {
            IGenericDataRepository<Department> departmentRepo = _uow.RepositoryFor<Department>();
            departmentRepo.Add(department);
            return true;
        }
        
        public Department GetDepartmentByCode(string code)
        {
            IGenericDataRepository<Department> courseRepo = _uow.RepositoryFor<Department>();
            var department = courseRepo.GetSingle(p => p.DepartmentCode.Equals(code));
            return department;
        }

        public bool DeleteDepartment(long id)
        {
            IGenericDataRepository<Department> departmentRepo = _uow.RepositoryFor<Department>();
            Department department = new Department();
            department.DepartmentID = id;
            department.EntityState = DomainLayer.EntityState.Deleted;
            departmentRepo.Remove(department); ;
            return true;
        }
    }
}
