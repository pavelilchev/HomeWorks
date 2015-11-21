using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Dictionary<string, int> result = new Dictionary<string, int>();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (result.ContainsKey(arr[i] + " " + arr[i + 1]))
            {
                result[arr[i] + " " + arr[i + 1]]++;
            }
            else
            {
                result.Add(arr[i] + " " + arr[i + 1], 1);
            }
        }

        foreach (var item in result)
        {

            Console.WriteLine("{0} -> {1:F2}%", item.Key, (double)item.Value / (arr.Length - 1) * 100);
        }
    }
}
