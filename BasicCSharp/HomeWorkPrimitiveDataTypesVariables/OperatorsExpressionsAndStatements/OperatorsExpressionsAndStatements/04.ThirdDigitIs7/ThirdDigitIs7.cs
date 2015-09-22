using System;

class ThirdDigitIs7
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        int thirdDigit = (number / 100) % 10;
        Console.WriteLine(thirdDigit == 7 ? true : false);
    }
}

