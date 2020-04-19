using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GUIEX2PROJECT.Models;

namespace GUIEX2PROJECT.Data
{
    public class DbHelper
    {
        public static void SeedUsers(ApplicationDbContext db,UserManager<Employee> userManager)
        {
            string password = "password1&";
            var user = new Employee
            {
                UserName = "gonzales@gmail.com",
                Email = "gonzales@gmail.com",
                EmployeeId = "1",
                EmployeeType = EmployeeEnum.Chef
            };

            var result = userManager.CreateAsync(user, password).Result;
            
            
            if (result.Succeeded)
            {
                var chefClaim = new Claim("Chef", "Yes");
                userManager.AddClaimAsync(user, chefClaim);
            }
        }
    }
}