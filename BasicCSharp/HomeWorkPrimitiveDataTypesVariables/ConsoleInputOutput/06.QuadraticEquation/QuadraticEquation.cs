using System;

class QuadraticEquation
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter c:");
        double c = double.Parse(Console.ReadLine());
        double D = b * b - 4 * a * c;
        double sqrtD = Math.Sqrt(D);
        if (D < 0)
        {
            Console.WriteLine("No real roots!");
        }
        if (D == 0)
        {
            Console.WriteLine("x1 = x2 = " + (-b / (2 * a)));
        }
        if (D > 0)
        {
            Console.WriteLine("x1 = " + ((-b - sqrtD) / (2 * a)));
            Console.WriteLine("x2 = " + ((-b + sqrtD) / (2 * a)));
        }

    }
}