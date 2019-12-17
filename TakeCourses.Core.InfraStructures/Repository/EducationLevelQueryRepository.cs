using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class EducationLevelQueryRepository : IEducationLevelQueryRepository
    {
        private readonly ApplicationQueryDbContext dbContext;

        public EducationLevelQueryRepository(ApplicationQueryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EducationLevel GetEducationById(byte id)
        {
            return dbContext.EducationLevels
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public EducationLevel GetEducationByName(string levelname)
        {
            return dbContext.EducationLevels
                .AsNoTracking()
                .Where(x => x.LevelName ==levelname)
                .FirstOrDefault();
        }

        public List<EducationLevel> SearchEducationLevel(EducationLevelSearchDto educationLevel)
        {
            var Query = dbContext.EducationLevels.AsNoTracking().Where(x => string.IsNullOrEmpty(educationLevel.LevelName) || x.LevelName.Contains(educationLevel.LevelName))
                .Select(x => new EducationLevel() { Id = x.Id, LevelName = x.LevelName });

            List<EducationLevel> Result = new List<EducationLevel>();

            if (educationLevel.ShowPagingView)
            {
                Result = Query.Skip((educationLevel.Page - 1) * educationLevel.PageSize)
                    .Take(educationLevel.PageSize)
                    .ToList();
            }
            else            
                Result =Query.ToList();
            
            return Result;
        }
    }
}
