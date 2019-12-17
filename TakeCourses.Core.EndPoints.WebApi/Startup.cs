using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TakeCourses.EndPoints.WebApi.InfraStructures.Extentions;
using TakeCourses.Core.Entities.Dtos.ConfigurationDto;
using TakeCourses.InfraStructures.DAL.SQL.Context;
using AutoMapper;

using TakeCourses.EndPoints.WebApi.InfraStructures.ActionFilters;
using TakeCourses.Core.EndPoints.WebApi.InfraStructures.MiddleWares;

namespace TakeCourses.EndPoints.WebApi
{
    public class Startup
    {
        private readonly JwtSettingsDto JwtSettings;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettingsDto>();
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            var queryconstr = Configuration.GetConnectionString("ApplicationQueryConStr");
            var commandconstr = Configuration.GetConnectionString("ApplicationCommandConStr");

            services.Configure<JwtSettingsDto>(Configuration.GetSection("JwtSettings"));

            services.RegisterDbContext(queryconstr, commandconstr);
            services.RegisterRepositories();
            services.RegisterServices();
                       
            services.AddControllers()
            .AddMvcOptions(options =>
             {
                 options.Filters.Add<CustomFlatApiResultActionFilter>();
             });
            
            services.AddJwtAuthentication(JwtSettings);
            services.RegisTerthirdParties();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
           
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
