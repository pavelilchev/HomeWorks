namespace Problem7ConnectedAreasInAMatrix
{
    using System;

    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public ConnectedArea(int x, int y, int size)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Size { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            int size = -this.Size.CompareTo(other.Size);
            if (size == 0)
            {
                int row = this.X.CompareTo(other.X);
                if (row == 0)
                {
                    return this.Y.CompareTo(other.Y);
                }

                return row;
            }

            return size;
        }
    }
}
