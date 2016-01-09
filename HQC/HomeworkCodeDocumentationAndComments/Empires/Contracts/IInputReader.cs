namespace Empires.Contracts
{
    /// <summary>
    /// Handle the input.
    /// </summary>
    public interface IInputReader
    {
        /// <summary>
        /// Handle input string.
        /// </summary>
        /// <returns>Input string.</returns>
        string ReadLine();
    }
}
