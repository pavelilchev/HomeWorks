using System;
using System.Text.RegularExpressions;


class ReplaceTag
{
    static void Main()
    {
        string text = @"<ul> <li> <a href= ""http://softuni.bg""> SoftUni </a> </li> </ul>";
        //string text = @"<ul> <li> <a href= 'http://softuni.bg'> SoftUni </a> </li> </ul>";


        string pattern = @"(<a href=(.*?)>).*?(<\/a>)";
        Regex reg = new Regex(pattern);
        MatchCollection matches = reg.Matches(text);

        foreach (Match item in matches)
        {
            string replacement = "[/URL" + item.Groups[2].Value + "]";
            text = text.Replace(item.Groups[1].Value, replacement);
            text = text.Replace(item.Groups[3].Value, @"[/URL]");
        }

        Console.WriteLine(text);
    }
}

