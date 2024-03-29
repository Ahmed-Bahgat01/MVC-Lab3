﻿using Microsoft.EntityFrameworkCore;
using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options):base(options)
        {
        }

        //public Context() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DeptStuDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //    //optionsBuilder.UseLazyLoadingProxies();
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>()
                .HasKey(x => new { x.StudentId, x.CourseId });
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Department>? Departments { get;set; }
        public virtual DbSet<Course>? Courses { get; set; }
        public virtual DbSet<StudentCourse>? StudentCourses { get; set; }
    }
}
