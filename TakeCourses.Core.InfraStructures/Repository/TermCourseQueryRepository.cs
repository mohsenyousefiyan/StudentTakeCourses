using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.TermCourseDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class TermCourseQueryRepository : ITermCourseQueryRepository
    {
        private readonly ApplicationQueryDbContext queryDbContext;

        public TermCourseQueryRepository(ApplicationQueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }
        public List<TermCourse> GetTermCourseByFieldId(TermCourseSearchDto model)
        {
            var Query = queryDbContext.TermCourses.AsNoTracking()
                .Where(x => x.TermId == model.TermId && x.Course.FieldId == model.FieldId)
                .OrderBy(x=>x.Course.CourseCode);

            List<TermCourse> Result = new List<TermCourse>();

            if (model.ShowPagingView)
            {
                Result = Query.Skip((model.Page - 1) * model.PageSize)
                    .Take(model.PageSize)
                    .ToList();
            }
            else
                Result = Query.ToList();

            return Result;
        }

        public TermCourse GetTermCourseById(int id)
        {
            return queryDbContext.TermCourses.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
