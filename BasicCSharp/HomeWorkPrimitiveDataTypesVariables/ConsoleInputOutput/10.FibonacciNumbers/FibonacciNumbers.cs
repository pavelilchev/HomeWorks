using System;

class FibonacciNumbers
{
    static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        long sum = 0;
        long numberOne = 0;
        long numberTwo = 1;
        if (n == 1)
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.Write(0 + " ");
            Console.Write(1 + " ");
        }
        for (int i = 2; i < n; i++)
        {
            sum = numberOne + numberTwo;
            Console.Write(sum + " ");
            numberOne = numberTwo;
            numberTwo = sum;
        }

    }
}

