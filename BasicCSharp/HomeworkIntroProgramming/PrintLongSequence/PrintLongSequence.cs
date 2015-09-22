using System;


class Program
{
    static void Main()
    {
        // using for loop
        for (int i = 2; i < 1002; i++)
        {
            Console.WriteLine("{0}", i % 2 == 0 ? i : -i);
        }
    }
}