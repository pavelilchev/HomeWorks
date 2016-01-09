namespace Empires.Contracts
{
    /// <summary>
    /// Provides destroying behavior for units and structures.
    /// </summary>
    public interface IDestroyable
    {
        /// <summary>
        ///  Gets or sets the health <see cref="IUnit" /> instance.
        /// </summary>
        int Health { get; set; }
    }
}
