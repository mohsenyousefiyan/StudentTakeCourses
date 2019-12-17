using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class CourseQueryRepository : ICourseQueryRepository
    {
        private readonly ApplicationQueryDbContext dbContext;

        public CourseQueryRepository(ApplicationQueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Course GetCourseByCode(string coursecode)
        {
            return dbContext.Courses
                  .AsNoTracking()
                  .Where(x =>  x.CourseCode==coursecode)
                  .FirstOrDefault();
        }

        public Course GetCourseById(Int16 id)
        {
            return dbContext.Courses
               .AsNoTracking()
               .Where(x => x.Id == id)
               .FirstOrDefault();
        }

        public Course GetCourseByName(Int16 fieldid, string coursename)
        {
            return dbContext.Courses
                 .AsNoTracking()
                 .Where(x => x.CourseName == coursename && x.FieldId==fieldid)
                 .FirstOrDefault();
        }

        public List<Course> GetFieldCourseList(Int16 fieldid)
        {
            return dbContext.Courses
                  .AsNoTracking()
                  .Where(x =>  x.FieldId == fieldid)
                  .ToList();
        }

        public List<Course> SearchCourse(CourseSearchDto courseSearch)
        {
            var Query = dbContext.Courses.AsNoTracking().Where(x => (string.IsNullOrEmpty(courseSearch.CourseCode) || x.CourseCode.Contains(courseSearch.CourseCode)) &&
            (string.IsNullOrEmpty(courseSearch.CourseName) || x.CourseName.Contains(courseSearch.CourseName)));               

            List<Course> Result = new List<Course>();

            if (courseSearch.ShowPagingView)
            {
                Result = Query.Skip((courseSearch.Page - 1) * courseSearch.PageSize)
                    .Take(courseSearch.PageSize)
                    .ToList();
            }
            else
                Result = Query.ToList();

            return Result;
        }
    }
}
