using System;

class CheckABitAtGivenPosition
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter position:");
        int position = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter bit value:");
        int bitValue = int.Parse(Console.ReadLine());
        int mask = 1 << position;
        if (bitValue == 1)
        {
            int newNumber = number | mask;
            Console.WriteLine(newNumber);
        }
        else
        {
            int newNumber = number & ~mask;
            Console.WriteLine(newNumber);
        }
    }
}