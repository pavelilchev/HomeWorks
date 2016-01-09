namespace Empires.Contracts
{
    /// <summary>
    /// Implement factory design pattern for buildings.
    /// </summary>
    public interface IBuildingFactory
    {
        /// <summary>
        /// Create building.
        /// </summary>
        /// <param name="buildingType">Type of building.</param>
        /// <param name="unitFactory">Unit Factory.</param>
        /// <param name="resourceFactory">Resource factory.</param>
        /// <returns>Building like IBuilding.</returns>
        IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFactory);
    }
}
