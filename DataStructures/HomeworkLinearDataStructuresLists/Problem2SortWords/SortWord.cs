namespace Problem2SortWords
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SortWord
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                return;
            }

            List<string> words = input.Split().ToList();
            words.Sort();

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
