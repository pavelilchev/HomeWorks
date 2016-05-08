namespace Problem3GenerateCombinationsIteratively
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class IterativelyCombinations
    {
        private static int n;

        static void Main()
        {
            n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            var sw = new Stopwatch();
            sw.Start();
            GenCombinationsIterative(k, n);
            Console.WriteLine("Iterative combinations: " + sw.Elapsed);
            int[] vector = new int[k];

            sw.Restart();
            GenCombinationRecursive(vector);
            Console.WriteLine("Recursive combinations: " + sw.Elapsed);
        }

        private static void GenCombinationRecursive(int[] vector, int index = 0, int start = 1)
        {
            if (index == vector.Length)
            {
                // Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = start; i <= n; i++)
                {
                    vector[index] = i;
                    GenCombinationRecursive(vector, index + 1, i + 1);
                }
            }
        }

        private static void GenCombinationsIterative(int k, int n)
        {
            int[] result = new int[k];
            Stack<int> stack = new Stack<int>();
            stack.Push(1);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        // Console.WriteLine(string.Join(" ", result));
                        break;
                    }
                }
            }
        }
    }
}
