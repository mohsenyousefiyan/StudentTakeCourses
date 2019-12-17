using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    /// <summary>
    /// چارت درسی هر رشته و ورودی های مشخص شده را نگهداری می کند.در این قسمت است که مشخص می شود
    /// برای هر ورودی هر رشته چه دروسی باید با چه پیش نیاز یا هم نیازی ارائه شود
    /// </summary>
    public class Syllabus:BaseEntity<int>
    {       
        public Int16 CourseId { get; set; }
        public Course Course { get; set; }
        public TermOrder TermOrder { get; set; }
        public Categury Categury { get; set; }
        public List<Course> PrerequisiteCourses{ get; private set; }
        public List<Course> NeededCourses { get; private set; }
        public byte RequiredPassedCount { get; set; }
        public DateTime ApplyStartEnteringDate { get; set; }
        public DateTime? ApplyEndEnteringDate { get; set; }
    }
}
