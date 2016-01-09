namespace Empires.Contracts
{
    /// <summary>
    /// Provides logic for output.
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// Write output string from game.
        /// </summary>
        /// <param name="message">Output message.</param>
        void Print(string message);
    }
}
