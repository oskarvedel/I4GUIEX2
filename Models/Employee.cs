using Microsoft.AspNetCore.Identity;

namespace GUIEX2PROJECT.Models
{
    public enum EmployeeEnum
    {
        Waiter,
        Receptionist,
        Chef
    }
    public class Employee : IdentityUser
    {
        public int EmployeeId { get; set; }
        public EmployeeEnum EmployeeType { get; set; }
    }
}
