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
            
        private static void SeedRoomsAndReservations(ApplicationDbContext db)
        {
            var r = db.Rooms.FirstOrDefault();
            if (r == null)
            {
                var rooms = new List<Room>();
                r = new Room()
                {
                    RoomNumber = 1
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 2
                };
                rooms.Add(r);

                r = new Room()
                {
                    RoomNumber = 3
                };
                rooms.Add(r);

                r = new Room()
                {
                    RoomNumber = 4
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 5
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 6
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 7
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 8
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 9
                };
                rooms.Add(r);
                r = new Room()
                {
                    RoomNumber = 10
                };
                rooms.Add(r);
                foreach (var Room in rooms)
                {
                    db.Rooms.Add(Room);
                }
                db.Rooms.AddRange(rooms);
                db.SaveChangesAsync();
            }

            var rb = db.RoomBookings.FirstOrDefault();
            if (rb == null)
            {
                var roomBookings = new List<RoomBooking>();
                rb = new RoomBooking()
                {
                    BookingId = 1,
                    NumOfAdultsInRoom = 2,
                    NumOfChildrenInRoom = 2,
                    NumberOfAdultBreakfastReservations = 1,
                    NumberOfChildBreakfastReservations = 2,
                    NumberOfAdultsCheckedInToBreakfast = 1,
                    NumberOfChildrenCheckedInToBreakfast = 1
                };
                roomBookings.Add(rb);
                rb = new RoomBooking()
                {
                    BookingId = 2,
                    NumOfAdultsInRoom = 4,
                    NumOfChildrenInRoom = 1,
                    NumberOfAdultBreakfastReservations = 4,
                    NumberOfChildBreakfastReservations = 1,
                    NumberOfAdultsCheckedInToBreakfast = 1,
                    NumberOfChildrenCheckedInToBreakfast = 1
                };
                roomBookings.Add(rb);
                db.RoomBookings.AddRange(roomBookings);
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

            var result = userManager.CreateAsync(user, password).Result;
            user = new Employee
            {
                UserName = "alina@gmail.com",
                Email = "alina@gmail.com",
                EmployeeId = "2",
                EmployeeType = EmployeeEnum.Receptionist
            };
            result = userManager.CreateAsync(user, password).Result;
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
            result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                var waiterClaim = new Claim("Waiter", "Yes");
                userManager.AddClaimAsync(user, waiterClaim);
            }
        }
    }
}