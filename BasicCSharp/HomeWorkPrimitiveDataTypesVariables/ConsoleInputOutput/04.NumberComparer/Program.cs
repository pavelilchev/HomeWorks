using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter first number:");
        double firstNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter second number:");
        double secondNumber = double.Parse(Console.ReadLine());
        bool greaterAB = (firstNumber > secondNumber);

        Console.WriteLine("greater number is: " + (greaterAB ? firstNumber : secondNumber));
    }
}

