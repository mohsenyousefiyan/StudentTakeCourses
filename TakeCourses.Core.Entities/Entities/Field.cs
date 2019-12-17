using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class Field:BaseEntity<Int16>
    {
        public string FieldCode { get; set; }
        public string FieldName { get; set; }
    }
}
