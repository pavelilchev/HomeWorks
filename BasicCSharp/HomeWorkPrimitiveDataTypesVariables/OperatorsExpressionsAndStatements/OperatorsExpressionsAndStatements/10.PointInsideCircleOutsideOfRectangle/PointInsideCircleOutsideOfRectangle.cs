using System;

class PointInsideCircleOutsideOfRectangle
{
    static void Main()
    {
        Console.WriteLine("Enter x:");
        double x = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter y:");
        double y = double.Parse(Console.ReadLine());
        if (((x-1)*(x-1) + (y-1)*(y-1) <= 1.5*1.5) && (y > 1))
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

