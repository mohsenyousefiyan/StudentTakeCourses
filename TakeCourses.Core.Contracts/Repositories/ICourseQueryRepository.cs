using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface ICourseQueryRepository
    {
        Course GetCourseById(Int16 id);
        Course GetCourseByName(Int16 fieldid,string coursename);
        Course GetCourseByCode(string coursecode);
        List<Course> GetFieldCourseList(Int16 fieldid);
        List<Course> SearchCourse(CourseSearchDto courseSearch);
    }
}
