using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SC.ViewModel;
using SC.ServiceLayer;
using SC.DomainLayer.Model;
using SC.Utility;

namespace SimpleCrudCodeFirst.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService = null;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        //
        // GET: /Course/
        public ActionResult Index()
        {
            var courseListViewModel = new CourseListViewModel();
            courseListViewModel.FormTitle = "Course List";
            courseListViewModel.CourseList = courseListViewModel.CopyModelToViewModel(_courseService.GetAllCourse());
            return View(courseListViewModel);
        }
        [HttpGet]
        public PartialViewResult GetListofCourse()
        {
            var courseListViewModel = new CourseListViewModel();
            var courseList = courseListViewModel.CopyModelToViewModel(_courseService.GetAllCourse());
            return PartialView("_CourseList", courseList);
        }
        [HttpGet]
        public PartialViewResult EditCourse(string code = "")
        {
            CourseViewModel courseViewModel = new CourseViewModel();
            if (code.Length <= 0 || code.Equals("0")) {
                courseViewModel.FormTitle = "Add Course";
            } else {
                courseViewModel = courseViewModel.CopyModelToViewModel(_courseService.GetCourseByCode(code));
                courseViewModel.FormTitle = "Edit Course";
            }
            return PartialView("_EditCourse", courseViewModel);
        }
        [HttpPost]
        public PartialViewResult EditCourse(CourseViewModel courseViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();
            if(ModelState.IsValid){
                if (courseViewModel.CourseID == 0) {
                    Course course = courseViewModel.CopyViewModelToModel(courseViewModel);
                    course.EntityState = SC.DomainLayer.EntityState.Added;
                    success = _courseService.SaveCourse(course);
                } else {
                    Course course = courseViewModel.CopyViewModelToModel(courseViewModel);
                    course.EntityState = SC.DomainLayer.EntityState.Modified;
                    success = _courseService.SaveCourse(course);
                }
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_SAVED_SUCCESS_FULLY, "Course"); 
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
        [HttpGet]
        public PartialViewResult DeleteCourse(string code)
        {
            
            if (code.Length <= 0 || code.Equals("0")) {
                MessageViewModel message = new MessageViewModel();
                //courseViewModel.FormTitle = "Add Course";
                return PartialView("_Message", message);
            } else {
                DeleteConfirmationViewModel deleteConfirmationViewModel = new DeleteConfirmationViewModel();
                Course course = _courseService.GetCourseByCode(code);
                deleteConfirmationViewModel.DeleteEntityID = course.CourseID;
                deleteConfirmationViewModel.HeaderText = "Delete Course?";
                deleteConfirmationViewModel.PostDeleteController = "Course";
                deleteConfirmationViewModel.PostDeleteAction = "DeleteCourse";
                deleteConfirmationViewModel.DeleteMessage = string.Format(AppMessage.DELETE_CONFIRMATION, "course");
                return PartialView("_DeleteConfirmation", deleteConfirmationViewModel);
            }
        }
        [HttpPost]
        public PartialViewResult DeleteCourse(DeleteConfirmationViewModel deleteConfirmationViewModel)
        {
            bool success = false;
            MessageViewModel message = new MessageViewModel();
            
            if (ModelState.IsValid) {
                success = _courseService.DeleteCourse(deleteConfirmationViewModel.DeleteEntityID);
            }
            if (success) {
                message.MessageType = EMessageType.Success;
                message.MessageText = string.Format(AppMessage.DATA_DELETED_SUCCESS_FULLY, "Course");
                message.ClassName = AppConstant.SUCCESS_CLASS;
            }
            return PartialView("_Message", message);
        }
	}
}