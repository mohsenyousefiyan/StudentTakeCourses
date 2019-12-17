using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.EndPoints.WebApi.ViewModels.CourseViewModel
{
    public class CourseAddViewModel
    {
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public Int16 FieldId { get; set; }
        [Required]
        public byte UnitCount { get; set; }
        [Required]
        public CourseUnitType UnitType { get; set; }
    }
}
