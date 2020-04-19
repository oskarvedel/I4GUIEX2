using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Security.Claims;
using GUIEX2PROJECT.Models;

namespace GUIEX2PROJECT.Data
{
    public class DbHelper
    {
        
        public static void SeedData(ApplicationDbContext db, UserManager<Employee> userManager)
        {
            
            SeedUsers(userManager);
        }
        public static void SeedUsers(UserManager<Employee> userManager)
        {
            string password = "nicepw_1";
            var user = new Employee
            {
                UserName = "gonzales@gmail.com",
                Email = "gonzales@gmail.com",
                EmployeeId = "1",
                EmployeeType = EmployeeEnum.Chef
            };
            
            var result =  userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                var chefClaim = new Claim("Chef", "Yes");
                userManager.AddClaimAsync(user, chefClaim);
            }
        }
    }
}