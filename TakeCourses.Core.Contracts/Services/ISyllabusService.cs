using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface ISyllabusService
    {
        /// <summary>
        /// چارت درسی ورودی یک رشته خاص را بر می گرداند 
        /// </summary>        
        List<Syllabus> GetSyllabusByFieldId(Int16 fieldid, DateTime enteringDate);
    }
}
