using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class SumAndAverage
{
    static void Main()
    {
        string str = Console.ReadLine();

        List<int> num = new List<int>();

        if (!string.IsNullOrEmpty(str))
        {
            num.AddRange(str.Split().Select(int.Parse).ToArray());
        }

        int sum = 0;
        double average = 0d;

        if (num.Count != 0)
        {
            sum = num.Sum();
            average = num.Average();
        }

        Console.WriteLine("Sum = {0}", sum);
        Console.WriteLine("Average = {0}", average);

    }
}

