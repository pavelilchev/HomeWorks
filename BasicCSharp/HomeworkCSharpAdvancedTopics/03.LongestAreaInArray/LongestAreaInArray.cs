using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.LongestAreaInArray
{
    class LongestAreaInArray
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] elements = new string[n];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = Console.ReadLine();
            }
            int counterMax = 0;
            int counter = 0;
            string mostElement = null;
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    if (elements[i] == elements[j])
                    {
                        counter++;
                    }
                }
                if (counterMax < counter)
                {
                    counterMax = counter;
                    mostElement = elements[i];
                }
                counter = 0;
            }
            Console.WriteLine(counterMax);
            for (int i = 0; i < counterMax; i++)
            {
                Console.WriteLine(mostElement);
            }
        }
    }
}
