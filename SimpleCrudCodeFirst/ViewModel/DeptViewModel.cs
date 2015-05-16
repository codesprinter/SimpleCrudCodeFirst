using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using SC.DomainLayer.Model;
using AutoMapper;

namespace SC.ViewModel
{
    public class DepartmentViewModel
    {
        public string FormTitle { get; set; }
        public long DepartmentID { get; set; }
        [DisplayName("Department Name")]
        [Required(ErrorMessage = "Department Name is required")]
        [MaxLength(50, ErrorMessage = "Department Name should not be more than 50 charecters")]
        public string DepartmentName { get; set; }
        [DisplayName("Department Code")]  
        [Required(ErrorMessage = "Department Code is required")]
        [MaxLength(50, ErrorMessage = "Course Code should not be more than 50 charecters")]
        public string DepartmentCode { get; set; }

        public DepartmentViewModel CopyModelToViewModel(Department source)
        {
            Mapper.CreateMap<Department, DepartmentViewModel>();
            DepartmentViewModel deptViewModel = Mapper.Map<DepartmentViewModel>(source);
            return deptViewModel;
        }

        public Department CopyViewModelToModel(DepartmentViewModel source)
        {
            Mapper.CreateMap<DepartmentViewModel, Department>();
            Department department = Mapper.Map<Department>(source);
            return department;
        }
    }

}