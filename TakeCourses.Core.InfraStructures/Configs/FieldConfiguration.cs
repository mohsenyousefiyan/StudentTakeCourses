using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class FieldConfiguration : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.ToTable("Tbl_Field");

            #region PropertyConfig

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.FieldName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasQueryFilter(x => x.IsDeleted == false);

            #endregion

            #region SeedData

            builder.HasData(new Field() { Id = 1, FieldName = "ریاضی" },
                            new Field() { Id = 2, FieldName = "کامپیوتر" },
                            new Field() { Id = 3, FieldName = "برق" },
                            new Field() { Id = 4, FieldName = "مخابرات" },
                            new Field() { Id = 5, FieldName = "الکترونیک" });

            #endregion
        }
    }
}
