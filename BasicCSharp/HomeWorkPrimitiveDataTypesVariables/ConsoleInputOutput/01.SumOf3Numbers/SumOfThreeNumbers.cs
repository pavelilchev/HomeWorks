using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double secondNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter fthird number:");
        double fthirdNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("The sum is: " + (firstNumber+secondNumber+fthirdNumber));

    }
}

