using System;
using System.Collections.Generic;
using System.Linq;


public class SubsetSums
{
    public static void Main()
    {
        Console.WriteLine("Enter sum");
        int sum = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter numbers separated whit single space");
        int[] arr = Console.ReadLine().Split().Select(int.Parse).Distinct().ToArray();
        
        int elementsCount = arr.Length;
        int countMask = 1 << elementsCount;
        bool haveMatch = false;

        for (int i = 0; i < countMask; i++)
        {
            List<int> subSet = new List<int>();

            for (int j = 0; j < elementsCount; j++)
            {
                if ((i >> j & 1) != 0)
                {
                    subSet.Add(arr[j]);
                }
            }

            if (subSet.Count != 0 && subSet.Sum() == sum)
            {
                Console.WriteLine("{0} = {1}", string.Join(" + ", subSet), sum);
                haveMatch = true;
            }
        }

        if (!haveMatch)
        {
            Console.WriteLine("No matching subsets.");
        }
    }
}


