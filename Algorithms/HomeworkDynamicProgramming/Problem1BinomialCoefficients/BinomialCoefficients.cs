namespace Problem1BinomialCoefficients
{
    using System;

    public class BinomialCoefficients
    {
        private static decimal[][] memo;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            if (k > n || k < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            memo = new decimal[n + 1][];
            memo[0] = new decimal[1];
            memo[0][0] = 1;

            for (int i = 1; i <= n; i++)
            {
                memo[i] = new decimal[i + 1];
                memo[i][0] = 1;
                memo[i][i] = 1;
            }

            decimal coeff = FindBinomialCoefficient(n, k);
            Console.WriteLine(coeff);
        }

        private static decimal FindBinomialCoefficient(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            if (memo[n][k] != 0)
            {
                return memo[n][k];
            }

            memo[n][k] = FindBinomialCoefficient(n - 1, k - 1) + FindBinomialCoefficient(n - 1, k);

            return memo[n][k];
        }
    }
}
