using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.TermDto
{
    public class TermSearchDto: BaseSelectPageingDto
    {
        public string Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
