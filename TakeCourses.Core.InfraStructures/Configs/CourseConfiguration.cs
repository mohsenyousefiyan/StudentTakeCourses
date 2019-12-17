using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Tbl_Course");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.CourseCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.CourseName)
                .HasMaxLength(50)               
                .IsRequired();


            builder.Property(x => x.UnitType)
               .HasMaxLength(50)
               .HasConversion(x => x.ToString(), x => (CourseUnitType)Enum.Parse(typeof(CourseUnitType), x))
               .IsUnicode(false);


            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.Field)
                .WithMany()
                .HasForeignKey(x => x.FieldId);

            #endregion
        }
    }
}
