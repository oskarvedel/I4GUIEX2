using GUIEX2PROJECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace GUIEX2PROJECT.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
        public DbSet<ApplicationUser> Employees { get; set; }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BreakfastReservation> BreakfastReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //modelbuilder.Entity<ApplicationUser>()
            //    .HasKey(e => e.Name);

            modelbuilder.Entity<Room>()
                .HasKey(r => r.RoomNumber);

            modelbuilder.Entity<BreakfastReservation>()
                .HasKey(b => b.ReservationId);

            modelbuilder.Entity<BreakfastReservation>()
                .HasOne<Room>(b => b.room)
                .WithMany(r => r.BreakfastDates)
                .HasForeignKey(b => b.roomNumber);

            modelbuilder.Entity<Room>()
                .HasData(
                new Room
                {
                    RoomNumber = 101,
                    NumberOfAdults = 3,
                    NumberOfChildren = 4
                },

            new Room
            {
                RoomNumber = 202,
                NumberOfAdults = 1,
                NumberOfChildren = 1
            },

            new Room
            {
                RoomNumber = 303,
                NumberOfAdults = 2,
                NumberOfChildren = 2
            }
            );
        }
    }
}
