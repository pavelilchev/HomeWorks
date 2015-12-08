using System;

namespace Problem3AsynchronousTimer
{
    public class TestAsyncTimer
    {
        static void Main(string[] args)
        {
           AsynchronousTimer asyncTimer = new AsynchronousTimer(Print, 5, 1000);

            asyncTimer.Execute();
        }

        private static void Print(int number)
        {
            Console.WriteLine(number);
        }
    }
}
