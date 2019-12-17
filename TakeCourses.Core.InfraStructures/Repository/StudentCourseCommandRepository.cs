using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.TakeCourseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class StudentCourseCommandRepository : IStudentCourseCommandRepository
    {
        private readonly ApplicationCommandDbContext dbcontextCommand;

        public StudentCourseCommandRepository(ApplicationCommandDbContext dbcontextCommand)
        {
            this.dbcontextCommand = dbcontextCommand;
        }

        public int StartStudentTakeCourse(StartTakeCourseDto model)
        {
            var addedItem = new StudentCourse() { StudentId = model.StudentId, TermId = model.TermId, LastEditDate = model.LastEditDate };
            dbcontextCommand.StudentCourses.Add(addedItem);
            dbcontextCommand.SaveChanges();
            return addedItem.Id;
        }

        public void TakeNewCourse(TakeNewCourseDto model)
        {
            var addedItem = new StudentCourseDetail()
            {
                StudentCourseId = model.StudentCourseId,
                TermCourseId = model.TermCourseId,
                Status = StudentCourseDetailStatusEnum.Taken,
                TakenDate = model.TakeDate
            };

            dbcontextCommand.StudentCourseDetails.Add(addedItem);
            dbcontextCommand.SaveChanges();
        }
    }
}
