namespace Problem4GenerateSubsetsOfStringArray
{
    using System;
    using System.Linq;

    public class SubsetOfStringArray
    {
        public static void Main()
        {
            string[] s = {"test", "rock", "fun"};
            // var s = Console.ReadLine().Split().ToArray();
            int k = int.Parse(Console.ReadLine());

            int[] vector = new int[k];
            GenCombinations(s, vector);
        }

        private static void GenCombinations(string[] strings, int[] vector, int index = 0, int start = 0)
        {
            if (index == vector.Length)
            {
                Print(vector, strings);
            }
            else
            {
                for (int i = start; i < strings.Length; i++)
                {
                    vector[index] = i;
                    GenCombinations(strings, vector, index + 1, i +1);
                }
            }
        }

        private static void Print(int[] vector, string[] strings)
        {
            var result = vector.Select(x => strings[x]);
            Console.WriteLine("({0})", string.Join(" ", result));
        }
    }
}
