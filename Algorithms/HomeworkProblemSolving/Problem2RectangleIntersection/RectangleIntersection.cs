namespace Problem2RectangleIntersection
{
    using System;
    using System.Linq;

    public class RectangleIntersection
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] map = new int[2001, 2001];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                int[] rect = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int x1 = rect[0] + 1000;
                int x2 = rect[1] + 1000;
                int y1 = rect[2] + 1000;
                int y2 = rect[3] + 1000;
                for (int j = y1; j < y2; j++)
                {
                    for (int k = x1; k < x2; k++)
                    {
                        if (map[j, k] == 1)
                        {
                            count++;
                        }

                        map[j, k]++;
                    }
                }
            }
          
            Console.WriteLine(count);
        }
    }
}
