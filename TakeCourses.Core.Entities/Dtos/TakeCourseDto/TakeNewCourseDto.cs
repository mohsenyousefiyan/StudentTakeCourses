using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Dtos.TakeCourseDto
{
    public class TakeNewCourseDto
    {
        public int StudentCourseId { get; set; }
        public int TermCourseId { get; set; }
        public DateTime TakeDate { get; set; }
    }
}
