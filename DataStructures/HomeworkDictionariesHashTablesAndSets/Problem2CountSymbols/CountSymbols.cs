namespace Problem2CountSymbols
{
    using System;
    using System.Collections.Generic;

    public class CountSymbols
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            if (input == null)
            {
                return;
            }

            var charOccurrences = new SortedDictionary<char, int>();

            foreach (char c in input)
            {
                if (!charOccurrences.ContainsKey(c))
                {
                    charOccurrences.Add(c, 1);
                }
                else
                {
                    charOccurrences[c]++;
                }
            }

            foreach (var pair in charOccurrences)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}
