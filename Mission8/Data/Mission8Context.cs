// =============================================================================
// JARED - Assignment #1: Models / Database / Setup
// Purpose: DbContext for the application. Configure DbSets for Task and Category.
//          Populate database with any seed data the team deems necessary.
// =============================================================================

using Microsoft.EntityFrameworkCore;
using Mission8.Models;
using MissionTask = Mission8.Models.Task;

namespace Mission8.Data
{
    public class Mission8Context : DbContext
    {
        public Mission8Context(DbContextOptions<Mission8Context> options) : base(options)
        {
        }

        public DbSet<MissionTask> Tasks => Set<MissionTask>();
        public DbSet<Category> Categories => Set<Category>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            modelBuilder.Entity<MissionTask>().HasData(
                new MissionTask
                {
                    TaskId = 1,
                    TaskName = "Finish Mission 8 database setup",
                    DueDate = new DateTime(2026, 2, 28),
                    Quadrant = 2,
                    CategoryId = 2,
                    Completed = false
                },
                new MissionTask
                {
                    TaskId = 2,
                    TaskName = "Plan weekly work priorities",
                    DueDate = new DateTime(2026, 3, 1),
                    Quadrant = 2,
                    CategoryId = 3,
                    Completed = false
                },
                new MissionTask
                {
                    TaskId = 3,
                    TaskName = "Prepare family activity",
                    DueDate = null,
                    Quadrant = 4,
                    CategoryId = 1,
                    Completed = false
                }
            );
        }
    }
}
