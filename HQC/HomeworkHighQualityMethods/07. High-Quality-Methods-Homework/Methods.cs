namespace Methods
{
    using System;

    public static class Methods
    {
        private static void Main()
        {
            try
            {
                Console.WriteLine(CalcTriangleArea(3, 4, 5));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                Console.WriteLine(NumberToDigit(5));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                Console.WriteLine(PrintAsNumber(1.3, "f"));
                Console.WriteLine(PrintAsNumber(0.75, "%"));
                Console.WriteLine(PrintAsNumber(2.30, "r"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            bool horizontal;
            bool vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            string peterOtherIno = "From Sofia, born at 17.03.1992";
            Student peter = new Student("Peter", "Ivanov", peterOtherIno);

            string stelaOtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";
            Student stella = new Student("Stella", "Markova", stelaOtherInfo);

            try
            {
                Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            {
                throw new ArgumentException("Sides cannot form triangle.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        private static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!", nameof(number));
            }
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException(nameof(elements));
            }

            int maxElement = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        private static string PrintAsNumber(object number, string format)
        {
            string result;

            switch (format)
            {
                case "f":
                    result = $"{number:f2}";
                    break;
                case "%":
                    result = $"{number:p0}";
                    break;
                case "r":
                    result = $"{number,8}";
                    break;
                default:
                    throw new ArgumentException("Unknown format.");
            }

            return result;
        }

        private static double CalcDistance(
            double x1,
            double y1,
            double x2,
            double y2,
            out bool isHorizontal,
            out bool isVertical)
        {
            const double Tolerance = 0.00001;

            isHorizontal = Math.Abs(y1 - y2) < Tolerance;
            isVertical = Math.Abs(x1 - x2) < Tolerance;

            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }
    }
}
