using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class TermConfiguration : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.ToTable("Tbl_Term");

            #region PropertyConfig


            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();          

            builder.HasQueryFilter(x => x.IsDeleted == false);
          
            #endregion
        }
    }
}
