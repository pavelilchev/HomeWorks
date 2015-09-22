using System;

class PlayWithIntDoubleAndString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:\n1 --> int\n2 --> double\n3 --> string");
        int input = int.Parse(Console.ReadLine());
        switch (input)
        {
            case 1:
                int numberInt = int.Parse(Console.ReadLine());
                numberInt++;
                Console.WriteLine(numberInt);
                break;
            case 2:
                double numberDouble = double.Parse(Console.ReadLine());
                numberDouble++;
                Console.WriteLine(numberDouble);
                break;
            case 3:
                string text = Console.ReadLine();
                Console.Write(text);
                Console.Write("*");
                Console.WriteLine();
                break;
        }
    }
}
