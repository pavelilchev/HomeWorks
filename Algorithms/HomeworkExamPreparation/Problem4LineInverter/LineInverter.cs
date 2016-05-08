namespace Problem4LineInverter
{
    using System;
    using System.Linq;

    public class LineInverter
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new bool[n, n];
            int[] whiteCounts = new int[2*n];
            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    if (row[j] == 'W')
                    {
                        matrix[i, j] = true;
                        whiteCounts[i]++;
                        whiteCounts[n + j]++;
                    }
                }
            }

            for (int iteration = 0; iteration < 2*n; iteration++)
            {
                int maxWhite = whiteCounts.Max();
                if (maxWhite == 0)
                {
                    Console.WriteLine(iteration);
                    return;
                }

                int maxWhiteIndex = -1;
                for (int i = 0; i < 2*n; i++)
                {
                    if (whiteCounts[i] == maxWhite)
                    {
                        maxWhiteIndex = i;
                        break;
                    }
                }

                if (maxWhiteIndex < n)
                {
                    whiteCounts[maxWhiteIndex] = n - whiteCounts[maxWhiteIndex];
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[maxWhiteIndex, i])
                        {
                            whiteCounts[i+n]--;
                        }
                        else
                        {
                            whiteCounts[i+n]++;
                        }

                        matrix[maxWhiteIndex, i] = !matrix[maxWhiteIndex, i];
                    }
                }
                else
                {
                    whiteCounts[maxWhiteIndex] = n - whiteCounts[maxWhiteIndex];
                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[i, maxWhiteIndex - n])
                        {
                            whiteCounts[i]--;
                        }
                        else
                        {
                            whiteCounts[i]++;
                        }

                        matrix[i, maxWhiteIndex - n] = !matrix[i, maxWhiteIndex - n];
                    }
                }
            }

            Console.WriteLine(-1);
        }
    }
}
