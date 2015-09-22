using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class SortWords
{
    static void Main()
    {
        List<string> input = Console.ReadLine().Split().ToList();
        input.Sort();
        Console.WriteLine(string.Join(" ", input));
    }
}
