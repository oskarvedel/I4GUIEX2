namespace WebApplication1.Models
{
    public enum EmployeeEnum
    {
        Waiter,
        Receptionist,
        Chef
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public EmployeeEnum EmployeeType { get; set; }
    }
}
