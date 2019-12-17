using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class Teacher:BaseEntity<int>
    {       
        public int UserId { get; set; }
        public User User { get; set; }       
        public Int16 FieldId { get; set; }
        public Field Field { get; set; }
        public byte EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public string EmploymentCode { get; set; }
        public DateTime EmploymentDate { get; set; }
        public byte EmploymentTypeId { get; set; }
        public EmploymentType EmploymentType { get; set; }
    }
}
