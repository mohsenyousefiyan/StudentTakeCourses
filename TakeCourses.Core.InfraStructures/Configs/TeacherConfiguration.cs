using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Tbl_Teacher");

            #region PropertyConfig


            builder.Property(x => x.EmploymentCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasIndex(x => x.EmploymentCode)
              .HasName("IX_EmpCode")
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

            builder.HasOne(x => x.EmploymentType)
              .WithMany()
              .HasForeignKey(x => x.EmploymentTypeId);

            #endregion
        }
    }
}
