namespace _6.MathUtilities
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine();

            while (line != "End")
            {
                var parameters = line.Split();
                double a = double.Parse(parameters[1]);
                double b = double.Parse(parameters[2]);
                double result = 0;
                switch (parameters[0])
                {
                    case "Sum":
                        result = MathUtil.Sum(a, b);
                        break;
                    case "Subtract":
                        result = MathUtil.Subtract(a, b);
                        break;
                    case "Multiply":
                        result = MathUtil.Multiply(a, b);
                        break;
                    case "Divide":
                        result = MathUtil.Divide(a, b);
                        break;
                    case "Percentage":
                        result = MathUtil.Percentage(a, b);
                        break;
                }

                Console.WriteLine($"{result:f2}");
                line = Console.ReadLine();
            }
        }
    }
}
