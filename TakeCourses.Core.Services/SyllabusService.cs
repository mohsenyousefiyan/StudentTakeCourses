using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.Core.Services
{
    public class SyllabusService : ISyllabusService
    {
        private readonly ISyllabusQueryRepository syllabusQueryRepository;

        public SyllabusService(ISyllabusQueryRepository syllabusQueryRepository)
        {
            this.syllabusQueryRepository = syllabusQueryRepository;
        }

        public List<Syllabus> GetSyllabusByFieldId(short fieldid, DateTime enteringDate)
        {
            return syllabusQueryRepository.GetSyllabusByFieldId(fieldid, enteringDate);
        }
    }
}
