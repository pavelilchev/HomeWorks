using System;
using System.Text.RegularExpressions;


class SentenceExtractor
{
    static void Main()
    {
        string key = Console.ReadLine();
        string text = Console.ReadLine();
        string pattern = @"\b([\w\s]*\b" + key + @"\b[\w\s]*[!?.])?";
        Regex reg = new Regex(pattern);
        MatchCollection sentences = reg.Matches(text);

        foreach (Match sentence in sentences)
        {
            if (sentence.ToString() != "")
            {
                Console.WriteLine(sentence);
            }
        }
    }
}

