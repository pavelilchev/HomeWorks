namespace Empires.Contracts
{
    using System.Collections.Generic;

    using Enums;

    /// <summary>
    /// Game database.
    /// </summary>
    public interface IEmpiresData
    {
        /// <summary>
        /// Gets a collection of buildings hold in database.
        /// </summary>
        IEnumerable<IBuilding> Buildings { get; }

        /// <summary>
        /// Add building to database.
        /// </summary>
        /// <param name="building">Building to add.</param>
        void AddBuilding(IBuilding building);

        /// <summary>
        /// Gets a collection of units by type and count.
        /// </summary>
        IDictionary<string, int> Units { get; }

        /// <summary>
        /// Add unit to database.
        /// </summary>
        /// <param name="unit">Unit to add.</param>
        void AddUnit(IUnit unit);

        /// <summary>
        /// Gets a resource by type and count.
        /// </summary>
        IDictionary<ResourceType, int> Resources { get; } 
    }
}
