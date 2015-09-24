using System;
using System.Text.RegularExpressions;


class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(?<=\s|^)([a-z0-9]+(?:[_.-][a-z0-9]+)*@(?:[a-z]+\-?[a-z]+\.)+[a-z]+\-?[a-z]+)\b";

        Regex reg = new Regex(pattern);
        MatchCollection emails = reg.Matches(input);

        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}

