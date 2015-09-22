using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter 5 numbers, separated by a space:");
        string fiveNumbers = Console.ReadLine();
        string [] numbers = fiveNumbers.Split(' ');
        double numberOne = double.Parse(numbers[0]);
        double numberTwo = double.Parse(numbers[1]);
        double numberThree = double.Parse(numbers[2]);
        double numberFour = double.Parse(numbers[3]);
        double numberFive = double.Parse(numbers[4]);
        Console.WriteLine("Sum is: " + (numberOne+numberTwo+numberThree+numberFour+numberFive));
    }
}

