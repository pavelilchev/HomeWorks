using System;
using System.Collections.Generic;
using System.Linq;


public class LongestIncreasingSequence
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var subSequence = new List<List<int>>();
        subSequence.Add(new List<int>());
        int listIndex = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            subSequence[listIndex].Add(arr[i]);

            if (arr[i] > arr[i + 1])
            {
                listIndex++;
                subSequence.Add(new List<int>());
            }
        }

        subSequence[listIndex].Add(arr[arr.Count() - 1]);

        int indexOfLongestSubsequence = 0;
        int longestSubsequenceCount = 0;

        for (int i = 0; i < subSequence.Count; i++)
        {
            Console.WriteLine(string.Join(" ", subSequence[i]));

            if (subSequence[i].Count > longestSubsequenceCount)
            {
                indexOfLongestSubsequence = i;
                longestSubsequenceCount = subSequence[i].Count;
            }
        }

        Console.WriteLine("Longest: {0}", string.Join(" ", subSequence[indexOfLongestSubsequence]));
    }
}

