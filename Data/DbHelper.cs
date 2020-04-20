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
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace GUIEX2PROJECT.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<Employee> userManager, ILogger log)
        {
            //DeleteAndCreateDatabase(db);
            //SeedRooms(db, log);
            SeedReservations(db, log);
            //SeedEmployee(userManager, log);
            
        }

        private static void DeleteAndCreateDatabase(ApplicationDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static async void SeedRooms(ApplicationDbContext db, ILogger log)
        {
            for (var i = 0; i < 10; i++)
            {
                var r = new Room() {RoomNumber = 1};
                db.Rooms.Add(r);
                await db.SaveChangesAsync();
            }
        }

        private static async void SeedReservations(ApplicationDbContext db, ILogger log)
        {
            var rb = new RoomBooking()
            {
                RoomNumber = 1,
                NumOfAdultsInRoom = 2,
                NumOfChildrenInRoom = 2,
                NumberOfAdultBreakfastReservations = 1,
                NumberOfChildBreakfastReservations = 2,
                NumberOfAdultsCheckedInToBreakfast = 1,
                NumberOfChildrenCheckedInToBreakfast = 1
            };
            db.RoomBookings.Add(rb);
            await db.SaveChangesAsync();
            rb = new RoomBooking()
            {
                RoomNumber = 2,
                NumOfAdultsInRoom = 4,
                NumOfChildrenInRoom = 1,
                NumberOfAdultBreakfastReservations = 4,
                NumberOfChildBreakfastReservations = 1,
                NumberOfAdultsCheckedInToBreakfast = 1,
                NumberOfChildrenCheckedInToBreakfast = 1
            };
            db.RoomBookings.Add(rb);
            await db.SaveChangesAsync();
        }

        private static bool SeedEmployee(UserManager<Employee> userManager, ILogger log)
        {
            string chefEmail = "gonzales@gmail.com";
            string password = "Thisisthecode_1";

            //add chef
            var chef = new Employee
            {
                UserName = "gonzales@gmail.com",
                Email = "gonzales@gmail.com",
                EmployeeId = "1",
                EmployeeType = EmployeeEnum.Chef
            };
            IdentityResult result = userManager.CreateAsync
                (chef, password).Result;
            if (result.Succeeded)
            {
                var chefClaim = new Claim("Chef", "Yes");
                var addClaimResult = userManager.AddClaimAsync(chef, chefClaim);
                addClaimResult.Wait();
            }

            //add receptionist
            var receptionist = new Employee
            {
                UserName = "alina@gmail.com",
                Email = "alina@gmail.com",
                EmployeeId = "2",
                EmployeeType = EmployeeEnum.Receptionist
            };

            result = userManager.CreateAsync
                (receptionist, password).Result;
            if (result.Succeeded)
            {
                var receptionistClaim = new Claim("Receptionist", "Yes");
                var addClaimResult = userManager.AddClaimAsync(chef, receptionistClaim);
                addClaimResult.Wait();
            }

            //add waiter
            var waiter = new Employee
            {
                UserName = "jegerboesse@gmail.com",
                Email = "jegerboesse@gmail.com",
                EmployeeId = "3",
                EmployeeType = EmployeeEnum.Waiter
            };
            result = userManager.CreateAsync
                (waiter, password).Result;
            if (result.Succeeded)
            {
                var waiterClaim = new Claim("Waiter", "Yes");
                var addClaimResult = userManager.AddClaimAsync(chef, waiterClaim);
                addClaimResult.Wait();
            }
            return true;
        }
    }
}