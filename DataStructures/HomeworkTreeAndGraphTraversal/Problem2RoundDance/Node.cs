namespace Problem2RoundDance
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Neighbors = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Neighbors  { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
