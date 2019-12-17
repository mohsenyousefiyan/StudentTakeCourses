using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.CourseDto
{
    public class CourseSearchDto: BaseSelectPageingDto
    {       
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Int16? FieldId { get; set; }

    }
}
