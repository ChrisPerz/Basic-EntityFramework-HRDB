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
            optionsBuilder.UseSqlite("Data Source=HRDatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.HasOne(e => e.Department).WithMany(d => d.Employees).HasForeignKey(e => e.DepartmentID);
            });
            modelBuilder.Entity<Employee>().HasData(

                new Employee { EmployeeId = 1, DepartmentID = 1, FirstName = "Jorge", LastName = "Colewall"},
                new Employee { EmployeeId = 2, DepartmentID = 2, FirstName = "Anna", LastName = "Smith" },
                new Employee { EmployeeId = 3, DepartmentID = 2, FirstName = "Peter", LastName = "Brown" },
                new Employee { EmployeeId = 4, DepartmentID = 3, FirstName = "Liam", LastName = "Johnson" }
            );
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "Human Resources", Location = "New York" },
                new Department { DepartmentId = 2, DepartmentName = "IT", Location = "San Francisco" },
                new Department { DepartmentId = 3, DepartmentName = "Finance", Location = "Chicago" }
            );
        }   
    }
}