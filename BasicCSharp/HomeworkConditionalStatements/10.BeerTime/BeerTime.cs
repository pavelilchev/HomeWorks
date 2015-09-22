using System;

class BeerTime
{
    static void Main()
    {
        DateTime input = DateTime.Parse(Console.ReadLine());
        DateTime startTime = new DateTime(2015, 6, 14, 13, 0, 0, 0);
        DateTime endTime = new DateTime(2015, 6, 14, 3, 0, 0, 0);

        if ((input >= startTime) && (input <= endTime))
        {
            Console.WriteLine("beer time");
        }
        else
        {
            Console.WriteLine("non-beer time");
        }
    }
}
