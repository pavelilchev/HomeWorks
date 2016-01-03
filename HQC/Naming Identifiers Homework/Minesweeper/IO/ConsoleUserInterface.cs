namespace Minesweeper.IO
{
    using System;
    using Interfaces;

    public class ConsoleUserInterface : IUserInterface
    {
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void Write(string format, params object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine()
        {
           Console.WriteLine();
        }

        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
