using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.TermCourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface ITermCourseService
    {
        /// <summary>
        /// لیست درس های ارائه شده مربوط به یک رشته خاص در یک ترم خاص را بر میگرداند
        /// </summary>        
        List<TermCourse> GetTermCourseByFieldId(TermCourseSearchDto model);
        
        /// <summary>
        /// برگرداندن یک واحد درسی ارائه شده یک ترم خاص بر حسب آی دی
        /// </summary>
        TermCourse GetTermCourseById(int id);
    }
}
