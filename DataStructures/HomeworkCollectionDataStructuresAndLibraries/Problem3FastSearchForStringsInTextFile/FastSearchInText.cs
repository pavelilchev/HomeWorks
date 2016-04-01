namespace Problem3FastSearchForStringsInTextFile
{
    using System;
    using System.Collections.Generic;

    public class FastSearchInText
    {
        public static void Main()
        {
            int searchStringsCount = int.Parse(Console.ReadLine());
            var searchStrings = new Dictionary<string, int>();
            var searched = new List<string>();
            for (int i = 0; i < searchStringsCount; i++)
            {
                string word = Console.ReadLine();
                searchStrings.Add(word, 0);
                searched.Add(word);
            }
            
            int linesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesCount; i++)
            {
                string line = Console.ReadLine();
                foreach (var word in searched)
                {
                    int index = line.IndexOf(word, StringComparison.InvariantCultureIgnoreCase);

                    while (index >= 0)
                    {
                        searchStrings[word]++;
                        index = line.IndexOf(word, index + 1, StringComparison.InvariantCultureIgnoreCase);
                    }
                }
            }

            foreach (var searchString in searchStrings)
            {
                Console.WriteLine("{0} -> {1}", searchString.Key, searchString.Value);
            }
        }
    }
}
