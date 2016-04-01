namespace Problem1FindTheRoot
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Parents = new List<Node>();
            this.Children = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Parents { get; set; }

        public List<Node> Children { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
