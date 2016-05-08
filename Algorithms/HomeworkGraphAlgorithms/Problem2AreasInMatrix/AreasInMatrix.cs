namespace Problem2AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AreasInMatrix
    {
       
        public static void Main()
        {
            int rows = Console.ReadLine().Split(':').Skip(1).Select(x => x.Trim()).Select(int.Parse).First();

            var matrix =new char[rows][];

            for (int i = 0; i < rows; i++)
            {
                var currentRow = Console.ReadLine();
                matrix[i] = new char[currentRow.Length];
                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i][j] = currentRow[j];
                }
            }

            var areasBySize = new SortedDictionary<char, int>();
            int areasCount = 0;
            var visited = new bool[rows, matrix[0].Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (!visited[i,j])
                    {
                        if (!areasBySize.ContainsKey(matrix[i][j]))
                        {
                            areasBySize.Add(matrix[i][j], 0);
                        }

                        areasCount++;
                        areasBySize[matrix[i][j]]++;
                        FindConnectedArea(i, j, visited, matrix, matrix[i][j]);
                    }
                }
            }

            Console.WriteLine("Areas: " + areasCount);
            foreach (var area in areasBySize)
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void FindConnectedArea(int row, int col, bool[,] visited, char[][] matrix, char symbol)
        {
            if (row < 0 || col < 0 || row >= visited.GetLength(0) || col >= visited.GetLength(1))
            {
                return;
            }

            if (visited[row, col] || matrix[row][col] != symbol)
            {
                return;
            }

            visited[row, col] = true;

            FindConnectedArea(row - 1, col, visited, matrix, symbol);
            FindConnectedArea(row, col + 1, visited, matrix, symbol);
            FindConnectedArea(row + 1, col, visited, matrix, symbol);
            FindConnectedArea(row, col - 1, visited, matrix, symbol);
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    Console.Write("{0, -2}", matrix[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
