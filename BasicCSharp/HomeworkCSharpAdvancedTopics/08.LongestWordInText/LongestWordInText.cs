using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.LongestWordInText
{
    class LongestWordInText
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] delimeters = new char[] {' ', ',', '.', '\r', '\n'};
            string[] words = input.Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
            int maxLenght = 0;
            int index = 0;

            for (int i = 0; i < words.Length; i++)
            {
                int lenght = words[i].Length;
                if (lenght > maxLenght)
                {
                    maxLenght = lenght;
                    index = i;
                } 
            }
            Console.WriteLine(words[index]);
        }
    }
}
