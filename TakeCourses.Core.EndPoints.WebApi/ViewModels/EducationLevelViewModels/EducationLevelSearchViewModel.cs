using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.EndPoints.WebApi.ViewModels.BaseViewModels;

namespace TakeCourses.EndPoints.WebApi.ViewModels.EducationLevelViewModels
{
    public class EducationLevelSearchViewModel: BaseSelectPageingViewModel
    {
        public string LevelName { get; set; }
    }
}
