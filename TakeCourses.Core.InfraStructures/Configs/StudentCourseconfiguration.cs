using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("Tbl_StudentCourse");

            #region PropertyConfig


            builder.Property(x => x.RegisterStatus)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(), x => (StudentCourseStatusEnum)Enum.Parse(typeof(StudentCourseStatusEnum), x))
                .IsUnicode(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);           

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x.Term)
               .WithMany()
               .HasForeignKey(x => x.TermId);          

            #endregion
        }
    }
}
