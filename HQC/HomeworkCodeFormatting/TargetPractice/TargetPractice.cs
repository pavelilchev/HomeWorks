namespace TargetPractice
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TargetPractice
    {
        private static int rows;
        private static int columns;
        private static char[,] matrix;

        public static void Main()
        {
            string dimensionsString = Console.ReadLine();

            InitializeSnakeMatrix(dimensionsString);

            string snake = Console.ReadLine();

            FillSnakeMatrix(snake);

            string readLine = Console.ReadLine();
            if (readLine != null)
            {
                int[] shootParameters = readLine.Split().Select(int.Parse).ToArray();

                int shootRow = shootParameters[0];
                int shootCol = shootParameters[1];
                int shootRadius = shootParameters[2];

                ReplaceShootedChars(shootRow, shootCol, shootRadius);
            }

            RemoveWhiteSpaceChars();

            PrintMatrix();
        }

        private static void InitializeSnakeMatrix(string dimensions)
        {
            var matrixDemensions = dimensions.Split().Select(int.Parse).ToArray();

            rows = matrixDemensions[0];
            columns = matrixDemensions[1];
            matrix = new char[rows, columns];
        }

        private static void RemoveWhiteSpaceChars()
        {
            var result = new List<char>();

            for (int col = 0; col < columns; col++)
            {
                for (int row = rows - 1; row >= 1; row--)
                {
                    result.Add(matrix[row, col]);
                }

                result.Add(matrix[0, col]);
                result.RemoveAll(item => item == ' ');
                int index = 0;
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (index < result.Count())
                    {
                        matrix[row, col] = result[index];
                        index++;
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }

                result.Clear();
            }
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static void ReplaceShootedChars(int shootRow, int shootCol, int shootRadius)
        {
            int minRow = Math.Max(0, shootRow - shootRadius);
            int maxRow = Math.Min(matrix.GetLength(0) - 1, shootRow + shootRadius);
            int minCol = Math.Max(0, shootCol - shootRadius);
            int maxCol = Math.Min(matrix.GetLength(1) - 1, shootCol + shootRadius);

            for (int i = minRow; i <= maxRow; i++)
            {
                for (int j = minCol; j <= maxCol; j++)
                {
                    bool isInRange = (Math.Abs(i - shootRow) * Math.Abs(i - shootRow))
                                     + (Math.Abs(j - shootCol) * Math.Abs(j - shootCol))
                                     <= shootRadius * shootRadius;
                    if (isInRange)
                    {
                        matrix[i, j] = ' ';
                    }
                }
            }
        }

        private static void FillSnakeMatrix(string snake)
        {
            int row = rows - 1;
            int col = columns - 1;
            int index = 0;
            string comand = "left";

            while (index >= columns * rows)
            {
                if (comand == "left")
                {
                    if (col >= 0)
                    {
                        matrix[row, col] = snake[index % snake.Length];
                        col--;
                        index++;
                    }
                    else
                    {
                        col++;
                        row--;
                        comand = "right";
                    }
                }

                if (comand == "right")
                {
                    if (col < columns)
                    {
                        matrix[row, col] = snake[index % snake.Length];
                        col++;
                        index++;
                    }
                    else
                    {
                        col--;
                        row--;
                        comand = "left";
                    }
                }
            }
        }
    }
}