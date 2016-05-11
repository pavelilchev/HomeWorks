namespace Problem3Towns
{
    using System;
    using System.Linq;

    public class Towns
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine().Split().First());
            }

            int[] len = new int[n];
            for (int i = 0; i < n; i++)
            {
                len[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j] && len[j] + 1 > len[i])
                    {
                        len[i] = len[j] + 1;
                    }
                }
            }

            int[] lenReverse = new int[n];
            numbers = numbers.Reverse().ToArray();
            for (int i = 0; i < n; i++)
            {
                lenReverse[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j] && lenReverse[j] + 1 > lenReverse[i])
                    {
                        lenReverse[i] = lenReverse[j] + 1;
                    }
                }
            }

            int longestPath = 0;
            int index = n - 1;
            for (int i = 0; i < n; i++)
            {
                if (lenReverse[index] + len[i] > longestPath)
                {
                    longestPath = lenReverse[index] + len[i];
                }
                index--;
            }

            Console.WriteLine(longestPath - 1);
        }
    }
}
