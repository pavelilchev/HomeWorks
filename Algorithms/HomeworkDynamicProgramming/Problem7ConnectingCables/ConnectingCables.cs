namespace Problem7ConnectingCables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectingCables
    {
        public static void Main()
        {
            int[] side1 =
                Console.ReadLine()
                    .Split(new[] { '=', '{', '}', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();


            int[] side2 =
                Console.ReadLine()
                    .Split(new[] { '=', '{', '}', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .Select(int.Parse)
                    .ToArray();

            FindMaxConnections(side1, side2);
        }

        private static void FindMaxConnections(int[] side1, int[] side2)
        {
            int firstLen = side1.Length;
            int secondLen = side2.Length;
            int[,] connectingCounts = new int[firstLen + 1, secondLen + 1];

            for (int i = 1; i <= firstLen; i++)
            {
                for (int j = 1; j <= secondLen; j++)
                {
                    if (side1[i - 1] == side2[j - 1])
                    {
                        connectingCounts[i, j] = connectingCounts[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        connectingCounts[i, j] = Math.Max(connectingCounts[i - 1, j], connectingCounts[i, j - 1]);
                    }
                }
            }

            Console.WriteLine(connectingCounts[firstLen, secondLen]);
            var result = new Stack<int>();

            while (firstLen > 0 && secondLen > 0)
            {
                if (side1[firstLen - 1] == side2[secondLen - 1])
                {
                    result.Push(firstLen);
                    firstLen--;
                    secondLen--;
                }
                else
                {
                    if (connectingCounts[firstLen - 1, secondLen] == connectingCounts[firstLen, secondLen])
                    {
                        firstLen--;
                    }
                    else
                    {
                        secondLen--;
                    }
                }
            }

            Console.WriteLine($"Connected pairs: {string.Join(" ", result)}");
        }
    }
}
