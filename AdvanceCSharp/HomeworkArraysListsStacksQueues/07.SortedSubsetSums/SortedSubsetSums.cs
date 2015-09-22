using System;
using System.Collections.Generic;
using System.Linq;


public class SortedSubsetSums
{
    public static void Main()
    {
        Console.WriteLine("Enter sum");
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numbers separated whit single space");
        int[] arr = Console.ReadLine().Split().Select(int.Parse).Distinct().OrderBy(a => a).ToArray();

        int elementsCount = arr.Length;
        int countMask = 1 << elementsCount;

        List<int>[] subSet = new List<int>[countMask];
        int index = 0;

        for (int i = 0; i < countMask; i++)
        {
            subSet[index] = new List<int>();

            for (int j = 0; j < elementsCount; j++)
            {
                if ((i >> j & 1) != 0)
                {
                    subSet[index].Add(arr[j]);
                }
            }

            index++;
        }

        var sortedSubSet = subSet.OrderBy(a => a.Count);
        bool haveMatch = false;

        foreach (var item in sortedSubSet)
        {
            if (item.Sum() == sum && item.Count != 0)
            {
                item.Sort();
                Console.WriteLine("{0} = {1}", string.Join(" + ", item), sum);
                haveMatch = true;
            }
        }

        if (!haveMatch)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}

