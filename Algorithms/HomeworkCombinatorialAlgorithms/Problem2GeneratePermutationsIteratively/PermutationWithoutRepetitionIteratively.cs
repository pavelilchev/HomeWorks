namespace Problem2GeneratePermutationsIteratively
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class PermutationWithoutRepetitionIteratively
    {
        private static int[] numbers;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = Enumerable.Range(1, n).ToArray();
            int[] p = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                p[i] = i;
            }

           // Print();
            int upperIndex = 1;
            var sw = new Stopwatch();
            sw.Start();
            while (upperIndex < n)
            {
                p[upperIndex]--;
                int lowerIndex = upperIndex % 2 * p[upperIndex];
                Swap(ref numbers[lowerIndex], ref numbers[upperIndex]);
               // Print();
                upperIndex = 1;
                while (p[upperIndex] == 0)
                {
                    p[upperIndex] = upperIndex;
                    upperIndex++;
                }
            }

            Console.WriteLine("Iteratively: "  + sw.Elapsed);
            sw.Restart();
            GenPermutation();
            Console.WriteLine("Recursively: " + sw.Elapsed);
        }

        private static void Print()
        {
            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Swap(ref int i, ref int j)
        {
            if (i == j)
            {
                return;
            }

            i ^= j;
            j ^= i;
            i ^= j;
        }

        private static void GenPermutation(int index = 0, int start = 0)
        {
            if (index == numbers.Length)
            {
                //Print();
            }
            else
            {
                for (int i = start; i < numbers.Length; i++)
                {
                    Swap(ref numbers[index], ref numbers[i]);
                    GenPermutation(index + 1, start + 1);
                    Swap(ref numbers[i], ref numbers[index]);
                }
            }
        }
    }
}
