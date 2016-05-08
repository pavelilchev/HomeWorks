namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoops
    {
        public static void Main()
        {
            int n = 3;
            // int n = int.Parse(Console.ReadLine());
            var vector = new int[n];
            FindSequence(n, 0, vector);
        }

        private static void FindSequence(int n, int index, int[] vector)
        {
            if (index == n)
            {
                Print(vector);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                vector[index] = i;
                FindSequence(n, index + 1, vector);
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}
