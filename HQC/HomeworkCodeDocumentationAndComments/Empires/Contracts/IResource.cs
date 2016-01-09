namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Resource model.
    /// </summary>
    public interface IResource
    {
        /// <summary>
        /// Gets resource type.
        /// </summary>
        ResourceType ResourceType { get; }

        /// <summary>
        /// Gets quantity of resource.
        /// </summary>
        int Quantity { get; }
    }
}
