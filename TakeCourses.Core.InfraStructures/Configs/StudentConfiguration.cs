using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Tbl_Student");

            #region PropertyConfig
         

            builder.Property(x => x.StudentCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();          

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasIndex(x => x.StudentCode)
                .HasName("IX_StdCode")
                .IsUnique();

            #endregion

            #region RelationConfig

            builder.HasOne(x => x.Field)
                .WithMany()
                .HasForeignKey(x => x.FieldId);

            builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.EducationLevel)
               .WithMany()
               .HasForeignKey(x => x.EducationLevelId);

            #endregion
        }
    }
}
