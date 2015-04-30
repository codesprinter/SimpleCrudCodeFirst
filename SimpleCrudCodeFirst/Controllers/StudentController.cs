using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SC.ViewModel;
using SC.ServiceLayer;
using SC.DomainLayer.Model;
using AutoMapper;


namespace SC.Controllers
{
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
            var studentList = _studentService.GetAllStudent();
            Mapper.CreateMap<Student, StudentViewModel>();
            var studentViewModelList = Mapper.Map<IList<Student>, IEnumerable<StudentViewModel>>(studentList);
            return View(studentViewModelList.ToList());
        }
        [HttpGet]
        public ActionResult EditStudent(string code = "")
        {
            StudentViewModel studentViewModel = null;
            if (code.Length <= 0 || code == "0") {
                studentViewModel = new StudentViewModel();
            } else {

                
            }
            return PartialView("_EditStudent", studentViewModel);
        }
        [HttpPost]
        public ActionResult AddStudent(StudentViewModel studentViewModel)
        {
            if (studentViewModel.IsNew) {


                studentViewModel.IsNew = false;
            } else { 
                
            }
            studentViewModel.IsFromSave = true;
            return RedirectToAction("EditStudent",studentViewModel.StudentCode);
        }
        
	}
}