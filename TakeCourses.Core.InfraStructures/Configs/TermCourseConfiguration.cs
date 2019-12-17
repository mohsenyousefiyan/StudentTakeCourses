using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class TermCourseConfiguration : IEntityTypeConfiguration<TermCourse>
    {
        public void Configure(EntityTypeBuilder<TermCourse> builder)
        {
            builder.ToTable("Tbl_TermCourse");

            #region PropertyConfig

            builder.Property(x => x.PresentationDays)
               .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<PresentationDay>>(x))
               .IsRequired();

            builder.Property(x => x.TestDate)
              .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<TestDate>(x))
              .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.Course)
                .WithMany()
                .HasForeignKey(x => x.CourseId)
                 .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(x => x.Teacher)
               .WithMany()
               .HasForeignKey(x => x.TeacherId)
               .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(x => x.Term)
               .WithMany()
               .HasForeignKey(x => x.TermId)
                .OnDelete(DeleteBehavior.NoAction); 

            #endregion
        }
    }
}
