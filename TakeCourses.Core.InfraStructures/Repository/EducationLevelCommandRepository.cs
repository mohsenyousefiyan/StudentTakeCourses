using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Repository
{
    public class EducationLevelCommandRepository : IEducationLevelCommandRepository
    {
        private readonly ApplicationCommandDbContext dbContext;

        public EducationLevelCommandRepository(ApplicationCommandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public EducationLevel AddEducationLevel(string levelname)
        {
            var addedItem = new EducationLevel() { LevelName = levelname };
            dbContext.EducationLevels.Add(addedItem);
            dbContext.SaveChanges();
            return addedItem;
        }

        public bool DeleteEducationLevel(byte id)
        {
            try
            {
                var deleted = dbContext.EducationLevels.FirstOrDefault(x => x.Id == id);
                dbContext.EducationLevels.Remove(deleted);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public EducationLevel EditEducationLevel(byte id, string levelname)
        {
            var editedItem = dbContext.EducationLevels.Where(x => x.Id == id).FirstOrDefault();
            if(editedItem!=null)
            {
                editedItem.LevelName = levelname;
                dbContext.EducationLevels.Update(editedItem);
                dbContext.SaveChanges();
            }

            return editedItem;
        }
    }
}
