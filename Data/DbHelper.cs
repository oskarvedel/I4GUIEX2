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
            
            SeedEmployees(userManager);
        }
        
        private static void Seed(ApplicationDbContext db)
        {
            var r = db.Rooms.FirstOrDefault();
            if (r == null)
            {
                var rooms = new List<Room>();
                r = new Room()
                {
                    RoomNumber = 1
                }
        }
            
            var r = db.RoomBookings.FirstOrDefault();
            if (r == null)
            {
                var roombookings = new List<RoomBooking>();
                r = new RoomBooking()
                {
                    RoomNumber = 1,
                    NumberOfAdults = 2,
                    NumberOfChildren = 2
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 2,
                    NumberOfAdults = 2,
                    NumberOfChildren = 4
                };
                rooms.Add(r);

                db.Rooms.AddRange(rooms);
                db.SaveChangesAsync();
            }
            var b = db.BreakfastReservations.FirstOrDefault();
            if (b == null)
            {
                var breakfastReservations = new List<BreakfastReservation>();
                b = new BreakfastReservation()
                {
                    DateTime = DateTime.Today,
                    NumberOfAdultReservations = ,
                    NumberOfChildReservations = ,
                    NumberOfAdultsCheckedIn = ,
                    NumberOfChildrenCheckedIn = 
                };
                musics.Add(m);
                m = new Music()
                {
                    Year = DateTime.Now.Year,
                    Month = DateTime.Now.Month + 1,
                    Name = "Tahoe Greg",
                    Description = "Tahoe Greg&rsquo;s back from his tour. New songs. New stories. CDs are now available.",
                    ThumbNailUrl = "gregthumb.jpg",
                    ImageUrl = "greg.jpg"
                };
                musics.Add(m);
                db.Musics.AddRange(musics);
                db.SaveChangesAsync();
            }
        }
        private static void SeedEmployees(UserManager<Employee> userManager)
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
            
            user = new Employee
            {
                UserName = "alina@gmail.com",
                Email = "alina@gmail.com",
                EmployeeId = "2",
                EmployeeType = EmployeeEnum.Receptionist
            };
            
            result =  userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                var receptionistClaim = new Claim("Receptionist", "Yes");
                userManager.AddClaimAsync(user, receptionistClaim);
            }
            
            user = new Employee
            {
                UserName = "alina@gmail.com",
                Email = "alina@gmail.com",
                EmployeeId = "3",
                EmployeeType = EmployeeEnum.Waiter
            };
            
            result =  userManager.CreateAsync(user, password).Result;

            if (result.Succeeded)
            {
                var waiterClaim = new Claim("Waiter", "Yes");
                userManager.AddClaimAsync(user, waiterClaim);
            }
        }
    }
}