using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class PhoneType:BaseEntity<byte>
    {      
        public string PhoneTypeName { get; set; }
    }
}
