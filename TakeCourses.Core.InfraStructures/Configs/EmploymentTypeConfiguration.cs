using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class EmploymentTypeConfiguration : IEntityTypeConfiguration<EmploymentType>
    {
        public void Configure(EntityTypeBuilder<EmploymentType> builder)
        {
            builder.ToTable("Tbl_EmploymentType");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.EmploymentTypeName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region SeedData

            builder.HasData(new EmploymentType() { Id = 1, EmploymentTypeName = "هیئت علمی رسمی" },
                            new EmploymentType() { Id = 2, EmploymentTypeName = "هیئت علمی پیمانی" },
                            new EmploymentType() { Id = 3, EmploymentTypeName = "رسمی" },
                            new EmploymentType() { Id = 4, EmploymentTypeName = "پیمانی" });

            #endregion
        }
    }
}
