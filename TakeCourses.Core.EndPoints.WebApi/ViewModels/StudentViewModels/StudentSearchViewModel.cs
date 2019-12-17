using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.EndPoints.WebApi.ViewModels.StudentViewModels
{
    public class StudentSearchViewModel: BaseSelectPageingViewModel
    {
        public string FullName { get; set; }
        public string NationCode { get; set; }
        public string StudentCode { get; set; }
        public Int16? FieldId { get; set; }
        public DateTime? StartEnteringDate { get; set; }
        public DateTime? EndEnteringDate { get; set; }
    }
}
