using System;

class StringsAndObjects
{
    static void Main()
    {
        string firstWay = "The \"use\" of quotations causes difficulties.";
        string secondWay = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine("{0}\n{1}\n", firstWay, secondWay);
    }
}

