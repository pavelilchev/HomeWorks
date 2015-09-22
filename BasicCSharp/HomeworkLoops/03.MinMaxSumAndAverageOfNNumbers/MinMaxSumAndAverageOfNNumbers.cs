using System;

using System.Linq;

class MinMaxSumAndAverageOfNNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] number = new int[n];
        for (int i = 0; i < n; i++)
        {
            number[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("min = {0}", number.Min());
        Console.WriteLine("max = {0}", number.Max());
        Console.WriteLine("sum = {0}", number.Sum());
        Console.WriteLine("avg = {0:0.00}", (decimal)number.Sum()/n);
    }
}

