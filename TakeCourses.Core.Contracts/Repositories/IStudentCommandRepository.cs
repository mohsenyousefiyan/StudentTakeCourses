using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
   public interface IStudentCommandRepository
    {
        StudentResultDto AddStudent(StudentAddDto model);
        StudentResultDto EditStudent(Int32 id, StudentAddDto model);        
    }
}
