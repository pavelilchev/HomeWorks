using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main(string[] args)
    {
        string text = Console.ReadLine();

        Regex regex = new Regex(@"(.)\1+");

        Console.WriteLine(regex.Replace(text, "$1"));
    }
}

