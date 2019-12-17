using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class Term:BaseEntity<int>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
