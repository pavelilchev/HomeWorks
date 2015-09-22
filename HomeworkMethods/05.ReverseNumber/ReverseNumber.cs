using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ReverseNumber
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());

        double reversedNumber = ReverseDouble(number);
        Console.WriteLine(reversedNumber);
    }

    private static double ReverseDouble(double number)
    {
        string numString = number.ToString();
        StringBuilder sb = new StringBuilder();

        for (int i = numString.Length - 1; i >= 0; i--)
        {
            sb.Append(numString[i]);
        }

        double result = double.Parse(sb.ToString());

        return result;
    }
}

