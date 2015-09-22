using System;
using System.Numerics;
class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger nFactorial = 1;
        BigInteger kFactorial = 1;
        for (int i = n; n > 0; n--)
        {
            nFactorial *= n;
            if (n == k)
            {
                kFactorial *= n;
                k--;
            }
        }
        Console.WriteLine(nFactorial / kFactorial);
    }
}

