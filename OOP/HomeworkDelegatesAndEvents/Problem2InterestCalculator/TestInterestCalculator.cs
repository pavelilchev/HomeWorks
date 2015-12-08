using System;

namespace Problem2InterestCalculator
{
    public class TestInterestCalculator
    {
        static void Main(string[] args)
        {
            var compaundResult = new InterestCalculator(500m, 0.056m, 10, GetCompoundInterest);

            var simpleResult = new InterestCalculator(2500m, 0.072m, 15, GetSimpleInterest);

            Console.WriteLine(compaundResult.Balance);
            Console.WriteLine(simpleResult.Balance);
        }

        public static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            return decimal.Round(sum * (1 + (interest * years)),4);
        }

        public static decimal GetCompoundInterest(decimal sum, decimal interest, int year)
        {
            int n = 12;
            double multipleFactor = year * n;
            decimal interestFactor = 1;

            for (int i = 0; i < multipleFactor; i++)
            {
                interestFactor *= (1 + (interest / n));
            }

            return decimal.Round((interestFactor*sum),4);
        }
    }
}
