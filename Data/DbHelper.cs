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
            //System.Data.Entity.MigrateDatabaseToLatestVersion;
            string password = "password";
            var user = new Employee
            {
                UserName = "gonzalesthechef",
                Email = "gonzales@gmail.com",
                EmployeeId = 1,
                EmployeeType = EmployeeEnum.Chef
            };

            IdentityResult result = userManager.CreateAsync(user, password).Result;
            
            if (result.Succeeded)
            {
                var chefClaim = new Claim("Chef", "Yes");
                userManager.AddClaimAsync(user, chefClaim);
            }
        }
    }
}