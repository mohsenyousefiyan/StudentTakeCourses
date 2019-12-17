using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.Core.Entities.Enums;
using TakeCourses.InfraStructures.Tools.Helpers;

namespace TakeCourses.InfraStructures.DAL.SQL.Configs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Tbl_User");

            #region PropertyConfig
           

            builder.Property(x => x.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NationCode)
                .HasMaxLength(10)
                .IsFixedLength()
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.FatherName)
                .HasMaxLength(30);
               
            builder.Property(x => x.UserName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)                
                .IsRequired();

            builder.Property(x => x.Addresses)
                .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<Address>>(x));

            builder.Property(x => x.PhoneNumbers)
                .HasConversion(x => JsonConvert.SerializeObject(x), x => JsonConvert.DeserializeObject<List<PhoneNumber>>(x));

            builder.Property(x => x.UserGroup)
               .HasMaxLength(50)
               .HasConversion(x => x.ToString(), x => (UserGroup)Enum.Parse(typeof(UserGroup), x))
               .IsUnicode(false);

            builder.HasQueryFilter(x => x.IsDeleted == false);

            builder.HasIndex(x => x.NationCode)
                .HasName("IX_NationCode")
                .IsUnique();

            builder.HasIndex(x => x.UserName)
                .HasName("IX_UserName");


            #endregion

            #region SeedData

            builder.HasData(new User()
            {
                Id = 1,
                FirstName = "Mohsen",
                LastName = "Yousefiyan",
                BirthDate = Convert.ToDateTime("1987/05/09"),
                UserGroup = UserGroup.Admin,
                NationCode = "1190005646",
                IsActive = true,
                UserName = "mohsen",
                Password = SecurityHelper.SHA256_Hash("123456")
            });

            #endregion
        }
    }
}
