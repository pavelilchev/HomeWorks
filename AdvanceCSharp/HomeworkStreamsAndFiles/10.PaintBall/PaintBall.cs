using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] canvas = new int[10];

        for (int i = 0; i < 10; i++)
        {
            canvas[i] = 1023;
        }


        string input = Console.ReadLine();
        bool isBlack = true;

        while (input != "End")
        {
            int[] tokens = input.Split(' ').Select(int.Parse).ToArray();
            int row = tokens[0];
            int col = tokens[1];
            int radius = tokens[2];

            int startRow = Math.Max(0, row - radius);
            int endRow = Math.Min(9, row + radius);
            int startCol = Math.Max(0, col - radius);
            int endCol = Math.Min(9, col + radius);


            if (isBlack)
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        canvas[i] &= ~(1 << j);
                    }
                }

                isBlack = !isBlack;
            }
            else
            {
                for (int i = startRow; i <= endRow; i++)
                {
                    for (int j = startCol; j <= endCol; j++)
                    {
                        canvas[i] &= ~(1 << j);
                        canvas[i] |= 1 << j;
                    }
                }

                isBlack = !isBlack;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(canvas.Sum());
    }
}
