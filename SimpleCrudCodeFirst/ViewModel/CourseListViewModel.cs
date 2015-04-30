using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SC.DomainLayer.Model;
using AutoMapper;

namespace SC.ViewModel
{
    public class CourseListViewModel
    {
        public string FormTitle { get; set; }
        public string Message { get; set; }
        public List<CourseViewModel> CourseList { get; set; }

        public List<CourseViewModel> CopyModelToViewModel(List<Course> source)
        {
            Mapper.CreateMap<Course, CourseViewModel>();
            List<CourseViewModel> viewModel = Mapper.Map<List<CourseViewModel>>(source);
            return viewModel;
        }

        public List<Course> CopyViewModelToModel(List<CourseViewModel> source)
        {
            Mapper.CreateMap<CourseViewModel, Course>();
            List<Course> model = Mapper.Map<List<Course>>(source);
            return model;
        }
    }
}