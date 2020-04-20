using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GUIEX2PROJECT.Models;

namespace GUIEX2PROJECT.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<Employee> userManager, ILogger log)
        {
            //DeleteAndCreateDatabase(db);
            SeedRooms(db, log);
            SeedRoomBookings(db, log);
            SeedEmployee(userManager, log);
        }
        
        private static void DeleteAndCreateDatabase(ApplicationDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static void SeedRooms(ApplicationDbContext db, ILogger log)
        {
            var r = db.Rooms.FirstOrDefault();
            if (r != null) return;
            for (var i = 1; i < 10; i++)
            {
                db.Rooms.Add(new Room() {RoomNumber = i});
                db.SaveChangesAsync().Wait();
            }
        }

        private static void SeedRoomBookings(ApplicationDbContext db, ILogger log)
        {
            var rb = db.RoomBookings.FirstOrDefault();
            if (rb != null) return;
            rb = new RoomBooking()
            {
                Date = DateTime.Today,
                RoomNumber = 1,
                NumOfAdultsInRoom = 2,
                NumOfChildrenInRoom = 2,
                NumberOfAdultBreakfastReservations = 1,
                NumberOfChildBreakfastReservations = 2,
                NumberOfAdultsCheckedInToBreakfast = 1,
                NumberOfChildrenCheckedInToBreakfast = 1
            };
            db.RoomBookings.Add(rb);
            db.SaveChangesAsync().Wait();
            rb = new RoomBooking()
            {
                Date = DateTime.Today,
                RoomNumber = 2,
                NumOfAdultsInRoom = 4,
                NumOfChildrenInRoom = 1,
                NumberOfAdultBreakfastReservations = 4,
                NumberOfChildBreakfastReservations = 1,
                NumberOfAdultsCheckedInToBreakfast = 1,
                NumberOfChildrenCheckedInToBreakfast = 1
            };
            db.RoomBookings.Add(rb);
            db.SaveChangesAsync().Wait();
        }

        private static bool SeedEmployee(UserManager<Employee> userManager, ILogger log)
        {
            string adminEmail = "admin@gmail.com";
            string chefEmail = "gonzales@gmail.com";
            string receptionistEmail = "alina@gmail.com";
            string waiterEmail = "thomaslarsen@gmail.com";
            string password = "Koden_1";
            
            var chefClaim = new Claim("Chef", "Yes");
            var receptionistClaim = new Claim("Receptionist", "Yes");
            var waiterClaim = new Claim("Waiter", "Yes");

            //add admin
            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var admin = new Employee
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmployeeId = "1",
                    EmployeeType = EmployeeEnum.Admin,
                };
                IdentityResult result = userManager.CreateAsync
                    (admin, password).Result;
                if (result.Succeeded)
                {
                    var addClaimResult = userManager.AddClaimAsync(admin, chefClaim);
                    addClaimResult.Wait();
                    addClaimResult = userManager.AddClaimAsync(admin, waiterClaim);
                    addClaimResult.Wait();
                    addClaimResult = userManager.AddClaimAsync(admin, receptionistClaim);
                    addClaimResult.Wait();
                }
            }

            //add chef
            if (userManager.FindByNameAsync(chefEmail).Result == null)
            {
                var chef = new Employee
                {
                    UserName = chefEmail,
                    Email = chefEmail,
                    EmployeeId = "2",
                    EmployeeType = EmployeeEnum.Chef
                };
                IdentityResult result = userManager.CreateAsync
                    (chef, password).Result;
                if (result.Succeeded)
                {
                    var addClaimResult = userManager.AddClaimAsync(chef, chefClaim);
                    addClaimResult.Wait();
                }
            }

            //add receptionist
            if (userManager.FindByNameAsync(receptionistEmail).Result == null)
            {
                var receptionist = new Employee
                {
                    UserName = receptionistEmail,
                    Email = receptionistEmail,
                    EmployeeId = "3",
                    EmployeeType = EmployeeEnum.Receptionist
                };

                IdentityResult result = userManager.CreateAsync
                    (receptionist, password).Result;
                if (result.Succeeded)
                {
                    var addClaimResult = userManager.AddClaimAsync(receptionist, receptionistClaim);
                    addClaimResult.Wait();
                }
            }

            //add waiter
            if (userManager.FindByNameAsync(waiterEmail).Result == null)
            {
                var waiter = new Employee
                {
                    UserName = waiterEmail,
                    Email = waiterEmail,
                    EmployeeId = "4",
                    EmployeeType = EmployeeEnum.Waiter
                };
                IdentityResult result = userManager.CreateAsync
                    (waiter, password).Result;
                if (result.Succeeded)
                {
                    var addClaimResult = userManager.AddClaimAsync(waiter, waiterClaim);
                    addClaimResult.Wait();
                }
            }

            return true;
        }
    }
}