using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;

namespace TakeCourses.Core.Entities.Dtos.AddressType
{
    public class AddressTypeSearchDto: BaseSelectPageingDto
    {
        public string AddressTypeName { get; set; }
    }
}
