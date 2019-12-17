using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Repositories
{
    public interface IStudentQueryRepository
    {
        StudentResultDto GetStudenteById(Int32 id);
        StudentResultDto GetStudenteByStudentCode(string studentcode);
        StudentResultDto GetStudenteByNationCode(string NationCode);        
        List<StudentResultDto> SearchStudente(StudentSearchDto StudenteSearch);       

    }
}
