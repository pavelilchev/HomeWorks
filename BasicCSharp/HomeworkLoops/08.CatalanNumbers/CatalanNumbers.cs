using System;
using System.Numerics;
class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); //5
       
        BigInteger TwonFactorial = 1;
        BigInteger kFactorial = 1;
        BigInteger nFactorial = 1;
        int k = n + 1; //6
        int c = n;     //5
        int a = 2 * n; //10
        for (int i = a; a > 0; a--)
        {
            TwonFactorial *= a;
            if (c == a)
            {
                kFactorial *= a;
                c--;
            }
            if (k == a)
            {
                nFactorial *= a;
                k--;
            }
        }
        BigInteger result = TwonFactorial / (kFactorial * nFactorial);
        Console.WriteLine(result);
    }
}
