using Microsoft.EntityFrameworkCore;
using TestTask.Core.Entites;

namespace TestTask.Infrastructure.Context
{
    public class TestTaskDbContext : DbContext
    {
        public TestTaskDbContext() : base()
        {

        }
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TestTask.Core.Entites.Task> Tasks { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeEntry>()
                .HasKey(entity => new { entity.EmployeeId, entity.TaskId });
            modelBuilder.Entity<TimeEntry>()
                .HasOne(entity => entity.Employee)
                .WithMany(e => e.TimeEntries)
                .HasForeignKey(entity => entity.EmployeeId);
            modelBuilder.Entity<TimeEntry>()
                .HasOne(entity => entity.Task)
                .WithMany(t => t.TimeEntries)
                .HasForeignKey(entity => entity.TaskId);

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Jhon",
                LastName = "Doe",
                DateOfBirth = DateTime.Now.Date
            });

            modelBuilder.Entity<TestTask.Core.Entites.Task>().HasData(new TestTask.Core.Entites.Task
            {
                TaskId = 1,
                Description = "New Task",
                EstimatedHours = "3",
            });

            modelBuilder.Entity<TimeEntry>().HasData(new TimeEntry
            {
                EmployeeId = 1,
                TaskId = 1,
                Date = DateTime.Now.Date,
                HoursSpent = "3",
            });
        }
    }
}
