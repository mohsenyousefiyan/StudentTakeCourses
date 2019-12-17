using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.Core.Entities.Entities
{
    public class Course:BaseEntity<Int16>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public Int16 FieldId { get; set; }
        public Field Field { get; set; }
        public byte UnitCount { get; set; }
        public CourseUnitType UnitType { get; set; }        
    }
}
