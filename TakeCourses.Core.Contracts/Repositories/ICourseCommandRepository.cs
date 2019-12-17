using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface ICourseCommandRepository
    {
        Course AddCourse(CourseAddDto coursedto);
        Course EditCourse(Int16 id,CourseAddDto coursedto);
        bool DeleteCourse(Int16 id);
    }
}
