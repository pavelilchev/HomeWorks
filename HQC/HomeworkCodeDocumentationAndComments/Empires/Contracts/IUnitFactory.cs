namespace Empires.Contracts
{
    /// <summary>
    /// Implement factory design pattern for units.
    /// </summary>
    public interface IUnitFactory
    {
        /// <summary>
        /// Create a unit and return it.
        /// </summary>
        /// <param name="unitType">unit type.</param>
        /// <returns>Created unit like IUnit.</returns>
        IUnit CreateUnit(string unitType);
    }
}
