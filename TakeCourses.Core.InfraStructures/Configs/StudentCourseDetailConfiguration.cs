using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class StudentCourseDetailConfiguration : IEntityTypeConfiguration<StudentCourseDetail>
    {
        public void Configure(EntityTypeBuilder<StudentCourseDetail> builder)
        {
            builder.ToTable("Tbl_StudentCourseDetail");

            #region PropertyConfig


            builder.Property(x => x.Status)
                .HasMaxLength(50)
                .HasConversion(x => x.ToString(), x => (StudentCourseDetailStatusEnum)Enum.Parse(typeof(StudentCourseDetailStatusEnum), x))
                .IsUnicode(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.StudentCourse)
                .WithMany()
                .HasForeignKey(x => x.StudentCourseId);

            builder.HasOne(x => x.TermCourse)
               .WithMany()
               .HasForeignKey(x => x.TermCourseId);

            #endregion
        }
    }
}
