using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents a reservation in the system.
    /// </summary>
    public class Reservation : EntityModel
    {
        /// <summary>
        /// The <see cref="Guest"/> who made the reservation.
        /// </summary>
        [Required]
        public int GuestId { get; set; }

        /// <summary>
        /// The <see cref="Room"/> that is reserved.
        /// </summary>
        [Required]
        public int RoomId { get; set; }

        /// <summary>
        /// The check-in date of the reservation.
        /// </summary>
        [Required]
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// The check-out date of the reservation.
        /// </summary>
        [Required]
        public DateTime CheckOutDate { get; set; }
    }
}
