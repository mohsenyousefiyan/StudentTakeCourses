using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;


namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class StudentQueryRepository : IStudentQueryRepository
    {
        private readonly ApplicationQueryDbContext dbContext;
        private readonly IMapper mapper;

        public StudentQueryRepository(ApplicationQueryDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public StudentResultDto GetStudenteById(int id)
        {
            return mapper.Map<StudentResultDto>( dbContext.Students
                 .AsNoTracking()
                 .Where(x => x.Id == id)
                 .FirstOrDefault());
        }

        public StudentResultDto GetStudenteByNationCode(string NationCode)
        {
            return mapper.Map<StudentResultDto>(dbContext.Students
                 .AsNoTracking()
                 .Where(x => x.User.NationCode == NationCode)
                 .FirstOrDefault());
        }

        public StudentResultDto GetStudenteByStudentCode(string studentcode)
        {
            return mapper.Map<StudentResultDto>( dbContext.Students
                 .AsNoTracking()
                 .Where(x => x.StudentCode == studentcode)
                 .FirstOrDefault());
        }

        public List<StudentResultDto> SearchStudente(StudentSearchDto StudenteSearch)
        {
            var Query = dbContext.Students.AsNoTracking().Where(x => (string.IsNullOrEmpty(StudenteSearch.FullName) || (x.User.FirstName+" "+x.User.LastName).Contains(StudenteSearch.FullName)) &&
            (string.IsNullOrEmpty(StudenteSearch.StudentCode) || x.StudentCode.Contains(StudenteSearch.StudentCode))&&
            (string.IsNullOrEmpty(StudenteSearch.NationCode) || x.User.NationCode.Contains(StudenteSearch.NationCode)) &&
            (StudenteSearch.FieldId.HasValue==false || x.FieldId==StudenteSearch.FieldId.Value)&&
            (StudenteSearch.StartEnteringDate.HasValue == false || x.EnteringDate.Date>= StudenteSearch.StartEnteringDate.Value.Date) &&
            (StudenteSearch.EndEnteringDate.HasValue == false || x.EnteringDate.Date <= StudenteSearch.EndEnteringDate.Value.Date)
            )
            .Select(x=>new StudentResultDto()
            {
                Id=x.Id,
                FirstName=x.User.FirstName,
                LastName=x.User.LastName,
                StudentCode=x.StudentCode,
                NationCode=x.User.NationCode,
                BirthDate=x.User.BirthDate,
                FatherName=x.User.FatherName,
                FieldId=x.FieldId,
                Field=x.Field,
                Addresses=x.User.Addresses,
                PhoneNumbers=x.User.PhoneNumbers,
                EducationLevel=x.EducationLevel,
                EducationLevelId=x.EducationLevelId,
                EnteringDate=x.EnteringDate,
                GraduationDate=x.GraduationDate 
            }).OrderBy(x => x.StudentCode);

            List<StudentResultDto> Result = new List<StudentResultDto>();

            if (StudenteSearch.ShowPagingView)
            {
                Result = Query.Skip((StudenteSearch.Page - 1) * StudenteSearch.PageSize)
                    .Take(StudenteSearch.PageSize)
                    .ToList();
            }
            else
                Result = Query.ToList();

            return Result;
        }
       
    }
}
