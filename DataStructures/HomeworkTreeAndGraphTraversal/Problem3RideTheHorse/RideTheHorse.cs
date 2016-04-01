namespace Problem3RideTheHorse
{
    using System;
    using System.Collections.Generic;

    public class RideTheHorse
    {
        private static int[,] matrix;
        private static int rows;
        private static int cols;

        public static void Main()
        {
            rows = int.Parse(Console.ReadLine());
            cols = int.Parse(Console.ReadLine());
            int currentRow = int.Parse(Console.ReadLine());
            int currentCol = int.Parse(Console.ReadLine());
           
            matrix = new int[rows, cols];

            FilMatrixBfs(currentRow, currentCol);

            PrintColumn(cols/2);

        }

        private static void FilMatrixBfs(int currentRow, int currentCol)
        {
            int currentTurns = 1;
            var queue = new Queue<Cell>();
            queue.Enqueue(new Cell(currentTurns, currentRow, currentCol));
            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();
                if (IsInMatrix(cell) && matrix[cell.Row, cell.Col] == 0)
                {
                    matrix[cell.Row, cell.Col] = cell.Value;
                }

                var nextCell = new Cell(cell.Value + 1, cell.Row - 1, cell.Col - 2);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row - 2, cell.Col - 1);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row - 2, cell.Col + 1);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row - 1, cell.Col + 2);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row + 1, cell.Col + 2);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row + 2, cell.Col + 1);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row + 2, cell.Col - 1);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }

                nextCell = new Cell(cell.Value + 1, cell.Row + 1, cell.Col - 2);
                if (IsInMatrix(nextCell) && matrix[nextCell.Row, nextCell.Col] == 0)
                {
                    queue.Enqueue(nextCell);
                }
            }
        }

        private static void PrintColumn(int col)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine(matrix[i, col]);
            }
        }

        private static bool IsInMatrix(Cell cell)
        {
            if (cell.Row < 0 || cell.Row > rows - 1 || cell.Col < 0 || cell.Col > cols - 1)
            {
                return false;
            }

            return true;
        }
    }
}
