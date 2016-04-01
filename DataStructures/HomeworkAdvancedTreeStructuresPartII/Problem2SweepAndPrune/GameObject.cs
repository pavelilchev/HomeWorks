namespace Problem2SweepAndPrune
{
    public class GameObject
    {

        private int defaultWidth = 10;
        private int defaultHeight = 10;

        public GameObject(string name, int x1, int y1)
        {
            this.Name = name;
            this.X1 = x1;
            this.Y1 = y1;
            this.Width = this.defaultWidth;
            this.Height = this.defaultHeight;
        }

        public string Name { get; private set; }

        public int  X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 => this.X1 + this.Width;

        public int Y2 => this.Y1 + this.Height;

        public int Width { get; private set; }

        public int Height { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
