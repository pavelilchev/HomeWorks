namespace Problem2Guitar
{
    using System;
    using System.Linq;

    public class Guitar
    {
        public static void Main()
        {
            var intervals =
                Console.ReadLine()
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int n = intervals.Length;
            var initialVolume = int.Parse(Console.ReadLine());
            var higetsPossibleVolume = int.Parse(Console.ReadLine());
            var dp = new int[intervals.Length + 1, higetsPossibleVolume + 1];

            dp[0, initialVolume] = 1;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j <= higetsPossibleVolume; j++)
                {
                    if (dp[i - 1, j] != 0)
                    {
                        if (j - intervals[i - 1] >= 0)
                        {
                            dp[i, j - intervals[i - 1]] = 1;
                        }

                        if (j + intervals[i - 1] <= higetsPossibleVolume)
                        {
                            dp[i, j + intervals[i - 1]] = 1;
                        }
                    }
                }
            }

            int maxVolume = -1;
            for (int i = higetsPossibleVolume; i >= 0; i--)
            {
                if (dp[n, i] > 0)
                {
                    maxVolume = i;
                    break;
                }
            }

            Console.WriteLine(maxVolume);
        }
    }
}
