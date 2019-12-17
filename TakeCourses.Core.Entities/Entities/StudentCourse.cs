using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    /// <summary>
    /// جهت ذخیره سازی هدر انتخاب واحد های یک دانشجو
    /// </summary>
    public class StudentCourse: BaseEntity<int>
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TermId { get; set; }
        public Term Term { get; set; }        
        public DateTime LastEditDate { get; set; }
        public StudentCourseStatusEnum RegisterStatus { get; set; }
    }

    
}
