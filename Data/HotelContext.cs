using Microsoft.EntityFrameworkCore;
using Vakantiepark_Area42.Models.Entities;


namespace Vakantiepark_Area42.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Guest> Guest { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
    }
}
