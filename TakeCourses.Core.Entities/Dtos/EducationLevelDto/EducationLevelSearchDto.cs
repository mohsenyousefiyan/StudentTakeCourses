using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.EducationLevelDto
{
    public class EducationLevelSearchDto: BaseSelectPageingDto
    {
        public string LevelName { get; set; }
    }
}
