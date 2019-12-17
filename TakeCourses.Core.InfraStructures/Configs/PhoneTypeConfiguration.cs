using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class PhoneTypeConfiguration : IEntityTypeConfiguration<PhoneType>
    {
        public void Configure(EntityTypeBuilder<PhoneType> builder)
        {
            builder.ToTable("Tbl_PhoneType");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.PhoneTypeName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region SeedData

            builder.HasData(new PhoneType() { Id = 1, PhoneTypeName = "تلفن محل سکونت" },
                            new PhoneType() { Id = 2, PhoneTypeName = "تلفن محل کار" },
                            new PhoneType() { Id = 3, PhoneTypeName = "موبایل" },
                            new PhoneType() { Id = 4, PhoneTypeName = "فکس" });

            #endregion
        }
    }
}
