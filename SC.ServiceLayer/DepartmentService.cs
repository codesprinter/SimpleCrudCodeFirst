using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SC.DomainLayer.Model;
using SC.DomainLayer;
using SC.DataAccessLayer;
using SC.BussinessLayer;

namespace SC.ServiceLayer
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartment();
        bool SaveDepartment(Department department);

        Department GetDepartmentByCode(string code);
        bool DeleteDepartment(long id);
    }
    public class DepartmentService:  IDepartmentService
    {
        private string _contextName = string.Empty;
        public DepartmentService(string contextName)
        { 
            _contextName =contextName;
        }
        public List<Department> GetAllDepartment()
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                DepartmentBusiness departmentBusiness = new DepartmentBusiness(uow);
                var departments = departmentBusiness.GetAllDepartment();
                return departments.ToList();
            }
        }
        public bool SaveDepartment(Department department)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                DepartmentBusiness departmentBusiness = new DepartmentBusiness(uow);
                bool saved = departmentBusiness.SaveDepartment(department);
                uow.SaveChanges();
                return saved;
            }
        }
        public Department GetDepartmentByCode(string code)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                DepartmentBusiness departmentBusiness = new DepartmentBusiness(uow);
                var department = departmentBusiness.GetDepartmentByCode(code);
                return department;
            }
        }
        public bool DeleteDepartment(long id)
        {
            using (SCContext context = new SCContext(_contextName)) {
                IUnitOfWork uow = new UnitOfWork(context);
                DepartmentBusiness departmentBusiness = new DepartmentBusiness(uow);
                bool success = departmentBusiness.DeleteDepartment(id);
                uow.SaveChanges();
                return success;
            }
        }
    }
}
