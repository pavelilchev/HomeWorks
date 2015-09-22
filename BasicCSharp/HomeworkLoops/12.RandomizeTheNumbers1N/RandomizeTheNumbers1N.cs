using System;

class RandomizeTheNumbers1N
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        Random numbers = new Random();
        bool[] printed = new bool[n + 1];
        int element;
        for (int i = 0; i < n; i++)
        {
            element = numbers.Next(1, n + 1);
            if (!printed[element])
            {
                Console.Write(element + " ");
                printed[element] = true;
            }
            else
            {
                i--;
            }
        }
        Console.WriteLine();
    }
}

