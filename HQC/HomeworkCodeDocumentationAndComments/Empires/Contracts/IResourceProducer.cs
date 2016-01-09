namespace Empires.Contracts
{
    using Models.EventHandlers;

    public interface IResourceProducer
    {
        /// <summary>
        /// Events is fired when building produce resources.
        /// </summary>
        event ResourceProducedEventHandler OnResourceProduced;
    }
}
