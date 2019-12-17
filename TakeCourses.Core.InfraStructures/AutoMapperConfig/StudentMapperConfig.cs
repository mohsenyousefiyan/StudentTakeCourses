using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Dtos.StudentDto;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.AutoMapperConfig
{
    public class StudentMapperConfig:Profile
    {
        public StudentMapperConfig()
        {
            CreateMap<StudentAddDto, User>();
            CreateMap<StudentAddDto, Student>();
            CreateMap<Student, StudentResultDto>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.User.PhoneNumbers))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.User.Addresses))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.User.BirthDate))
                .ForMember(dest => dest.FatherName, opt => opt.MapFrom(src => src.User.FatherName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.NationCode, opt => opt.MapFrom(src => src.User.NationCode));
        }
    }
}
