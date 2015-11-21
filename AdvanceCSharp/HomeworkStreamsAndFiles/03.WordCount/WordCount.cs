using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        Dictionary<string, int> wordData = new Dictionary<string, int>();

        StreamReader wordReader = new StreamReader(@"..\..\word.txt");
        StreamReader textReader = new StreamReader(@"..\..\text.txt");
        StreamWriter writer = new StreamWriter(@"..\..\result.txt");

        using (wordReader)
        {
            string line = wordReader.ReadLine();

            while (line != null)
            {
                if (!wordData.ContainsKey(line))
                {
                    wordData.Add(line, 0);
                } 

                line = wordReader.ReadLine();
            }
        }

        List<string> text = new List<string>();

        using (textReader)
        {
            string line = textReader.ReadLine();

            while (line != null)
            {
                text.Add(line.ToLower());
                line = textReader.ReadLine();
            }
        }

        string pattern = @"(\w+)";
        Regex reg = new Regex(pattern);

        foreach (var line in text)
        {
            MatchCollection matches = reg.Matches(line);

            foreach (Match word in matches)
            {
                if (wordData.ContainsKey(word.ToString()))
                {
                    wordData[word.ToString()]++;
                }
            }
        }

        var sortedWordData = wordData.OrderByDescending(x => x.Value);
        using (writer)
        {
            foreach (var word in sortedWordData)
            {
                writer.WriteLine("{0} - {1}", word.Key, word.Value);
            }
        }
    }
}
