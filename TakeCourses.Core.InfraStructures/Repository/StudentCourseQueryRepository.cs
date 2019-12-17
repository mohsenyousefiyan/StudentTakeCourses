using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class StudentCourseQueryRepository : IStudentCourseQueryRepository
    {
        private readonly ApplicationQueryDbContext queryDbContext;

        public StudentCourseQueryRepository(ApplicationQueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }

        public int GetStudentCountOfTakeCourse(int termcourseid)
        {
            var query = from stdcourse in queryDbContext.StudentCourses
                        join stdcoursedetail in queryDbContext.StudentCourseDetails on stdcourse.Id equals stdcoursedetail.StudentCourseId
                        where stdcourse.RegisterStatus == StudentCourseStatusEnum.Confirmed && stdcoursedetail.TermCourseId == termcourseid
                        select new { stdcoursedetail.Id };
            return query.Count();            
        }

        public StudentCourse GetStudentCourseById(int studentcourseid)
        {
            return queryDbContext.StudentCourses.AsNoTracking()
                .Include(y=>y.Student)
                .Where(x => x.Id == studentcourseid)
                .FirstOrDefault();
        }

        public StudentCourse GetStudentCourseByTermId(int studentid, int termid)
        {
            return queryDbContext.StudentCourses
                .AsNoTracking()
                .Where(x => x.StudentId == studentid && x.TermId == termid)
                .FirstOrDefault();
        }

        public List<StudentCourseDetail> GetStudentCourseDetail(int studentcourseid)
        {
            return queryDbContext.StudentCourseDetails
                .Include(y=>y.TermCourse)
                .ThenInclude(z=>z.Course)
                .AsNoTracking()
                .Where(x => x.StudentCourseId == studentcourseid)
                .ToList();            
        }

        public Int16 GetStudentUnitPassedCount(int studentid)
        {
            var query = from stdcourse in queryDbContext.StudentCourses
                     join stdcoursedetail in queryDbContext.StudentCourseDetails on stdcourse.Id equals stdcoursedetail.StudentCourseId
                     where (stdcourse.StudentId==studentid )&&
                     (stdcourse.RegisterStatus==StudentCourseStatusEnum.Confirmed )&&
                     (stdcoursedetail.Status==StudentCourseDetailStatusEnum.Passed)&&
                     (stdcoursedetail.Grade>=10)
                     select new { stdcoursedetail.TermCourse.Course.UnitCount};

            return Convert.ToInt16(query.Sum(x=>x.UnitCount));
        }

        public bool IsStudentTakeaCourse(int studentcourseid, int termcourseid)
        {
            return queryDbContext.
                StudentCourseDetails
                .AsNoTracking()
                .Any(x => x.StudentCourseId == studentcourseid && x.TermCourseId==termcourseid);
        }

        //public bool IsStudentTakeaCourse(int studentid, int termcourseid)
        //{
        //    var query = from stdcourse in queryDbContext.StudentCourses
        //                join stdcoursedetail in queryDbContext.StudentCourseDetails on stdcourse.Id equals stdcoursedetail.StudentCourseId
        //                where stdcourse.StudentId==studentid && stdcoursedetail.TermCourseId == termcourseid
        //                select new { stdcoursedetail.Id };

        //    return query.Count() > 0 ? true : false;           
        //}
    }
}
