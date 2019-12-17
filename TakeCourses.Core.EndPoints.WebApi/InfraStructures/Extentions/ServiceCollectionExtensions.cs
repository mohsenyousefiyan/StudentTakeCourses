using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeCourses.Core.Contracts.Repositories;
using TakeCourses.Core.Contracts.Services;
using TakeCourses.Core.Entities.Dtos.ConfigurationDto;
using TakeCourses.InfraStructures.DAL.SQL.Context;
using TakeCourses.InfraStructures.DAL.SQL.Repository;
using TakeCourses.InfraStructures.Tools.Helpers;
using TakeCourses.Core.Services;
using TakeCourses.EndPoints.WebApi.InfraStructures.ActionFilters;
using AutoMapper;

namespace TakeCourses.EndPoints.WebApi.InfraStructures.Extentions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterDbContext(this IServiceCollection services, string queryconstr,string commandconstr)
        {
            services.AddDbContextPool<ApplicationQueryDbContext>(option =>
            {
                option.UseSqlServer(queryconstr);
            });

            services.AddDbContextPool<ApplicationCommandDbContext>(option =>
            {
                option.UseSqlServer(commandconstr);
            });
        }
        public static void AddJwtAuthentication(this IServiceCollection services, JwtSettingsDto jwtSettings)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = StringHelper.StringToByteArray(jwtSettings.SecretKey);
                var encryptionkey = StringHelper.StringToByteArray(jwtSettings.Encryptkey);

                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero, // default: 5 min
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true, //default : false
                    ValidAudience = jwtSettings.Audience,

                    ValidateIssuer = true, //default : false
                    ValidIssuer = jwtSettings.Issuer,

                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
            });
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IEducationLevelService, EducationLevelService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IStudentTakeCoursesService,StudentTakeCoursesService>();
            services.AddScoped<ISyllabusService, SyllabusService>();
            services.AddScoped<ITermCourseService, TermCourseService>();
            services.AddScoped<CustomeAuthorizeActionFilterAttribute>();

        }
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IEducationLevelQueryRepository, EducationLevelQueryRepository>();
            services.AddTransient<IEducationLevelCommandRepository, EducationLevelCommandRepository>();
            services.AddTransient<ICourseQueryRepository, CourseQueryRepository>();
            services.AddTransient<IStudentCommandRepository, StudentCommandRepository>();
            services.AddTransient<IStudentQueryRepository, StudentQueryRepository>();
            services.AddTransient<ICourseCommandRepository, CourseCommandRepository>();
            services.AddTransient<ITermCourseQueryRepository, TermCourseQueryRepository>();
            services.AddTransient<ISyllabusQueryRepository, SyllabusQueryRepository>();
            services.AddTransient<IStudentCourseQueryRepository, StudentCourseQueryRepository>();
            services.AddTransient<IStudentCourseCommandRepository, StudentCourseCommandRepository>();
            services.AddTransient<IUserQueryRepository, UserQueryRepository>();
        }

        public static void RegisTerthirdParties(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup), typeof(ApplicationCommandDbContext));

            services.AddOpenApiDocument(option =>
            {
                option.Title = "University API";
                option.Version = "1";
            });
        }
    }
}
