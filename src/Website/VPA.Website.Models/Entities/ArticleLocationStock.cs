using System.ComponentModel.DataAnnotations;

namespace VPA.Website.Models
{
    /// <summary>
    /// Represents the stock of an <see cref="Article"/> in a <see cref="StoreLocation"/>.
    /// </summary>
    public class ArticleLocationStock : EntityModel
    {
        /// <summary>
        /// The <see cref="Article"/> that is located in the store location.
        /// </summary>
        [Required]
        public int ArticleId { get; set; }

        /// <summary>
        /// The <see cref="StoreLocation"/> where the article is located.
        /// </summary>
        [Required]
        public int LocationId { get; set; }

        /// <summary>
        /// The amount of stock of the article in the location.
        /// </summary>
        [Required]
        public int Amount { get; set; }
    }
}
