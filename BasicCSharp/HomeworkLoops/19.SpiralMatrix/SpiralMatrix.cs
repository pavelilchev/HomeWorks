using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];
        int k = 1, c1 = 0, c2 = n - 1, r1 = 0, r2 = n - 1;
        while (k <= n * n)
        {
            for (int i = c1; i <= c2; i++)
            {
                matrix[r1, i] = k++;
            }
            for (int j = r1 + 1; j <= r2; j++)
            {
                matrix[j, c2] = k++;
            }
            for (int i = c2 - 1; i >= c1; i--)
            {
                matrix[r2, i] = k++;
            }
            for (int j = r2 - 1; j >= r1 + 1; j--)
            {
                matrix[j, c1] = k++;
            }
            c1++;
            c2--;
            r1++;
            r2--;
        }
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 3} ", matrix[i, j]);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}


