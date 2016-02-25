namespace Problem5LinkedStack
{
    using System;

    public class LinkedStack<T>
    {
        private Node firstNode;

        public int Count { get; private set; }

        public void Push(T element)
        {
            this.firstNode = new Node(element , this.firstNode);
            this.Count++;
        }

        public T Pop()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var element = this.firstNode;
            this.firstNode = this.firstNode.NextNode;
            this.Count--;

            return element.Value;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var first = this.firstNode;

            for (int i = 0; i < this.Count; i++)
            {
                resultArr[i] = first.Value;
                first = first.NextNode;
            }

            return resultArr;
        }

        private class Node
        {
            public Node(T value, Node nextNode = null)
            {
                this.Value = value;
                this.NextNode = nextNode;
            }

            public T Value { get; private set; }

            public Node NextNode { get; private set; } 
        }
    }
}
