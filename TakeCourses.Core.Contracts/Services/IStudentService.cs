using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Contracts.Services
{
    public interface IStudentService
    {
        /// <summary>
        /// ایجاد دانشجوی جدید
        /// </summary>
        BaseResultModel<StudentResultDto> CreateNewStudent(StudentAddDto model);
        BaseResultModel<StudentResultDto> EditStudent(int id, StudentAddDto model);
        StudentResultDto GetStudentById(int id);
        StudentResultDto GetStudentByStdCode(string studentcode);
        StudentResultDto GetStudentByNationCode(string nationcode);
        List<StudentResultDto> SearchStudent(StudentSearchDto model);

        /// <summary>
        /// محاسبه تعداد واحدی که دانشجو پاس کرده است
        /// </summary>        
        byte GetStudentUnitPassedCount();


    }
}
