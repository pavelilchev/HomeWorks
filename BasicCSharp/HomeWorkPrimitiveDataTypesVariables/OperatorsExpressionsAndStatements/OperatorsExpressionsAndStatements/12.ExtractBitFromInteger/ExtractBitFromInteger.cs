using System;

class ExtractBitFromInteger
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter position:");
        int p = int.Parse(Console.ReadLine());

        int mask = 1 << p;
        if ((mask&n)==mask)
        {
            Console.WriteLine(1);
        }
        else
        {
            Console.WriteLine(0);
        }
    }
}

