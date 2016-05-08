namespace Problem5PermutationsWithRepetition
{
    using System;
    using System.Linq;

    public class PermutationsWithRepetition
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).OrderBy(x => x).ToArray();
            Console.WriteLine();
            Console.WriteLine(string.Join(" ", numbers));
            Permutate(numbers, 0, numbers.Length);
        }

        public static void Permutate(int[] numbers, int start, int n)
        {
            if (start < n)
            {
                for (int i = n - 2; i >= start; i--)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (numbers[i] != numbers[j])
                        {
                            Swap(ref numbers[i], ref numbers[j]);
                            Console.WriteLine(string.Join(" ", numbers));
                            Permutate(numbers, i + 1, n);
                        }
                    }

                    int tmp = numbers[i];
                    for (int k = i; k < n - 1;)
                    {
                        numbers[k] = numbers[++k];
                    }

                    numbers[n - 1] = tmp;
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
    }
}
