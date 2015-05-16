using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SC.ServiceLayer;
using SC.DomainLayer.Model;
using SC.ViewModel;
using SC.Utility;

namespace SimpleCrudCodeFirst.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentService _departmentService = null;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        // GET: /Department/
        public ActionResult Index()
        {
            var departmentListViewModel = new DepartmentListViewModel();
            departmentListViewModel.DepartmentList = departmentListViewModel.CopyModelToViewModel(_departmentService.GetAllDepartment());
            return View(departmentListViewModel);
        }
        [HttpGet]
        public PartialViewResult GetListofDepartment()
        {
            var departmentListViewModel = new DepartmentListViewModel();
            var departmentList = departmentListViewModel.CopyModelToViewModel(_departmentService.GetAllDepartment());
            return PartialView("_DepartmentList", departmentList);
        }
        [HttpGet]
        public PartialViewResult EditDepartment(string code = "")
        {
            DepartmentViewModel deptViewModel = new DepartmentViewModel();
            if (code.Length <= 0 || code.Equals("0")) {
                deptViewModel.FormTitle = "Add Department";
            } else {
                deptViewModel = deptViewModel.CopyModelToViewModel(_departmentService.GetDepartmentByCode(code));
                deptViewModel.FormTitle = "Edit Department";
            }
            return PartialView("_EditDepartment", deptViewModel);
        }
        [HttpPost]
        public PartialViewResult EditDepartment(DepartmentViewModel departmentViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();
            if (ModelState.IsValid) {
                if (departmentViewModel.DepartmentID == 0) {
                    Department department = departmentViewModel.CopyViewModelToModel(departmentViewModel);
                    department.EntityState = SC.DomainLayer.EntityState.Added;
                    success = _departmentService.SaveDepartment(department);
                } else {
                    Department department = departmentViewModel.CopyViewModelToModel(departmentViewModel);
                    department.EntityState = SC.DomainLayer.EntityState.Modified;
                    success = _departmentService.SaveDepartment(department);
                }
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_SAVED_SUCCESS_FULLY, "Department");
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
        [HttpGet]
        public PartialViewResult DeleteDepartment(string code)
        {

            if (code.Length <= 0 || code.Equals("0")) {
                MessageViewModel message = new MessageViewModel();
                //courseViewModel.FormTitle = "Add Course";
                return PartialView("_Message", message);
            } else {
                DeleteConfirmationViewModel deleteConfirmationViewModel = new DeleteConfirmationViewModel();
                Department department = _departmentService.GetDepartmentByCode(code);
                deleteConfirmationViewModel.DeleteEntityID = department.DepartmentID;
                deleteConfirmationViewModel.HeaderText = "Delete Department?";
                deleteConfirmationViewModel.PostDeleteController = "Department";
                deleteConfirmationViewModel.PostDeleteAction = "DeleteDepartment";
                deleteConfirmationViewModel.DeleteMessage = string.Format(AppMessage.DELETE_CONFIRMATION, "department");
                return PartialView("_DeleteConfirmation", deleteConfirmationViewModel);
            }
        }
        [HttpPost]
        public PartialViewResult DeleteDepartment(DeleteConfirmationViewModel deleteConfirmationViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();

            if (ModelState.IsValid) {
                success = _departmentService.DeleteDepartment(deleteConfirmationViewModel.DeleteEntityID);
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_DELETED_SUCCESS_FULLY, "Department");
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
	}
}