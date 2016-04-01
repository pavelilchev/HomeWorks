namespace Problem3RideTheHorse
{
    public class Cell
    {
        public Cell(int value, int row, int col)
        {
            this.Value = value;
            this.Row = row;
            this.Col = col;
        }
        
        public int Value { get; set; }

        public int Row { get; set; }

        public int Col { get; set; }
    }
}
