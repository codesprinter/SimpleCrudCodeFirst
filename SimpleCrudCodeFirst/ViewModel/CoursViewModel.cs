using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using SC.DomainLayer.Model;
using AutoMapper;

namespace SC.ViewModel
{
    public class CourseViewModel
    {
        public bool IsEdit { get; set; }
        public long CourseID { get; set; }
        public string FormTitle { get; set; }
        [DisplayName("Course Code")]
        [Required(ErrorMessage = "Course Code is required")]
        [MaxLength(50, ErrorMessage = "Course Code should not be more than 50 charecters")]
        public string CourseCode { get; set; }
        [DisplayName("Course Title")]
        [Required(ErrorMessage = "Course Title is required")]
        [MaxLength(100, ErrorMessage = "Course Title should not be more than 100 charecters")]
        public string CourseTitle { get; set; }
        [DisplayName("Course Description")]
        [MaxLength(500, ErrorMessage = "Course Description should not be more than 100 charecters")]
        public string CourseDescription { get; set; }
        [DisplayName("Credit")]
        [Required(ErrorMessage = "Credit is required")]
        public int Credit { get; set; }

        public CourseViewModel CopyModelToViewModel(Course source)
        {
            Mapper.CreateMap<Course, CourseViewModel>();
            CourseViewModel courseViewModel = Mapper.Map<CourseViewModel>(source);
            return courseViewModel;
        }

        public Course CopyViewModelToModel(CourseViewModel soursce)
        {
            Mapper.CreateMap<CourseViewModel, Course>();
            Course course = Mapper.Map<Course>(soursce);
            return course;
        }
    }
}