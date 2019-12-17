using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Dtos.TermDto
{
    public class TermAddDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
