using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.InfraStructures.DAL.SQL.Context;
using TakeCourses.InfraStructures.Tools.Helpers;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class StudentCommandRepository : IStudentCommandRepository
    {
        private readonly ApplicationCommandDbContext dbContext;
        private readonly IMapper mapper;

        public StudentCommandRepository(ApplicationCommandDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public StudentResultDto AddStudent(StudentAddDto model)
        {
            var user = mapper.Map<User>(model);
            user.IsActive = true;
            user.UserName = model.StudentCode;
            user.Password = SecurityHelper.SHA256_Hash(model.NationCode);
            user.UserGroup = UserGroup.Student;
            var student = mapper.Map<Student>(model);

            using (var dbtran = dbContext.Database.BeginTransaction())
            {
                try
                {
                    dbContext.Users.Add(user);                   
                    student.User = user;
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    dbContext.Entry(student).Reference(x => x.Field).Load();
                    dbContext.Entry(student).Reference(x => x.EducationLevel).Load();
                    dbtran.Commit();                    
                }
                catch(Exception ex)
                {
                    dbtran.Rollback();
                    return null;
                }
            }
            return mapper.Map<StudentResultDto>(student);
        }

        public StudentResultDto EditStudent(int id, StudentAddDto model)
        {
            throw new NotImplementedException();
        }
    }
}
