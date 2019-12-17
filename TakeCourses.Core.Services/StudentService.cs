using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.BaseDto;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;


namespace TakeCourses.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentQueryRepository queryRepository;
        private readonly IStudentCommandRepository commandRepository;

        public StudentService(IStudentQueryRepository queryRepository, IStudentCommandRepository commandRepository)
        {
            this.queryRepository = queryRepository;
            this.commandRepository = commandRepository;
        }
        public BaseResultModel<StudentResultDto> CreateNewStudent(StudentAddDto model)
        {
            var addedItem = GetStudentByStdCode(model.StudentCode);
            if (addedItem != null)
                return new BaseResultModel<StudentResultDto>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "شماره دانشجویی از قبل به ثبت رسیده است" };

            addedItem = GetStudentByNationCode(model.NationCode);
            if (addedItem != null)
                return new BaseResultModel<StudentResultDto>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "کد ملی از قبل به ثبت رسیده است" };

            addedItem = commandRepository.AddStudent(model);
            if(addedItem!=null)
                return new BaseResultModel<StudentResultDto>() { IsSuccess = true, Result = addedItem };
            
            return new BaseResultModel<StudentResultDto>() { IsSuccess = false, StatusCode = EnuResultStatusCode.LogicError };
        }

        public BaseResultModel<StudentResultDto> EditStudent(int id, StudentAddDto model)
        {
            if (GetStudentById(id) == null)
                return new BaseResultModel<StudentResultDto>() { StatusCode = EnuResultStatusCode.NotFound };

            var editedItem = GetStudentByStdCode(model.StudentCode);
            if (editedItem != null)
                if (editedItem.Id != id)
                    return new BaseResultModel<StudentResultDto>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "شماره دانشجویی  از قبل به ثبت رسیده است" };

            editedItem = GetStudentByNationCode(model.NationCode);
            if (editedItem != null)
                if (editedItem.Id != id)
                    return new BaseResultModel<StudentResultDto>() { StatusCode = EnuResultStatusCode.LogicError, ErrorMessage = "کد ملی از قبل به ثبت رسیده است" };


            editedItem = commandRepository.EditStudent(id, model);
            return new BaseResultModel<StudentResultDto>() { IsSuccess = true, Result = editedItem };
        }

        public StudentResultDto  GetStudentById(int id)
        {
            return queryRepository.GetStudenteById(id);
        }

        public StudentResultDto GetStudentByNationCode(string nationcode)
        {
            return queryRepository.GetStudenteByNationCode(nationcode);
        }

        public StudentResultDto GetStudentByStdCode(string studentcode)
        {
            return queryRepository.GetStudenteByStudentCode(studentcode);
        }

        public byte GetStudentUnitPassedCount()
        {
            throw new NotImplementedException();
        }

        public List<StudentResultDto> SearchStudent(StudentSearchDto model)
        {
            return queryRepository.SearchStudente(model);
        }
    }
}
