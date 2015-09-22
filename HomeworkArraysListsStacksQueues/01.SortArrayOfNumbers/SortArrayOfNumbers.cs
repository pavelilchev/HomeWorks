using System;
using System.Collections.Generic;
using System.Linq;


public class SortArrayOfNumbers
{
    public static void Main()
    {
        Console.WriteLine("Enter numbers separated whit single space");

        IEnumerable<int> numbers = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).OrderBy(a => a).ToArray();  
              
        Console.WriteLine(string.Join(" ", numbers));
    }
}
