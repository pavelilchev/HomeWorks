using System;

class GravitationOnTheMoon
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter weight");
        double weight = double.Parse(Console.ReadLine());
        double moonWeight = weight * 0.17;
        Console.WriteLine(moonWeight);
    }
}
