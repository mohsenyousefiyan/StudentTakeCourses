using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.TermCourseDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Services
{
    public class TermCourseService : ITermCourseService
    {
        private readonly ITermCourseQueryRepository queryRepository;

        public TermCourseService(ITermCourseQueryRepository queryRepository)
        {
            this.queryRepository = queryRepository;
        }
        public List<TermCourse> GetTermCourseByFieldId(TermCourseSearchDto model)
        {
            return queryRepository.GetTermCourseByFieldId(model);
        }

        public TermCourse GetTermCourseById(int id)
        {
            return queryRepository.GetTermCourseById(id);
        }
    }
}
