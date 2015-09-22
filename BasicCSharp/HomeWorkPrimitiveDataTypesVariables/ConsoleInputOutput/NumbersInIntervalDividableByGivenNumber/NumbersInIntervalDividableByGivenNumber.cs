using System;

class NumbersInIntervalDividableByGivenNumber
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int lastNumber = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = firstNumber; i <= lastNumber; i++)
        {
            
            if (i%5==0)
            {

                Console.Write(i + " ");
                count++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("count is: " + count);
    }
}

