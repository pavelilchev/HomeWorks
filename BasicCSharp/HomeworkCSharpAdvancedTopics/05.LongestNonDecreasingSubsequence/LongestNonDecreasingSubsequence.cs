using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.LongestNonDecreasingSubsequence
{
    class LongestNonDecreasingSubsequence
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<int> elements = new List<int>();
            List<int> copyOfElements = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                elements.Add(int.Parse(input[i]));               
            }

        }
    }
}
