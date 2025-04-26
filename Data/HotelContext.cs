using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Models;


namespace Vakantiepark_Area42.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }

}
