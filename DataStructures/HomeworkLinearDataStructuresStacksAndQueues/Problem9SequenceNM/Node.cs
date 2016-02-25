namespace Problem9SequenceNM
{
    public class Node
    {
        public Node(int value, Node prevNode)
        {
            this.Value = value;
            this.PrevNode = prevNode;
        }

        public int Value { get; private set; }

        public Node PrevNode { get; private set; }
    }
}
