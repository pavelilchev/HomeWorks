using System;

class MatrixOfNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int number = 1;
        for (int i = 1; i <= n; i++)
        {            
            for (int j = 1; j <= n; j++)
            {
                Console.Write(number + " ");
                number++;
            }
            number = i + 1;
            Console.WriteLine();
        }
    }
}

