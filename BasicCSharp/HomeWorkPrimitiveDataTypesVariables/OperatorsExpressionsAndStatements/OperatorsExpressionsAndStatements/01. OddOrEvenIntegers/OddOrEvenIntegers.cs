using System;

class OddOrEvenIntegers
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine((n % 2 == 0) ? true : false);    
    }
}

