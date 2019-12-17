using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TakeCourses.EndPoints.WebApi.ViewModels.EducationLevelViewModels
{
    public class EducationLevelAddViewMoel
    {
        [Required]
        public string LevelName { get; set; }
    }
}
