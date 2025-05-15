using System.ComponentModel.DataAnnotations;

namespace VPA.Website.Models
{
    /// <summary>
    /// Represents a room in the system.
    /// </summary>
    public class Room : EntityModel
    {
        /// <summary>
        /// The number of the room.
        /// </summary>
        [StringLength(10)]
        public string Number { get; set; }

        /// <summary>
        /// The type of room.
        /// </summary>
        public RoomType Type { get; set; }

        /// <summary>
        /// The price per night for the room (in euros).
        /// </summary>
        public decimal PricePerNight { get; set; }

        /// <summary>
        /// If the room is available for booking.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
