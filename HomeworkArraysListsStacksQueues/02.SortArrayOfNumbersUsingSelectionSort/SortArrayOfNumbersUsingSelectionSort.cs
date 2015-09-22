using System;
using System.Linq;

public class SortArrayOfNumbersUsingSelectionSort
{
    public static void Main()
    {
        Console.WriteLine("Enter numbers separated whit single space");

        int[] numbers = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();

        SelectionSort(numbers);

        Console.WriteLine(string.Join(" ", numbers));
    }

    private static void SelectionSort(int[] numbers)
    {
        int iterations = numbers.Length;
        int minElement = 0;
        int temp = 0;
        int index = 0;

        for (int j = 0; j < iterations - 1; j++)
        {
            minElement = numbers[j];
            bool haveChange = false;

            for (int i = j + 1; i < iterations; i++)
            {
                if (numbers[i] < minElement)
                {
                    minElement = numbers[i];
                    index = i;
                    haveChange = true;
                }              
            }

            if (haveChange)
            {
                temp = numbers[index];
                numbers[index] = numbers[j];
                numbers[j] = temp; 
            }
        }
    }
}

