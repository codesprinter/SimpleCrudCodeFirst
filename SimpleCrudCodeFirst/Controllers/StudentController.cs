using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SC.ViewModel;
using SC.ServiceLayer;
using SC.DomainLayer.Model;
using AutoMapper;
using SC.Utility;


namespace SC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private  IStudentService _studentService = null;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        //
        // GET: /Student/
        public ActionResult Index()
        {
            var studentListViewModel = new StudentListViewModel();
            studentListViewModel.FormTitle = "Student List";
            studentListViewModel.StudentList = studentListViewModel.CopyModelToViewModel(_studentService.GetAllStudent());
            return View(studentListViewModel);
        }
        [HttpGet]
        public ActionResult EditStudent(string code = "")
        {
            StudentViewModel studentViewModel = new StudentViewModel();
            
            if (code.Length <= 0 || code.Equals("0")) {
                studentViewModel.FormTitle = "Add Student";
                studentViewModel.Dob = DateTime.Today;
            } else {
                studentViewModel = studentViewModel.CopyModelToViewModel(_studentService.GetStudentByCode(code));
                studentViewModel.FormTitle = "Edit Student";
            }
            return PartialView("_EditStudent", studentViewModel);
        }
        [HttpPost]
        public PartialViewResult EditStudent(StudentViewModel studentViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();

            if (ModelState.IsValid) {
                if (studentViewModel.StudentID == 0) {
                    Student student = studentViewModel.CopyViewModelToModel(studentViewModel);
                    student.EntityState = SC.DomainLayer.EntityState.Added;
                    success = _studentService.SaveStudent(student);
                } else {
                    Student student = studentViewModel.CopyViewModelToModel(studentViewModel);
                    student.EntityState = SC.DomainLayer.EntityState.Modified;
                    success = _studentService.SaveStudent(student);
                }
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_SAVED_SUCCESS_FULLY, "Student");
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
        [HttpGet]
        public PartialViewResult GetListofStudent()
        {
            var studentListViewModel = new StudentListViewModel();
            var studentList = studentListViewModel.CopyModelToViewModel(_studentService.GetAllStudent());
            return PartialView("_StudentList", studentList);
        }
        [HttpGet]
        public PartialViewResult DeleteStudent(string code)
        {

            if (code.Length <= 0 || code.Equals("0")) {
                MessageViewModel message = new MessageViewModel();
                //courseViewModel.FormTitle = "Add Course";
                return PartialView("_Message", message);
            } else {
                DeleteConfirmationViewModel deleteConfirmationViewModel = new DeleteConfirmationViewModel();
                Student student = _studentService.GetStudentByCode(code);
                deleteConfirmationViewModel.DeleteEntityID = student.StudentID;
                deleteConfirmationViewModel.HeaderText = "Delete Student?";
                deleteConfirmationViewModel.PostDeleteController = "Student";
                deleteConfirmationViewModel.PostDeleteAction = "DeleteStudent";
                deleteConfirmationViewModel.DeleteMessage = string.Format(AppMessage.DELETE_CONFIRMATION, "student");
                return PartialView("_DeleteConfirmation", deleteConfirmationViewModel);
            }
        }
        [HttpPost]
        public PartialViewResult DeleteStudent(DeleteConfirmationViewModel deleteConfirmationViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();

            if (ModelState.IsValid) {
                success = _studentService.DeleteStudent(deleteConfirmationViewModel.DeleteEntityID);
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_DELETED_SUCCESS_FULLY, "Student");
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
	}
}