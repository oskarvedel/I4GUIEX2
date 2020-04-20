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
using Microsoft.EntityFrameworkCore;

namespace GUIEX2PROJECT.Data
{
    public class DbHelper
    {
        public static void SeedData(ApplicationDbContext db, UserManager<Employee> userManager)
        {
            //DeleteAndCreateDatabase(db);
            SeedRoomsAndReservations(db);
            SeedEmployees(userManager);
        }

        private static void DeleteAndCreateDatabase(ApplicationDbContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        private static async void SeedRoomsAndReservations(ApplicationDbContext db)
        {
            var r = db.Rooms.FirstOrDefault();
            if (r == null)
            {
                for (var i = 0; i < 10; i++)
                {
                    r = new Room() {RoomNumber = 1};
                    db.Rooms.Add(r);
                    await db.SaveChangesAsync();
                }

                var rb = db.RoomBookings.FirstOrDefault();
                if (rb == null)
                {
                    var roomBookings = new List<RoomBooking>();
                    rb = new RoomBooking()
                    {
                        RoomId = 1,
                        BookingId = 1,
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
                        RoomId = 2,
                        BookingId = 2,
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
            }
        }

        private static async void SeedEmployees(UserManager<Employee> userManager)
        {
            string password = "thisisthecode_1";
            
            //add chef
            var chef = new Employee
            {
                UserName = "gonzales@gmail.com",
                Email = "gonzales@gmail.com",
                //EmployeeId = "1",
                //EmployeeType = EmployeeEnum.Chef
            };
            await userManager.CreateAsync(chef, password);
            var chefClaim = new Claim("Receptionist", "Yes");
            await userManager.AddClaimAsync(chef, chefClaim);

            //add receptionist
            var receptionist = new Employee
            {
                UserName = "alina@gmail.com",
                Email = "alina@gmail.com",
                EmployeeId = "2",
                EmployeeType = EmployeeEnum.Receptionist
            };
            await userManager.CreateAsync(receptionist, password);
            var receptionistClaim = new Claim("Receptionist", "Yes");
            await userManager.AddClaimAsync(chef, receptionistClaim);

            //add employee
            var waiter = new Employee
            {
                UserName = "alina2@gmail.com",
                Email = "alina2@gmail.com",
                EmployeeId = "3",
                EmployeeType = EmployeeEnum.Waiter
            };
            await userManager.CreateAsync(waiter, password);
            var waiterClaim = new Claim("Receptionist", "Yes");
            await userManager.AddClaimAsync(chef, waiterClaim);
        }
    }
}