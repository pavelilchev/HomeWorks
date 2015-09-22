using System;

class OddAndEvenProduct
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] splitInput = input.Split(' ');
        int[] inputInt = new int[splitInput.Length];
        int sumOdd = 1;
        int sumEven = 1;
        for (int i = 0; i < splitInput.Length; i++)
        {
            inputInt[i] = int.Parse(splitInput[i]);
            if (i % 2 != 0)
            {
                sumEven *= inputInt[i];
            }
            else
            {
                sumOdd *= inputInt[i];
            }
        }
        if (sumOdd == sumEven)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("product = {0}", sumOdd);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("odd_product = {0}", sumOdd);
            Console.WriteLine("even_product = {0}", sumEven);
        }
    }
}

