using Microsoft.EntityFrameworkCore;
using SkiServiceBackend.Models;

namespace SkiServiceBackend.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<TaskPriority> TaskPriorities { get; set; }
        public DbSet<TaskOrder> TaskOrders { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed AppUsers
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser() { UserID = 1, Name = "admin", UserPassword = "admin" },
                new AppUser() { UserID = 2, Name = "Employee1", UserPassword = "E1" },
                new AppUser() { UserID = 3, Name = "Employee2", UserPassword = "E2" },
                new AppUser() { UserID = 4, Name = "Employee3", UserPassword = "E3" },
                new AppUser() { UserID = 5, Name = "Employee4", UserPassword = "E4" },
                new AppUser() { UserID = 6, Name = "Employee5", UserPassword = "E5" },
                new AppUser() { UserID = 7, Name = "Employee6", UserPassword = "E6" },
                new AppUser() { UserID = 8, Name = "Employee7", UserPassword = "E7" },
                new AppUser() { UserID = 9, Name = "Employee8", UserPassword = "E8" },
                new AppUser() { UserID = 10, Name = "Employee9", UserPassword = "E9" },
                new AppUser() { UserID = 11, Name = "Employee10", UserPassword = "E10" }
            );

            // Seed TaskPriorities
            modelBuilder.Entity<TaskPriority>().HasData(
                new TaskPriority() { PriorityID = 1, Type = "Low", DaysToCompletion = 12 },
                new TaskPriority() { PriorityID = 2, Type = "Standard", DaysToCompletion = 7 },
                new TaskPriority() { PriorityID = 3, Type = "Express", DaysToCompletion = 5 }
            );
        }
    }
}
