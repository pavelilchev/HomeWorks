namespace RotatingWalkinInMatrix.IO
{
    public interface IUserInterface
    {
        void Write(string format, params object[] args);

        void WriteLine(string format, params object[] args);

        void WriteLine();

        string ReadLine();
    }
}
