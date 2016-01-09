namespace Empires.Contracts
{
    /// <summary>
    /// Every who need to start the game must implement this.
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Start the game loop.
        /// </summary>
        void Run();
    }
}
