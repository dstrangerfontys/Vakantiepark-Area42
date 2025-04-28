using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    public class Room : EntityModel
    {
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;
        public ICollection<Reservation> Reservations { get; set; }
    }
}
