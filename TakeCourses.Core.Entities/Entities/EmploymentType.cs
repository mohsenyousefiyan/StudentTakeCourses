using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    /// <summary>
    /// نوع استخدامی اساتید
    /// </summary>
    public class EmploymentType:BaseEntity<byte>
    {      
        public string EmploymentTypeName { get; set; }
    }
}
