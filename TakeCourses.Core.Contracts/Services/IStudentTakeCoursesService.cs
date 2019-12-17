using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.TakeCourseDto;

namespace TakeCourses.Core.Contracts.Services
{
    public interface IStudentTakeCoursesService    
    {     
        /// <summary>
        /// آغاز عملیات انتخاب واحد و درج رکورد مستر
        /// </summary>
        BaseResultModel<int> StartTakeCourse(StartTakeCourseDto model);
        
        /// <summary>
        /// اخذ یک واحد درسی برای یک دانشجو در ترم مشخص شده
        /// </summary>        
        BaseResultModel TakeNewCourse(TakeNewCourseDto model);
        
        /// <summary>
        ///بررسی می کند واحد های انتخاب شده توسط یک دانشجو تداخل زمانی امتحانی پیش نیاز و .. نداشته باشند
        /// </summary>       
        BaseResultModel<List<string>> ProcessStudentTakeCourse(int studentcourseid);

        /// <summary>
        /// وضعیت انتخاب واحد دانشجو را تایید نهایی می کند
        /// </summary>
        bool ConfirmedStudentTakeCourse(int studentcourseid);
    }
}
