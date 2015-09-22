using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class NumberCalculations
{
    static void Main()
    {
        int[] intNumbers = { 1, 2, 3, 4, 5, 6, 31 };
        double[] doubleNumbers = { 1.1, 2.2, 3.3, 4.4, 5.5 };
        decimal[] decimalNumbers = { 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

        Console.WriteLine(GetMin(intNumbers));
        Console.WriteLine(GetMax(doubleNumbers));
        Console.WriteLine(Average(decimalNumbers));
        Console.WriteLine(Sum(intNumbers));
        Console.WriteLine(Product(doubleNumbers));
    }

    private static decimal Product(decimal[] arr)
    {
        decimal product = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static double Product(double[] arr)
    {
        double product = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static long Product(int[] arr)
    {
        long product = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            product *= arr[i];
        }

        return product;
    }

    private static decimal Sum(decimal[] arr)
    {
        decimal sum = 0m;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static double Sum(double[] arr)
    {
        double sum = 0d;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static long Sum(int[] arr)
    {
        long sum = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return sum;
    }

    private static decimal Average(decimal[] arr)
    {
        decimal sum = 0m;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        decimal average = sum / arr.Length;

        return average;
    }

    private static double Average(double[] arr)
    {
        double sum = 0d;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;

        return average;
    }

    private static double Average(int[] arr)
    {
        double sum = 0d;

        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        double average = sum / arr.Length;

        return average;
    }

    private static decimal GetMax(decimal[] decimalNumbers)
    {
        decimal max = decimal.MinValue;

        for (int i = 0; i < decimalNumbers.Length; i++)
        {
            if (decimalNumbers[i] > max)
            {
                max = decimalNumbers[i];
            }
        }

        return max;
    }

    private static double GetMax(double[] doubleNumbers)
    {
        double max = double.MinValue;

        for (int i = 0; i < doubleNumbers.Length; i++)
        {
            if (doubleNumbers[i] > max)
            {
                max = doubleNumbers[i];
            }
        }

        return max;
    }

    private static int GetMax(int[] intNumbers)
    {
        int max = int.MinValue;

        for (int i = 0; i < intNumbers.Length; i++)
        {
            if (intNumbers[i] > max)
            {
                max = intNumbers[i];
            }
        }

        return max;
    }

    private static int GetMin(int[] intNumbers)
    {
        int min = int.MaxValue;

        for (int i = 0; i < intNumbers.Length; i++)
        {
            if (intNumbers[i] < min)
            {
                min = intNumbers[i];
            }
        }

        return min;
    }

    private static double GetMin(double[] doubleNumbers)
    {
        double min = double.MaxValue;

        for (int i = 0; i < doubleNumbers.Length; i++)
        {
            if (doubleNumbers[i] < min)
            {
                min = doubleNumbers[i];
            }
        }

        return min;
    }

    private static decimal GetMin(decimal[] decimalNumbers)
    {
        decimal min = decimal.MaxValue;

        for (int i = 0; i < decimalNumbers.Length; i++)
        {
            if (decimalNumbers[i] < min)
            {
                min = decimalNumbers[i];
            }
        }

        return min;
    }
}

