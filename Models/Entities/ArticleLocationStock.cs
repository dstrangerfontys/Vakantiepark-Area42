using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    /// <summary>
    /// Represents the stock of an article at a specific location.
    /// </summary>
    public class ArticleLocationStock : EntityModel
    {
        /// <summary>
        /// The <see cref="Article"/> that is stored at the location.
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// The <see cref="StoreLocation"/> where the article is stored.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// The amount of stock of the article at the location.
        /// </summary>
        public int Amount { get; set; }
    }
}
