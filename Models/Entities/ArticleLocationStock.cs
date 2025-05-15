using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    /// <summary>
    /// Represents the stock of an article at a specific location.
    /// </summary>
    public class ArticleLocationStock : EntityModel
    {
        /// <summary>
        /// The article that is stored at the location.
        /// </summary>
        public Article Article { get; set; }

        /// <summary>
        /// The location where the article is stored.
        /// </summary>
        public StoreLocation Location { get; set; }

        /// <summary>
        /// The amount of stock of the article at the location.
        /// </summary>
        public int Amount { get; set; }
    }
}
