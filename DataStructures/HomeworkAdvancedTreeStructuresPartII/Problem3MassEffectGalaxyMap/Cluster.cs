namespace Problem3MassEffectGalaxyMap
{
    using System;

    public class Cluster : IComparable<Cluster>
    {
        public Cluster(string name, double x, double y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }

        public string Name { get; private set; }

        public double X { get; private set; }

        public double Y { get; private set; }

        public int CompareTo(Cluster other)
        {
            return this.X.CompareTo(other.X);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}