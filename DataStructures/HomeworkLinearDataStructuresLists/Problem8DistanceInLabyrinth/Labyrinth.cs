namespace Problem8DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Labyrinth
    {
        private readonly string[,] matrix;
        private readonly int rows;
        private readonly int cols;

        public Labyrinth(string[,] labyrinth)
        {
            this.matrix = labyrinth;
            this.rows = this.matrix.GetLength(0);
            this.cols = this.matrix.GetLength(1);
            this.FillMatrix();
        }

        public void Print()
        {
            this.ChangeUnreachebleCells();

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    Console.Write("{0, 3}", this.matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private void ChangeUnreachebleCells()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    if (this.matrix[i, j] == "0")
                    {
                        this.matrix[i, j] = "u";
                    }
                }
            }
        }

        private void FillMatrix()
        {
            var currentCell = this.FindStartPosition();
            int number = currentCell.Value + 1;

            var queue = new Queue<Cell>();
            queue.Enqueue(new Cell(currentCell.X, currentCell.Y + 1, number));
            queue.Enqueue(new Cell(currentCell.X + 1, currentCell.Y, number));
            queue.Enqueue(new Cell(currentCell.X, currentCell.Y - 1, number));
            queue.Enqueue(new Cell(currentCell.X - 1, currentCell.Y, number));

            while (queue.Count != 0)
            {
                var nextCell = queue.Dequeue();

                if (nextCell.X < 0 || nextCell.X >= this.rows ||
                 nextCell.Y < 0 || nextCell.Y >= this.cols ||
                 this.matrix[nextCell.X, nextCell.Y] != "0")
                {
                    continue;
                }

                if (this.matrix[nextCell.X, nextCell.Y] == "0")
                {
                    this.matrix[nextCell.X, nextCell.Y] = nextCell.Value.ToString();

                    queue.Enqueue(new Cell(nextCell.X, nextCell.Y + 1, nextCell.Value + 1));
                    queue.Enqueue(new Cell(nextCell.X + 1, nextCell.Y, nextCell.Value + 1));
                    queue.Enqueue(new Cell(nextCell.X, nextCell.Y - 1, nextCell.Value + 1));
                    queue.Enqueue(new Cell(nextCell.X - 1, nextCell.Y, nextCell.Value + 1));
                }
            }
        }

        private Cell FindStartPosition()
        {
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.cols; j++)
                {
                    if (this.matrix[i, j] == "*")
                    {
                        return new Cell(i, j, 0);
                    }
                }
            }

            throw new ArgumentException("Labyrinth dont have starting position.");
        }

        private class Cell
        {
            public Cell(int x, int y, int value)
            {
                this.X = x;
                this.Y = y;
                this.Value = value;
            }

            public int X { get; }

            public int Y { get; }

            public int Value { get; }
        }
    }
}
