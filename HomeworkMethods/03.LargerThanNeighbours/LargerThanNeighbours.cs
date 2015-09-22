using System;
using System.Linq;


class LargerThanNeighbours
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    private static bool IsLargerThanNeighbours(int[] numbers, int index)
    {
        bool isLarger = false;      

        if (index == 0 && numbers.Length > 1 && numbers[index] > numbers[index + 1])
        {
            isLarger = true;
        }
        else if (index == numbers.Length - 1 && numbers.Length > 1 && numbers[index] > numbers[index - 1])
        {
            isLarger = true;
        }
        else if (index != 0 && index != numbers.Length - 1
            && numbers[index] > numbers[index - 1] && numbers[index] > numbers[index + 1])
        {
            isLarger = true;
        }

        return isLarger;
    }
}

