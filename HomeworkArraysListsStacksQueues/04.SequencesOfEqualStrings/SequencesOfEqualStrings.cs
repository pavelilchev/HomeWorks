using System;
using System.Collections.Generic;

public class SequencesOfEqualStrings
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split();

        Dictionary<string, int> countEqualElements = new Dictionary<string, int>();

        foreach (var item in input)
        {
            if (countEqualElements.ContainsKey(item))
            {
                countEqualElements[item]++;
            }
            else
            {
                countEqualElements.Add(item, 1);
            }
        }

        foreach (var item in countEqualElements)
        {
            for (int i = 0; i < item.Value; i++)
            {
                Console.Write(item.Key + " ");
            }

            Console.WriteLine();
        }
    }
}

