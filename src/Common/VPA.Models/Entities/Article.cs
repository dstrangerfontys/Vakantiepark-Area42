using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents an Reservation in the store.
    /// </summary>
    public class Article : EntityModel
    {
        /// <summary>
        /// The name of the Reservation.
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// The price of the Reservation (in euros).
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
