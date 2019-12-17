
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.AutoMapperConfig
{
    public class CourseMapperConfig:Profile
    {
        public CourseMapperConfig()
        {
            CreateMap<CourseAddDto,Course>();
           
        }
    }
}
