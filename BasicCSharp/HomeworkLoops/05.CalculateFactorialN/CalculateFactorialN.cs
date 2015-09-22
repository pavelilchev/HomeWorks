using System;

class CalculateFactorialN
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); //2
        int x = int.Parse(Console.ReadLine()); //3
        long factorial = 1;
        long powerUp = 1;
        decimal sum = 1;
        for (int i = 1; i <= n; i++)
        {
            factorial *= i;
            powerUp *= x;
            sum += (decimal)factorial / powerUp;
        }
        Console.WriteLine("{0:F5}", sum);
    }
}
