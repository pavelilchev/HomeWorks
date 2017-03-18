namespace _6.MathUtilities
{
    public static class MathUtil
    {
        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Subtract(double a, double b)
        {
            return a - b;
        }

        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double dividend, double divisor)
        {
            return dividend / divisor;
        }
        public static double Percentage(double totalNumber, double percent)
        {
            return totalNumber * percent / 100;
        }
    }
}
