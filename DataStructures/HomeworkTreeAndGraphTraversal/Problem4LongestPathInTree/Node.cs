namespace Problem4LongestPathInTree
{
    using System.Collections.Generic;

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public int Value { get; private set; }

        public Node Parent { get; set; }

        public List<Node> Children { get; private set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
