using AutoMapper;
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
    public class CourseCommandRepository : ICourseCommandRepository
    {
        private readonly ApplicationCommandDbContext dbContext;
        private readonly IMapper mapper;

        public CourseCommandRepository(ApplicationCommandDbContext dbContext,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public Course AddCourse(CourseAddDto coursedto)
        {            
            var addedItem = mapper.Map<Course>(coursedto);
            dbContext.Courses.Add(addedItem);
            dbContext.SaveChanges();
            dbContext.Entry(addedItem).Reference(x => x.Field).Load();
            return addedItem;
        }

        public bool DeleteCourse(Int16 id)
        {
            try
            {
                var deleted = dbContext.Courses.FirstOrDefault(x => x.Id == id);
                dbContext.Courses.Remove(deleted);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Course EditCourse(short id, CourseAddDto coursedto)
        {
            var editedItem = dbContext.Courses.Where(x => x.Id == id).FirstOrDefault();
            if (editedItem != null)
            {
                editedItem.CourseCode = coursedto.CourseCode;
                editedItem.CourseName = coursedto.CourseName;
                editedItem.UnitCount = coursedto.UnitCount;
                editedItem.UnitType = coursedto.UnitType;

                dbContext.Courses.Update(editedItem);
                dbContext.SaveChanges();
                dbContext.Entry(editedItem).Reference(x => x.Field).Load();
            }

            return editedItem;
        }
    }
}
