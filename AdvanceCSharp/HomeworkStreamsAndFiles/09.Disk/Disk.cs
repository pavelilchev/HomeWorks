using System;

public class Program
{
    public static void Main()
    {
        int sizeOfField = int.Parse(Console.ReadLine());
        double radius = double.Parse(Console.ReadLine());

        int midlePoint = sizeOfField / 2;
        bool[,] field = new bool[sizeOfField, sizeOfField];


        for (int i = 0; i < sizeOfField; i++)
        {
            for (int j = 0; j < sizeOfField; j++)
            {
                if ((midlePoint - i) * (midlePoint - i) + (midlePoint - j) * (midlePoint - j) <= radius * radius)
                {
                    field[i, j] = true;
                }
            }
        }


        for (int i = 0; i < sizeOfField; i++)
        {
            for (int j = 0; j < sizeOfField; j++)
            {
                if (field[i, j])
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }

            Console.WriteLine();
        }
    }
}