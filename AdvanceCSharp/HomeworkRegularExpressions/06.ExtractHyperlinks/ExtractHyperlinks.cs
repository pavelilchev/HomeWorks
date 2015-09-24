using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

class ExtractHyperlinks
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(input);

        while (input != "END")
        {
            input = Console.ReadLine();
            sb.Append(input);
        }

        string tagPattern = @"<a([^>]+)>(.*?)<\/a>";       
        string hrefPattern = "\\s*href\\s*=\\s*(\"([^\"]*)\"|'([^']*)'|([^'\">\\s]+))";
        Regex reg = new Regex(tagPattern);
        MatchCollection tagMatches = reg.Matches(sb.ToString());

        Regex linkRegex = new Regex(hrefPattern);

        foreach (Match item in tagMatches)
        {
           Match extractedLink = linkRegex.Match(item.ToString());

            if (extractedLink.Groups[2].Value.ToString() != "")
            {
                Console.WriteLine(extractedLink.Groups[2].Value);
            }
            else if(extractedLink.Groups[3].Value.ToString() != "")
            {
                Console.WriteLine(extractedLink.Groups[3].Value);
            }
            else if(extractedLink.Groups[4].Value.ToString() != "")
            {
                Console.WriteLine(extractedLink.Groups[4].Value);
            }
        }
    }
}

