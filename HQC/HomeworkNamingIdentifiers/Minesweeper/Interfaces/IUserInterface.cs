namespace Minesweeper.Interfaces
{
    public interface IUserInterface
    {
        void WriteLine(string format, params object[] args);

        void Write(string format, params object[] args);

        void WriteLine();

        string ReadLine();
    }
}
