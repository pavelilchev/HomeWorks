using System;

class CirclePerimeterAndArea
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter radius:");
        double radius = double.Parse(Console.ReadLine());
        double perimeter = 2*radius*Math.PI;
        double area = Math.PI * radius * radius;
        Console.WriteLine("Perimeter is: {0:F2}", perimeter);
        Console.WriteLine("Area is {0:0.00}", area);
    }
}
