namespace EFCoreModelApp
{
    using Microsoft.EntityFrameworkCore;
    using EFCoreModelApp.Models;

    public class HRDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hrdatabase.db");
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
            .HasMany(d=> d.Employees)
            .WithOne(e=> e.Department)
            .HasForeignKey(e=> e.DepartmentID);

            //OR
            // modelBuilder.Entity<Employee>(entity =>
            // {
            //     entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            //     entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            //     entity
            //         .HasOne(e => e.Department)
            //         .WithMany(d => d.Employees)
            //         .HasForeignKey(e => e.DepartmentID);
            // });

            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Human Resources", Location = "New York" },
                new Department { DepartmentId = 2, DepartmentName = "IT", Location = "San Francisco" },
                new Department { DepartmentId = 3, DepartmentName = "Finance", Location = "Chicago" }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Alicia", LastName = "Wood", DepartmentID = 1},
                new Employee { EmployeeId = 2, FirstName = "Brian", LastName = "Johnson", DepartmentID = 2 },
                new Employee { EmployeeId = 3, FirstName = "Catherine", LastName = "Smith", DepartmentID = 3 }
            );
        }
    }
}