using System;

class FormattingNumbers
{
    static void Main()
    {
        int a = 0;
        Console.WriteLine("Enter first number:");
        bool isAint = int.TryParse(Console.ReadLine(), out a);
        while (a < 0 || a > 500)
        {
            Console.WriteLine("Incorrect input!");
            a = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter second number:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter thicmber:");
        double c = double.Parse(Console.ReadLine());
        Console.Write("|{0,-10:X}|", a);
        Console.Write(Convert.ToString(a, 2).PadLeft(10, '0'));
        Console.Write("|{0,10:F2}|", b);
        Console.Write("{0,-10:F3}|", c);
    }
}
