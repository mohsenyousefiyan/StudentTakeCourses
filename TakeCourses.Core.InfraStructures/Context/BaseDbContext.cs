using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TakeCourses.Core.Entities.Entities;
using TakeCourses.InfraStructures.DAL.SQL.Configs;

namespace TakeCourses.InfraStructures.DAL.SQL.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext()
        {

        }
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<StudentCourseDetail> StudentCourseDetails { get; set; }
        public DbSet<Syllabus> Syllabus { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<TermCourse> TermCourses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Password=1;User=sa;Initial Catalog=University;Data Source=.");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new EducationLevelConfiguration());
            modelBuilder.ApplyConfiguration(new EmploymentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FieldConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseDetailConfiguration());
            modelBuilder.ApplyConfiguration(new SyllabusConfiguration());
            modelBuilder.ApplyConfiguration(new TermConfiguration());
            modelBuilder.ApplyConfiguration(new TermCourseConfiguration());
            modelBuilder.ApplyConfiguration(new AddressTypeConfiguration());
        }

    }
}

