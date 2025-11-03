namespace EFCoreModelApp.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}