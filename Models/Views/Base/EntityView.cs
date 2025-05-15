using Vakantiepark_Area42.Models.Entities.Base;

namespace Vakantiepark_Area42.Models.Views.Base
{
    /// <summary>
    /// Base class for all entity views in the application.
    /// </summary>
    public class EntityView : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
