namespace VPA.Models
{
    /// <summary>
    /// Base class for all entity views.
    /// </summary>
    public class EntityView : IEntity
    {
        /// <inheritdoc />
        public int Id { get; set; }
    }
}
