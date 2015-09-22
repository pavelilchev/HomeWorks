using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.WriteLine("Enter number:");
        int number = int.Parse(Console.ReadLine());
        int firstDigit = number % 10;
        int secondDigit = (number / 10) % 10;
        int thirdDigit = (number / 100) % 10;
        int fourthDigit = number / 1000;
       
        Console.WriteLine("Sum of digits is: " + (firstDigit + secondDigit + thirdDigit + fourthDigit));
        Console.WriteLine(1000 * firstDigit + 100 * secondDigit + 10 * thirdDigit + fourthDigit);
        Console.WriteLine(firstDigit.ToString() + fourthDigit + thirdDigit + secondDigit);
        Console.WriteLine(fourthDigit.ToString() + secondDigit + thirdDigit + fourthDigit);
    }
}

