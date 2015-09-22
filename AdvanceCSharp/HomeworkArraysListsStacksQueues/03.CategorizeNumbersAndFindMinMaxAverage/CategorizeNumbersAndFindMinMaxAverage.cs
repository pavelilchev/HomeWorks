using System;
using System.Collections.Generic;
using System.Linq;

public class CategorizeNumbersAndFindMinMaxAverage
{
    public static void Main()
    {
        Console.WriteLine("Enter numbers separated whit single space");

        double[] numbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

        List<double> intNumbers = new List<double>();
        List<double> floatNumbers = new List<double>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] % 1 == 0)
            {
                intNumbers.Add(numbers[i]);
            }
            else
            {
                floatNumbers.Add(numbers[i]);
            }
        }

        Console.Write("[{0}]", string.Join(", ", floatNumbers));
        Console.Write(" -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}",
            floatNumbers.Min(), floatNumbers.Max(), floatNumbers.Sum(), floatNumbers.Average());
        Console.WriteLine();
        Console.Write("[{0}]", string.Join(", ", intNumbers));
        Console.Write(" -> min: {0}, max: {1}, sum: {2}, avg: {3:F2}",
            intNumbers.Min(), intNumbers.Max(), intNumbers.Sum(), intNumbers.Average());
        Console.WriteLine();
    }
}

