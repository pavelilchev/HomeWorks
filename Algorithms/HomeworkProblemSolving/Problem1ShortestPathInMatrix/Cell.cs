namespace Problem1ShortestPathInMatrix
{
    using System;

    public class Cell : IComparable<Cell>
    {
        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
            this.DijkstraDistance = int.MaxValue;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Value { get; set; }

        public int DijkstraDistance { get; set; }

        public Cell PreviousCell { get; set; }

        public bool IsVisited { get; set; }

        public int CompareTo(Cell other)
        {
            return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
        }
    }
}