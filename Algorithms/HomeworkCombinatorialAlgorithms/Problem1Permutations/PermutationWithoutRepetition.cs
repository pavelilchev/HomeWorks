namespace Problem1Permutations
{
    using System;
    using System.Linq;

    public class PermutationWithoutRepetition
    {
        private static int[] numbers;
        private static int totalPermutation = 0;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            numbers = Enumerable.Range(1, n).ToArray();

            GenPermutation();
            Console.WriteLine("Total permutations: " + totalPermutation);
        }

        private static void GenPermutation(int index = 0, int start = 0)
        {
            if (index == numbers.Length)
            {
                totalPermutation++;
                Print();
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

        private static void Print()
        {
            Console.WriteLine("({0})", string.Join(", ", numbers));
        }
    }
}
