using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Dtos.BaseDto
{
    public class BaseSelectPageingDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public Boolean ShowPagingView { get; set; } = false;
        public int? UserId { get; set; }
    }
}
