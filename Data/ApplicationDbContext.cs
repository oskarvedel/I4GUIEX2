using GUIEX2PROJECT.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public DbSet<RoomBooking> RoomBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Room>()
                .HasKey(r => r.RoomId);

            modelbuilder.Entity<Room>()
                .HasIndex(r => r.RoomNumber)
                .IsUnique();

            modelbuilder.Entity<RoomBooking>()
                .HasKey(r => r.BookingId);

            modelbuilder.Entity<RoomBooking>()
                .HasOne<Room>(r => r.Room)
                .WithMany(r => r.RoomBookings)
                .HasForeignKey(r => r.RoomNumber);

            modelbuilder.Entity<Room>()
                .Property(r => r.RoomNumber);

        }
    }
}
