using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Entities
{
    /// <summary>
    /// Represents a store location in the store.
    /// </summary>
    public class StoreLocation : EntityModel
    {
        /// <summary>
        /// The name of the store location.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The row of the store location.
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// The height int the row of the store location.
        /// </summary>
        public int Height { get; set; }
    }
}
