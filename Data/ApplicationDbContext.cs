using GUIEX2PROJECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GUIEX2PROJECT.Data
{
	public class ApplicationDbContext : IdentityDbContext<Employee>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
        public DbSet<Employee> Employees { get; set; }
        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BreakfastReservation> BreakfastReservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //modelbuilder.Entity<ApplicationUser>()
            //    .HasKey(e => e.Name);

            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Room>()
                .HasKey(r => r.RoomNumber);

            modelbuilder.Entity<BreakfastReservation>()
                .HasKey(b => b.ReservationId);

            modelbuilder.Entity<BreakfastReservation>()
                .HasOne<Room>(b => b.room)
                .WithMany(r => r.BreakfastDates)
                .HasForeignKey(b => b.roomNumber);

           
        }
    }
}
