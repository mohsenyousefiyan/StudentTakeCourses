using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class AddressType:BaseEntity<byte>
    {    
        public string AddressTypeName { get; set; }
    }
}
