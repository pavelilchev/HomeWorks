namespace _5PlanckConstant
{
    using System;
    using System.Text.RegularExpressions;

    public class Calculation
    {
        private static double Plank = 6.62606896e-34;
        private static double Pi = 3.14159;

        public static double CalculateStrangeResult()
        {
            return Plank / (2 * Pi);
        }
    }
}
