using System.ComponentModel.DataAnnotations;

namespace VPA.Models
{
    /// <summary>
    /// Represents an article in the store.
    /// </summary>
    public class Article : EntityModel
    {
        /// <summary>
        /// The name of the article.
        /// </summary>
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        /// <summary>
        /// The price of the article (in euros).
        /// </summary>
        [Required]
        public decimal Price { get; set; }
    }
}
