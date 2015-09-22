using System;

class ComparingFloats
{
    static void Main()
    {
        Console.WriteLine("Enter number 1:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter number 2:");
        double b = double.Parse(Console.ReadLine());
        double eps = 0.000001;
        double diff = Math.Abs(a - b);
        if (diff == eps)
        {
            Console.WriteLine("false");
            Console.WriteLine("Border case. The difference 0.000001 == eps. We consider the numbers are different.");
        }
        else if (diff < eps)
        {
            Console.WriteLine("true");
            Console.WriteLine("The difference  " + diff + "< eps");
        }
        else
        {
            Console.WriteLine("false");
            Console.WriteLine("The difference of  " + diff + "is too big (>eps)");
        }

    }
}
