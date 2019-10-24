using WebApplication1.Models;
using System;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CourseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Courses.Any())
            {
                return;   // DB has been seeded
            }

            var courses = new CourseDescription[]
            {
            new CourseDescription{Description="Coding class 1"},
            new CourseDescription{Description="Another coding class 2"},
            new CourseDescription{Description="Another coding class 3"},
            new CourseDescription{Description="Another coding class 4"},
            new CourseDescription{Description="Another coding class 5"}
            };
            foreach (CourseDescription c in courses)
            {
                context.Description.Add(c);
            }
            context.SaveChanges();

            var coursesList = new CourseInstance[]
            {
            new CourseInstance{ID=1,Dept="Computer Science",Number=1410,Semester="Fall",Year=2019,Description=courses[1]},
            new CourseInstance{ID=2,Dept="Computer Science",Number=2420,Semester="Fall",Year=2019,Description=courses[1]},
            new CourseInstance{ID=3,Dept="Computer Science",Number=2420,Semester="Spring",Year=2020,Description=courses[1]},
            new CourseInstance{ID=4,Dept="Computer Science",Number=3500,Semester="Fall",Year=2019,Description=courses[3]},
            new CourseInstance{ID=5,Dept="Computer Science",Number=3505,Semester="Fall",Year=2019,Description=courses[3]},
            };
            foreach (CourseInstance s in coursesList)
            {
                context.Courses.Add(s);
            }
            context.SaveChanges();

            
        }
    }
}