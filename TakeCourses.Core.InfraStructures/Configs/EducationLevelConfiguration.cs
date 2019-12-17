using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.ToTable("Tbl_EducationLevel");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x =>x.LevelName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region SeedData

            builder.HasData(new EducationLevel() { Id = 1, LevelName = "دیپلم" },
                            new EducationLevel() { Id = 2, LevelName = "کاردانی" },
                            new EducationLevel() { Id = 3, LevelName = "کارشناسی" },
                            new EducationLevel() { Id = 4, LevelName = "کارشناسی ارشد" },
                            new EducationLevel() { Id = 5, LevelName = "دکتری" });

            #endregion
        }
    }
}
