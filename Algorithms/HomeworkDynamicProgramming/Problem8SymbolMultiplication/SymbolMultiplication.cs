namespace Problem8SymbolMultiplication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SymbolMultiplication
    {
        static StringBuilder sb = new StringBuilder();
        public static void Main()
        {
            char[] alphabet =
                Console.ReadLine()
                    .Split(new[] { '=', ' ', '{', '}', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(x => x[0])
                    .ToArray();

            Console.ReadLine();
            int len = alphabet.Length;
            var table = new Dictionary<Tuple<char, char>, char>();
            for (int i = 0; i < len; i++)
            {
                string row = Console.ReadLine().Trim();
                for (int j = 0; j < len; j++)
                {
                    table.Add(new Tuple<char, char>(alphabet[i], alphabet[j]), row[j]);
                }
            }

            string s = Console.ReadLine().Split(new[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray()[1];

            FindSolution(len, s, table);

        }

        private static void FindSolution(int len, string s, Dictionary<Tuple<char, char>, char> table)
        {
            for (int i = 0; i < len-1; i++)
            {
                var tuple = new Tuple<char, char>(s[i], s[i + 1]);
            }
        }
    }
}
