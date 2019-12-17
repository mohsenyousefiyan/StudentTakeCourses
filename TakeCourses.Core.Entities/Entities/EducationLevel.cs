using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    //میزان تحصیلات دانشجویان و اساتید
    public class EducationLevel:BaseEntity<byte>
    {       
        public string LevelName { get; set; }
    }
}
