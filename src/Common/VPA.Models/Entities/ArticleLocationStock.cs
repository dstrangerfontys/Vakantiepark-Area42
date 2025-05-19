using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents the stock of an <see cref="Reservation"/> in a <see cref="StoreLocation"/>.
    /// </summary>
    public class ReservationLocationStock : EntityModel
    {
        /// <summary>
        /// The <see cref="Reservation"/> that is located in the store location.
        /// </summary>
        [Required]
        public int ReservationId { get; set; }

        /// <summary>
        /// The <see cref="StoreLocation"/> where the Reservation is located.
        /// </summary>
        [Required]
        public int LocationId { get; set; }

        /// <summary>
        /// The amount of stock of the Reservation in the location.
        /// </summary>
        [Required]
        public int Amount { get; set; }
    }
}
