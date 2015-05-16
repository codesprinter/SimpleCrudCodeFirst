using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SC.DomainLayer.Model;
using AutoMapper;

namespace SC.ViewModel
{
    public class DepartmentListViewModel
    {
        public string FormTitle { get; set; }
        public string Message { get; set; }
        public List<DepartmentViewModel> DepartmentList { get; set; }

        public List<DepartmentViewModel> CopyModelToViewModel(List<Department> source)
        {
            Mapper.CreateMap<Department, DepartmentViewModel>();
            List<DepartmentViewModel> viewModel = Mapper.Map<List<DepartmentViewModel>>(source);
            return viewModel;
        }

        public List<Department> CopyViewModelToModel(List<DepartmentListViewModel> source)
        {
            Mapper.CreateMap<CourseViewModel, Course>();
            List<Department> model = Mapper.Map<List<Department>>(source);
            return model;
        }
    }
}