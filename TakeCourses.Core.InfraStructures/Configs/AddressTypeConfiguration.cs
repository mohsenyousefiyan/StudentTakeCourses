using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<AddressType>
    {
        public void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.ToTable("Tbl_AddressType");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.AddressTypeName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region SeedData

            builder.HasData(new AddressType() { Id = 1, AddressTypeName = "محل سکونت" },
                            new AddressType() { Id = 2, AddressTypeName = "محل کار" },
                            new AddressType() { Id = 3,AddressTypeName = "محل تحصیل"});

            #endregion
        }
    }
}
