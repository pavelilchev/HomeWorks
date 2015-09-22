using System;
using System.Numerics;

class TrailingZeroesInNFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger factorial = 1;
        int counter = 0;
        for (int i = n; n > 0; n--)
        {
            factorial *= n;
        }
        while((factorial % 10) == 0)
        {
            counter++;
            factorial /= 10;
        }
        Console.WriteLine(counter);
    }
}

