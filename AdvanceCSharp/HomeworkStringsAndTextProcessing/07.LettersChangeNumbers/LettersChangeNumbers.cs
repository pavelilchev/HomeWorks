using System;


class LettersChangeNumbers
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        decimal sum = 0m;

        foreach (var item in input)
        {
            sum += CalculateSum(item);
        }

        Console.WriteLine("{0:F2}", sum);
    }

    private static decimal CalculateSum(string str)
    {
        decimal number = decimal.Parse(str.Substring(1, str.Length - 2));

        if (char.IsUpper(str[0]))
        {
            number /= str[0] - 'A' + 1.00m;
        }
        else
        {
            number *= str[0] - 'a' + 1.00m;
        }

        if (char.IsUpper(str[str.Length-1]))
        {
            number -= str[str.Length - 1] - 'A' + 1.00m;
        }
        else
        {
            number += str[str.Length - 1] - 'a' + 1.00m;
        }

        return number;
    }
}
