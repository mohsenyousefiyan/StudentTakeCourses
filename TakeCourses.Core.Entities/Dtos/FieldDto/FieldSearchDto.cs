using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.FieldDto
{
    public class FieldSearchDto: BaseSelectPageingDto
    {
        public string FieldCode { get; set; }
        public string FieldName { get; set; }
    }
}
