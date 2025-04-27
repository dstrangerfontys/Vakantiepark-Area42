namespace Vakantiepark_Area42.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }
        public decimal PricePerNight { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }

}
