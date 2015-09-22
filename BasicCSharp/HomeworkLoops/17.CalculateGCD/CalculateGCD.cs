using System;

class CalculateGCD
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int max = Math.Max(a, b);
        int min = Math.Min(a, b);
        int result = 0;
        int rest = 1;
        while (true)
        {
            if (rest != 0)
            {
                rest = max % min;
                result = max / min;
                max = min;
                min = rest;
            }
            else
            {
                Console.WriteLine(max);
                break;
            }
        }
    }
}

