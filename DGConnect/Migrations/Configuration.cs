namespace DGConnect.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DGConnect.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DGConnect.Models.ApplicationDbContext";
        }

        protected override void Seed(DGConnect.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Courses.AddOrUpdate(c => c.Name,
            new Course { Name = "Log Lake", City = "Kalkaska", State = "MI", Country = "USA" },
            new Course { Name = "Hickory Hills", City = "Traverse City", State = "MI", Country = "USA" },
            new Course
            {
                Name = "Avalanche Park",
                City = "Boyne City",
                State = "MI",
                Country = "USA",
                Reviews =
                new List<CourseReview>
                {
                    new CourseReview {Rating = 8, Body = "One hell of a workout!" },
                    new CourseReview {Rating = 9, Body = "Test Review" }
                }
            });
        }
    }
}
