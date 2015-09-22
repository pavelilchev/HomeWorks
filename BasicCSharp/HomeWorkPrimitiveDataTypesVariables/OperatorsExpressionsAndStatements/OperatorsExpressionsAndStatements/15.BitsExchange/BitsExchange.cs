using System;

class BitsExchange
{
    static void Main()
    {
        Console.Write("Enter the unsigned integer number n:");
        uint n = uint.Parse(Console.ReadLine());
        Console.WriteLine("binary initial n:");
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
        n = ((~(7u << 24 | 7u << 3)) & n) | (((n & (7u << 3)) << 21) | ((n & (7u << 24)) >> 21));
        Console.WriteLine("binary new n:");
        Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
    }
}

