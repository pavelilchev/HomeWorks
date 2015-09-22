using System;

class BinaryToDecimalNumber
{
    static void Main()
    {
        string input = Console.ReadLine(); //11
        int postion = input.Length;
        long number = 0;
        double pow = 0;      
        for (int i = postion - 1; i >= 0; i--)
        {
            number += (int)Char.GetNumericValue(input[i]) * (long)Math.Pow(2, pow);
            pow++;
        }
        Console.WriteLine(number);
    }
}

