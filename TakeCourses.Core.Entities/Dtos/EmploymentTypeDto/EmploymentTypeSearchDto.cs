using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.EmploymentTypeDto
{
    public class EmploymentTypeSearchDto: BaseSelectPageingDto
    {
        public string EmploymentTypeName { get; set; }
    }
}
