using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class SyllabusQueryRepository : ISyllabusQueryRepository
    {
        private readonly ApplicationQueryDbContext queryDbContext;

        public SyllabusQueryRepository(ApplicationQueryDbContext queryDbContext)
        {
            this.queryDbContext = queryDbContext;
        }
        public List<Syllabus> GetSyllabusByFieldId(short fieldid, DateTime enteringDate)
        {
            return queryDbContext.Syllabus.AsNoTracking()
                .Include(y => y.Course)
                .Where(x => x.Course.FieldId == fieldid && (x.ApplyStartEnteringDate.Date >= enteringDate.Date && (x.ApplyEndEnteringDate.HasValue == false || x.ApplyEndEnteringDate.Value.Date <= enteringDate.Date)))                
                .ToList();
        }
    }
}
