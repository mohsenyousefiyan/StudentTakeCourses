using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.StudentDto
{
    public class StudentSearchDto: BaseSelectPageingDto
    {
        public string FullName { get; set; }
        public string NationCode { get; set; }
        public string StudentCode { get; set; }
        public Int16? FieldId { get; set; }
        public DateTime? StartEnteringDate { get; set; }
        public DateTime? EndEnteringDate { get; set; }
    }
}
