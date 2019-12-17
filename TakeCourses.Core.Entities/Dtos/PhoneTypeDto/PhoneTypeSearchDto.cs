using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.PhoneTypeDto
{
   public  class PhoneTypeSearchDto: BaseSelectPageingDto
    {
        public string PhoneTypeName { get; set; }
    }
}
