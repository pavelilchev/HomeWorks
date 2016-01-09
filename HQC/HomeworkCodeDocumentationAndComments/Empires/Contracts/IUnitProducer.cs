namespace Empires.Contracts
{
    using Models.EventHandlers;

    public interface IUnitProducer
    {
        /// <summary>
        /// This is fired when building produce unit.
        /// </summary>
        event UnitProducedEventHandler OnUnitProduced;
    }
}
