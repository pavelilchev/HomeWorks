namespace Problem2Bridges
{
    using System;
    using System.Linq;

    public class Bridges
    {
        public static void Main()
        {
            int[] north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] south = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int firstLen = north.Length;
            int secondLen = south.Length;
            int[,] maxBridges = new int[firstLen, secondLen];
            if (north[0] == south[0])
            {
                maxBridges[0, 0] = 1;
            }
            for (int i = 1; i < firstLen; i++)
            {
                maxBridges[i, 0] = maxBridges[i - 1, 0];
                if (north[i] == south[0])
                {
                    maxBridges[i, 0]++;
                }
            }

            for (int i = 1; i < secondLen; i++)
            {
                maxBridges[0, i] = maxBridges[0, i -1];
                if (north[0] == south[i])
                {
                    maxBridges[0, i]++;
                }
            }

            for (int i = 1; i < firstLen; i++)
            {
                for (int j = 1; j < secondLen; j++)
                {
                    maxBridges[i, j] = Math.Max(maxBridges[i - 1, j], maxBridges[i, j - 1]);
                    if (north[i] == south[j])
                    {
                        maxBridges[i, j]++;
                    }
                }
            }

            //for (int i = 0; i < firstLen; i++)
            //{
            //    for (int j = 0; j < secondLen; j++)
            //    {
            //        Console.Write("{0,-3}", maxBridges[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            Console.WriteLine(maxBridges[firstLen - 1, secondLen - 1]);
        }
    }
}
