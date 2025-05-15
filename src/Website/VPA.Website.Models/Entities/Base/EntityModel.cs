namespace VPA.Website.Models
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    public class EntityModel : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
