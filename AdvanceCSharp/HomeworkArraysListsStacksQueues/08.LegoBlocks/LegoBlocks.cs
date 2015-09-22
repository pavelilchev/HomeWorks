using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LegoBlocks
{
    public static void Main()
    {
        int rowsNumber = int.Parse(Console.ReadLine());

        if (rowsNumber == 0)
        {
            Console.WriteLine("The total number of cells is: 0");
            return;
        }

        int[][] firstMatrix = new int[rowsNumber][];
        int[][] secondMatrix = new int[rowsNumber][];

        for (int i = 0; i < rowsNumber; i++)
        {
            firstMatrix[i] = Console.ReadLine().Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        for (int j = 0; j < rowsNumber; j++)
        {
            secondMatrix[j] = Console.ReadLine().Trim()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }

        int chekCountSum = firstMatrix[0].Count() + secondMatrix[0].Count();
        bool haveRechtangle = true;
        int cellCount = 0;

        for (int i = 0; i < rowsNumber; i++)
        {
            int countSum = firstMatrix[i].Count() + secondMatrix[i].Count();
            cellCount += countSum;

            if (countSum != chekCountSum)
            {
                haveRechtangle = false;
            }
        }

        if (!haveRechtangle)
        {
            Console.WriteLine("The total number of cells is: {0}", cellCount);
            return;
        }

        for (int i = 0; i < rowsNumber; i++)
        {
            Console.WriteLine("[{0}, {1}]", string.Join(", ", firstMatrix[i]), string.Join(", ", secondMatrix[i].Reverse()));
        }
    }
}




