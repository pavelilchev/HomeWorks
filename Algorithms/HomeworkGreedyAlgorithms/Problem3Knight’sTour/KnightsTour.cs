namespace Problem3Knight_sTour
{
    using System;

    public class KnightsTour
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] board = new int[n, n];
            int step = 1;
            board[0, 0] = step++;

            var nextCell = CalculateNextCell(new Cell(0, 0), board);
            while (nextCell != null)
            {
                board[nextCell.Row, nextCell.Col] = step++;
                nextCell = CalculateNextCell(nextCell, board);
            }

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write("{0, 4}", board[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static Cell CalculateNextCell(Cell cell, int[,] board)
        {
            Cell nextCell = null;
            int minMoves = int.MaxValue;
            int next = CalculatePossibleMoves(cell.Row - 2, cell.Col - 1, board);
            if (CheckIsPossibleMove(cell.Row - 2, cell.Col - 1, board) &&
                next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row - 2, cell.Col - 1);
            }
            next = CalculatePossibleMoves(cell.Row - 2, cell.Col + 1, board);
            if (CheckIsPossibleMove(cell.Row - 2, cell.Col + 1, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row - 2, cell.Col + 1);
            }
            next = CalculatePossibleMoves(cell.Row - 1, cell.Col + 2, board);
            if (CheckIsPossibleMove(cell.Row - 1, cell.Col + 2, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row - 1, cell.Col + 2);
            }
            next = CalculatePossibleMoves(cell.Row + 1, cell.Col + 2, board);
            if (CheckIsPossibleMove(cell.Row + 1, cell.Col + 2, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row + 1, cell.Col + 2);
            }
            next = CalculatePossibleMoves(cell.Row + 2, cell.Col + 1, board);
            if (CheckIsPossibleMove(cell.Row + 2, cell.Col + 1, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row + 2, cell.Col + 1);
            }
            next = CalculatePossibleMoves(cell.Row + 2, cell.Col - 1, board);
            if (CheckIsPossibleMove(cell.Row + 2, cell.Col - 1, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row + 2, cell.Col - 1);
            }
            next = CalculatePossibleMoves(cell.Row + 1, cell.Col - 2, board);
            if (CheckIsPossibleMove(cell.Row + 1, cell.Col - 2, board) && next != -1 && next < minMoves)
            {
                minMoves = next;
                nextCell = new Cell(cell.Row + 1, cell.Col - 2);
            }
            next = CalculatePossibleMoves(cell.Row - 1, cell.Col - 2, board);
            if (CheckIsPossibleMove(cell.Row - 1, cell.Col - 2, board) && next != -1 && next < minMoves)
            {
                nextCell = new Cell(cell.Row - 1, cell.Col - 2);
            }

            return nextCell;
        }

        private static int CalculatePossibleMoves(int row, int col, int[,] board)
        {
            if (!CheckIsPossibleMove(row, col, board))
            {
                return -1;
            }

            int possibleMoves = 0;
            if (CheckIsPossibleMove(row - 2, col - 1, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row - 2, col + 1, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row - 1, col + 2, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row + 1, col + 2, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row + 2, col + 1, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row + 2, col - 1, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row + 1, col - 2, board))
            {
                possibleMoves++;
            }
            if (CheckIsPossibleMove(row - 1, col - 2, board))
            {
                possibleMoves++;
            }

            return possibleMoves;
        }

        private static bool CheckIsPossibleMove(int row, int col, int[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            if (row < 0 || col < 0 || row >= rows || col >= cols || board[row, col] != 0)
            {
                return false;
            }

            return true;
        }

        private class Cell
        {
            public Cell(int row, int col)
            {
                this.Row = row;
                this.Col = col;
            }

            public int Row { get; private set; }

            public int Col { get; private set; }
        }
    }
}
