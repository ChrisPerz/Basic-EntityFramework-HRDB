
using EFCoreModelApp;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        using (var context = new HRDbContext())
        {
            context.Database.EnsureCreated();

            var departments = context.Departments
                .Include(d => d.Employees)
                .ToList();

            foreach (var department in departments)
            {
                Console.WriteLine($"Department: {department.DepartmentName} ({department.Location})");
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine($"\tEmployee: {employee.FirstName} {employee.LastName}");
                }
            }
        }
    }
}