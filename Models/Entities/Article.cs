using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    /// <summary>
    /// Represents an article in the store.
    /// </summary>
    public class Article : EntityModel
    {
        /// <summary>
        /// The name of the article.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The price of the article (in euros).
        /// </summary>
        public decimal Price { get; set; }
    }
}
