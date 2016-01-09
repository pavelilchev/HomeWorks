namespace Empires.Contracts
{
    using Enums;

    /// <summary>
    /// Implement factory design pattern for resources.
    /// </summary>
    public interface IResourceFactory
    {
        /// <summary>
        /// Create resource and return it.
        /// </summary>
        /// <param name="resourceType">Type of resource.</param>
        /// <param name="quantity">Quantity of resource.</param>
        /// <returns>Created resource like IResource.</returns>
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
