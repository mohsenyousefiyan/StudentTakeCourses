using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class Student:BaseEntity<int>
    {     
        public int UserId { get; set; }
        public User User { get; set; }
        public string StudentCode { get; set; }
        public Int16 FieldId { get; set; }
        public Field Field { get; set; }
        public byte EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public DateTime EnteringDate { get; set; }
        public DateTime? GraduationDate { get; set; }
    }
}
