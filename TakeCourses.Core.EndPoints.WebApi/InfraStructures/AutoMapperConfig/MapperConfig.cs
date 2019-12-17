using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Entities.Dtos.CourseDto;
using TakeCourses.Core.Entities.Dtos.EducationLevelDto;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.EndPoints.WebApi.ViewModels.CourseViewModel;
using TakeCourses.EndPoints.WebApi.ViewModels.EducationLevelViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.StudentViewModels;
using TakeCourses.EndPoints.WebApi.ViewModels.UserViewModels;

namespace TakeCourses.EndPoints.WebApi.InfraStructures.AutoMapperConfig
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<EducationLevelSearchViewModel, EducationLevelSearchDto>();
            CreateMap<CourseSearchViewModel, CourseSearchDto>();
            CreateMap<CourseAddViewModel, CourseAddDto>();
            CreateMap<StudentSearchViewModel, StudentSearchDto>();
            CreateMap<StudentAddViewModel, StudentAddDto>();
            CreateMap<User, UserLoginResultViewModel>();
        }
    }
}
