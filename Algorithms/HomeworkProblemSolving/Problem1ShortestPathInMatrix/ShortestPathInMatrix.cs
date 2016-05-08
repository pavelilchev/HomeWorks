namespace Problem1ShortestPathInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShortestPathInMatrix
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            var matrix = new Cell[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = new Cell(i, j, currentRow[j]);
                }
            }
           
            matrix[0, 0].DijkstraDistance = 0;
            var queue = new PriorityQueue<Cell>();
            queue.Enqueue(matrix[0, 0]);
            while (queue.Count > 0)
            {
                var cell = queue.ExtractMin();
                int row = cell.Row;
                int col = cell.Col;

                if (IsValidCell(row, col + 1, rows, cols))
                {
                    var rightCell = matrix[row, col + 1];
                    if (rightCell.DijkstraDistance > cell.DijkstraDistance + rightCell.Value)
                    {
                        rightCell.DijkstraDistance = cell.DijkstraDistance + rightCell.Value;
                        rightCell.PreviousCell = cell;
                        if (queue.Contain(rightCell))
                        {
                            queue.DecreaseKey(rightCell);
                        }
                    }

                     if(!rightCell.IsVisited)
                    {
                        queue.Enqueue(rightCell);
                        rightCell.IsVisited = true;
                    }
                }

                if (IsValidCell(row + 1, col, rows, cols))
                {
                    var bottomCell = matrix[row + 1, col];
                    if (bottomCell.DijkstraDistance > cell.DijkstraDistance + bottomCell.Value)
                    {
                        bottomCell.DijkstraDistance = cell.DijkstraDistance + bottomCell.Value;
                        bottomCell.PreviousCell = cell;
                        if (queue.Contain(bottomCell))
                        {
                            queue.DecreaseKey(bottomCell);
                        }
                    }
                    
                    if(!bottomCell.IsVisited)
                    {
                        queue.Enqueue(bottomCell);
                        bottomCell.IsVisited = true;
                    }
                }

                if (IsValidCell(row, col - 1, rows, cols))
                {
                    var leftCell = matrix[row, col - 1];
                    if (leftCell.DijkstraDistance > cell.DijkstraDistance + leftCell.Value)
                    {
                        leftCell.DijkstraDistance = cell.DijkstraDistance + leftCell.Value;
                        leftCell.PreviousCell = cell;
                        if (queue.Contain(leftCell))
                        {
                            queue.DecreaseKey(leftCell);
                        }
                    }

                   
                    if(!leftCell.IsVisited)
                    {
                        queue.Enqueue(leftCell);
                        leftCell.IsVisited = true;
                    }
                }

                if (cell.Row == rows - 1 && cell.Col == cols -1)
                {
                    break;
                }
            }

            var lastCell = matrix[rows - 1, cols - 1];
            var path = new Stack<int>();
            while (lastCell != null)
            {
                path.Push(lastCell.Value);
                lastCell = lastCell.PreviousCell;
            }

            Console.WriteLine("Length: " + path.Sum());
            Console.WriteLine("Path: " + string.Join(" ", path));
        }

        private static bool IsValidCell(int nextRow, int nextCol, int rows, int cols)
        {
            return nextRow >= 0 && nextCol >= 0 && nextRow < rows && nextCol < cols;
        }
    }
}
