using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Dtos.TakeCourseDto
{
   public class StartTakeCourseDto
    {
        public int StudentId { get; set; }       
        public int TermId { get; set; }       
        public DateTime LastEditDate { get; set; }       
    }
}
