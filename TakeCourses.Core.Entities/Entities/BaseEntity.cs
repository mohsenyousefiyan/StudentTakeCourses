using System;
using System.Collections.Generic;
using System.Text;

namespace TakeCourses.Core.Entities.Entities
{
    public class BaseEntity<T> where T: unmanaged
    {
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
