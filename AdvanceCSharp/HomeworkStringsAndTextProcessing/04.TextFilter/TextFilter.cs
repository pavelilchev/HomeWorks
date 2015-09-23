using System;
using System.Text;


class TextFilter
{
    static void Main()
    {
        string[] banList = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder();
        result.Append(text);

        foreach (var banWord in banList)
        {
            result.Replace(banWord, new string('*', banWord.Length));
        }

        Console.WriteLine();
        Console.WriteLine(result);
    }
}

