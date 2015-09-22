using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PythagoreanNumbers
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] numbers = new int[count];

        for (int i = 0; i < count; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        bool noPythagorean = true;
      
        for (int a = 0; a < count; a++)
        {
            for (int b = 0; b < count; b++)
            {
                for (int c = 0; c < count; c++)
                {
                    if (numbers[a] <= numbers[b])
                    {
                        bool isPythagorean = numbers[a] * numbers[a] + numbers[b] * numbers[b] == numbers[c] * numbers[c];

                        if (isPythagorean)
                        {
                            noPythagorean = false;
                            Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                        }
                    }
                }
            }
        }

        if (noPythagorean)
        {
            Console.WriteLine("No");
        }
    }
}

