namespace Problem3CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        public static void Main()
        {
            int n = 5;
            int k = 3;
            int[] vector = new int[k];
            GenerateCombinations(vector, 0, 1, n);
        }

        private static void GenerateCombinations(int[] vector, int index, int start, int n)
        {
            if (index == vector.Length)
            {
                Print(vector);
                return;
            }

            for (int i = start; i <= n; i++)
            {
                vector[index] = i;
                GenerateCombinations(vector, index + 1, i, n);
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine("({0})", string.Join(" ", vector));
        }
    }
}
