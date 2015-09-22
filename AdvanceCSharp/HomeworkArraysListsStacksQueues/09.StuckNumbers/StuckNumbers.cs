using System;
using System.Linq;
using System.Text;

public class StuckNumbers
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] numbers = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
        bool haveMatch = false;

        StringBuilder left = new StringBuilder();
        StringBuilder right = new StringBuilder();

        for (int a = 0; a < count; a++)
        {
            for (int b = 0; b < count; b++)
            {
                for (int c = 0; c < count; c++)
                {
                    for (int d = 0; d < count; d++)
                    {
                        if (a != b && a != c && a != d && b != c && b != d && c != d)
                        {
                            left.Append(numbers[a]);
                            left.Append(numbers[b]);
                            right.Append(numbers[c]);
                            right.Append(numbers[d]);

                            if (left.Equals(right))
                            {
                                haveMatch = true;
                                Console.WriteLine("{0}|{1}=={2}|{3}", numbers[a], numbers[b], numbers[c], numbers[d]);
                            }

                            left.Clear();
                            right.Clear();
                        }
                    }
                }
            }
        }

        if (!haveMatch)
        {
            Console.WriteLine("No");
        }
    }
}

