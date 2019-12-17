using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.TermCourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface ITermCourseQueryRepository
    {
        List<TermCourse> GetTermCourseByFieldId(TermCourseSearchDto model);
        TermCourse GetTermCourseById(int id);
    }
}
