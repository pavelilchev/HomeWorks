using System;

class BitwiseExtractBit3
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int n = int.Parse(Console.ReadLine());

        int mask = 1 << 3;
        if ((mask & n) == mask )
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}

