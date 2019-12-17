﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TakeCourses.InfraStructures.DAL.SQL.Context;

namespace TakeCourses.InfraStructures.DAL.SQL.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20191217134427_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.AddressType", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tbl_AddressType");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            AddressTypeName = "محل سکونت",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (byte)2,
                            AddressTypeName = "محل کار",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (byte)3,
                            AddressTypeName = "محل تحصیل",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Course", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<short>("FieldId")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<byte>("UnitCount")
                        .HasColumnType("tinyint");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Tbl_Course");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.EducationLevel", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LevelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tbl_EducationLevel");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            IsDeleted = false,
                            LevelName = "دیپلم"
                        },
                        new
                        {
                            Id = (byte)2,
                            IsDeleted = false,
                            LevelName = "کاردانی"
                        },
                        new
                        {
                            Id = (byte)3,
                            IsDeleted = false,
                            LevelName = "کارشناسی"
                        },
                        new
                        {
                            Id = (byte)4,
                            IsDeleted = false,
                            LevelName = "کارشناسی ارشد"
                        },
                        new
                        {
                            Id = (byte)5,
                            IsDeleted = false,
                            LevelName = "دکتری"
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.EmploymentType", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmploymentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tbl_EmploymentType");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            EmploymentTypeName = "هیئت علمی رسمی",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (byte)2,
                            EmploymentTypeName = "هیئت علمی پیمانی",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (byte)3,
                            EmploymentTypeName = "رسمی",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (byte)4,
                            EmploymentTypeName = "پیمانی",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Field", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FieldCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Tbl_Field");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            FieldName = "ریاضی",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (short)2,
                            FieldName = "کامپیوتر",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (short)3,
                            FieldName = "برق",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (short)4,
                            FieldName = "مخابرات",
                            IsDeleted = false
                        },
                        new
                        {
                            Id = (short)5,
                            FieldName = "الکترونیک",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.PhoneType", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PhoneTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tbl_PhoneType");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            IsDeleted = false,
                            PhoneTypeName = "تلفن محل سکونت"
                        },
                        new
                        {
                            Id = (byte)2,
                            IsDeleted = false,
                            PhoneTypeName = "تلفن محل کار"
                        },
                        new
                        {
                            Id = (byte)3,
                            IsDeleted = false,
                            PhoneTypeName = "موبایل"
                        },
                        new
                        {
                            Id = (byte)4,
                            IsDeleted = false,
                            PhoneTypeName = "فکس"
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("EducationLevelId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("EnteringDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("FieldId")
                        .HasColumnType("smallint");

                    b.Property<DateTime?>("GraduationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("FieldId");

                    b.HasIndex("StudentCode")
                        .IsUnique()
                        .HasName("IX_StdCode");

                    b.HasIndex("UserId");

                    b.ToTable("Tbl_Student");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.StudentCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastEditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegisterStatus")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TermId");

                    b.ToTable("Tbl_StudentCourse");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.StudentCourseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Grade")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("StudentCourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TakenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TermCourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentCourseId");

                    b.HasIndex("TermCourseId");

                    b.ToTable("Tbl_StudentCourseDetail");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Syllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ApplyEnteringDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Categury")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<short>("CourseId")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NeededCourses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrerequisiteCourses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("RequiredPassedCount")
                        .HasColumnType("tinyint");

                    b.Property<string>("TermOrder")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Tbl_Syllabus");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("EducationLevelId")
                        .HasColumnType("tinyint");

                    b.Property<string>("EmploymentCode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("EmploymentTypeId")
                        .HasColumnType("tinyint");

                    b.Property<short>("FieldId")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EducationLevelId");

                    b.HasIndex("EmploymentCode")
                        .IsUnique()
                        .HasName("IX_EmpCode");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("FieldId");

                    b.HasIndex("UserId");

                    b.ToTable("Tbl_Teacher");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tbl_Term");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.TermCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Capacity")
                        .HasColumnType("tinyint");

                    b.Property<short>("CourseId")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PresentationDays")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("TermId")
                        .HasColumnType("int");

                    b.Property<string>("TestDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TermId");

                    b.ToTable("Tbl_TermCourse");
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addresses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("NationCode")
                        .IsRequired()
                        .HasColumnType("char(10)")
                        .IsFixedLength(true)
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserGroup")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("NationCode")
                        .IsUnique()
                        .HasName("IX_NationCode");

                    b.HasIndex("UserName")
                        .HasName("IX_UserName");

                    b.ToTable("Tbl_User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1987, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Mohsen",
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Yousefiyan",
                            NationCode = "1190005646",
                            Password = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92",
                            UserGroup = "Admin",
                            UserName = "mohsen"
                        });
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Course", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Student", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.StudentCourse", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.StudentCourseDetail", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.StudentCourse", "StudentCourse")
                        .WithMany()
                        .HasForeignKey("StudentCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.TermCourse", "TermCourse")
                        .WithMany()
                        .HasForeignKey("TermCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Syllabus", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.Teacher", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.EducationLevel", "EducationLevel")
                        .WithMany()
                        .HasForeignKey("EducationLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.EmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TakeCourses.Core.Entities.Entities.TermCourse", b =>
                {
                    b.HasOne("TakeCourses.Core.Entities.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("TakeCourses.Core.Entities.Entities.Term", "Term")
                        .WithMany()
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
