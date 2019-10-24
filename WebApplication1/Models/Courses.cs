using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        { }

        public DbSet<CourseInstance> Courses { get; set; }
        public DbSet<CourseDescription> Description { get; set; }
       // protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
          //  modelBuilder.Entity<CourseInstance>().ToTable("Course");
          //  modelBuilder.Entity<CourseDescription>().ToTable("Description");
            // override to set a primary key to create a controller
            //modelBuilder.Entity<CourseDescription>().HasKey(c => c.DescriptionId);
       // }
  
    }

    public class CourseInstance
    {
        public int ID { get; set; }
        public string Dept { get; set; }
        public int Number  { get; set; }
        public string Semester { get; set; }
        public int Year { get; set; }
        public CourseDescription Description { get; set; }

        
    }

    public class CourseDescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}