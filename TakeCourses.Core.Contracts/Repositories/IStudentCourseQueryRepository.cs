using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IStudentCourseQueryRepository
    {
        /// <summary>
        /// تعداد دانشجویانی که در یک درس ثبت نام کرده اند را بر می گرداند
        /// </summary>        
        int GetStudentCountOfTakeCourse(int termcourseid);
        
        /// <summary>
        ///  بررسی می کند دانشجو در این ترم این درس را یکبار ثبت کرده یا نه 
        /// </summary>
        bool IsStudentTakeaCourse(int studentcourseid, int termcourseid);
        
        /// <summary>
        /// در صورتی که رکورد مستر انتخاب واحد برای یک دانشجو در یک ترم خاص ثبت شده باشد ان را بر می گرداند
        /// </summary>        
        StudentCourse GetStudentCourseByTermId(int studentid, int termid);
        
        StudentCourse GetStudentCourseById(int studentcourseid);

        /// <summary>
        /// برگرداندن  لیست درس های اخذ شده توسط یک دانشجو در یک ترم خاص
        /// </summary>
        List<StudentCourseDetail> GetStudentCourseDetail(int studentcourseid);

        /// <summary>
        /// مشخص می کند یک دانشجو چند واحد پاس کرده است
        /// </summary>        
        Int16 GetStudentUnitPassedCount(int studentid);
    }
}
