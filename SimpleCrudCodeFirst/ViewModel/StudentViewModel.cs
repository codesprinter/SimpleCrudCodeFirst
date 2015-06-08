using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SC.ServiceLayer;
using SC.DomainLayer.Model;
using AutoMapper;

namespace SC.ViewModel
{
    public class StudentViewModel
    {
        public bool IsEdit { get; set; }
        public long StudentID { get; set; }
        public string FormTitle { get; set; }
        [DisplayName("First Name")]  
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "First Name should not be more than 50 charecters")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "Last Name should not be more than 50 charecters")]
        public string LastName { get; set; }
        [DisplayName("Student Code")]
        [Required(ErrorMessage = "Student Code is required")]
        [MaxLength(50, ErrorMessage = "Student Code should not be more than 50 charecters")]
        public string StudentCode { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DisplayName("Department")]
        public IEnumerable<SelectListItem> DepartmentList { get { return LookUpModelSet.DepartmentSelectList; } }
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dob { get; set; }
        public long DepartmentID { get; set; }

        public StudentViewModel CopyModelToViewModel(Student source)
        {
            Mapper.CreateMap<Student, StudentViewModel>();
            StudentViewModel studentViewModel = Mapper.Map<StudentViewModel>(source);
            return studentViewModel;
        }

        public Student CopyViewModelToModel(StudentViewModel source)
        {
            Mapper.CreateMap<StudentViewModel, Student>();
            Student student = Mapper.Map<Student>(source);
            return student;
        }
        

    }
}