using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.ToTable("Tbl_Syllabus");

            #region PropertyConfig
           
            builder.Property(x => x.NeededCourses)
                .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<Course>>(x));

            builder.Property(x => x.PrerequisiteCourses)
                .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<Course>>(x));

            builder.Property(x => x.TermOrder)
               .HasMaxLength(50)
               .HasConversion(x => x.ToString(), x => (TermOrder)Enum.Parse(typeof(TermOrder), x))
               .IsUnicode(false);

            builder.Property(x => x.Categury)
              .HasMaxLength(50)
              .HasConversion(x => x.ToString(), x => (Categury)Enum.Parse(typeof(Categury), x))
              .IsUnicode(false);


            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId);
            
            #endregion
        }
    }
}
