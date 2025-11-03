
using EFCoreModelApp;
using EFCoreModelApp.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
       using var context = new HRDbContext();
        var allEmployees = context.Employees.Include(e => e.Department).ToList();
        foreach (var employee in allEmployees)
        {
            Console.WriteLine($"{employee.FirstName} works in {employee.Department.DepartmentName} in location {employee.Department.Location}");
        }
        var TIEmployees = context.Employees
            .Include(e => e.Department)
            .Where(e => e.Department.DepartmentName == "IT")
            .ToList();
        Console.WriteLine("\nEmployees in IT Department: ");
        foreach (var emp in TIEmployees)
        {
            Console.WriteLine($"{emp.FirstName} works in IT department located at {emp.Department.Location}");
        }

        context.Employees.Add( new Employee
        {
            FirstName = "Sara",
            LastName = "Connor",
            DepartmentID = 2
        });

        context.SaveChanges();
        Console.WriteLine("\nAfter Adding a new Employee:");
        var TIEmployeesAfter = context.Employees
            .Include(e => e.Department)
            .Where(e => e.Department.DepartmentName == "IT")
            .ToList();
        foreach (var emp in TIEmployeesAfter)
        {
            Console.WriteLine($"{emp.FirstName} works in IT department located at {emp.Department.Location}");
        }
    }
}