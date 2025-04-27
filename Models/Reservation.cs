using System.ComponentModel.DataAnnotations;

namespace Vakantiepark_Area42.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-in Date")]
        public DateTime CheckInDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-out Date")]
        public DateTime CheckOutDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public Guest Guest { get; set; }
        public Room Room { get; set; }
    }


}
