using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface ICourseService
    {
        BaseResultModel<Course> CreateNewCourse(CourseAddDto model);
        BaseResultModel<Course> EditCourse(Int16 id, CourseAddDto model);
        BaseResultModel DeleteCourse(Int16 id);
        Course GetCourseById(Int16 id);
        Course GetCourseByCode(string coursecode);
        Course GetCourseByName(Int16 fieldid,string coursename);
        List<Course> SearchCourse(CourseSearchDto model);
        List<Course> GetFieldCourseList(Int16 fieldid);
    }
}
