using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.TakeCourseDto;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IStudentCourseCommandRepository
    {
        /// <summary>
        /// شروع عملیات انتخاب واحد و درج رکورد مستر
        /// </summary>
        int StartStudentTakeCourse(StartTakeCourseDto model);
        
        /// <summary>
        /// ثبت یک واحد درسی برای یک دانشجو
        /// </summary>        
        void TakeNewCourse(TakeNewCourseDto model);
    }
}
