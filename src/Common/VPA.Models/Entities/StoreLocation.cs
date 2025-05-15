using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents a location in the store where articles can be placed.
    /// </summary>
    public class StoreLocation : EntityModel
    {
        /// <summary>
        /// The name of the store location.
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// The row in the store where the location is situated.
        /// </summary>
        [Required]
        public int Row { get; set; }

        /// <summary>
        /// The height in the row where the location is situated.
        /// </summary>
        [Required]
        public int Height { get; set; }
    }
}
