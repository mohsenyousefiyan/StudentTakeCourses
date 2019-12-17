using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    /// <summary>
    /// جهت ذخیره واحدهای درسی اخذ شده توسط دانشجویان 
    /// </summary>
    public class StudentCourseDetail:BaseEntity<int>
    {
        public int StudentCourseId { get; set; }
        public StudentCourse StudentCourse { get; set; }
        public int TermCourseId { get; set; }
        public TermCourse TermCourse { get; set; }
        public DateTime TakenDate { get; set; }
        public decimal? Grade { get; set; }
        public StudentCourseDetailStatusEnum Status { get;  set; }
    }
}
