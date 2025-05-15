namespace Vakantiepark_Area42.Models.Entities.Base
{
    /// <summary>
    /// Base class for all entities in the application.
    /// </summary>
    public class EntityModel : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
