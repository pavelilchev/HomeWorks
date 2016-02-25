namespace RotatingWalkinInMatrix.IO
{
    using System;

    public class ConsoleUserInterface : IUserInterface
    {
        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public string ReadLine()
        {
            string input = Console.ReadLine();
            return input;
        }
    }
}
