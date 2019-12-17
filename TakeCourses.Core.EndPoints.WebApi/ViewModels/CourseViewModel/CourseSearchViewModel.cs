using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.EndPoints.WebApi.ViewModels.CourseViewModel
{
    public class CourseSearchViewModel: BaseSelectPageingViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Int16? FieldId { get; set; }
    }
}
