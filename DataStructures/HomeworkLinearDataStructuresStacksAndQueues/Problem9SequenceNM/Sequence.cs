namespace Problem9SequenceNM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Sequence
    {
        private readonly int start;
        private readonly int end;

        public Sequence(int start, int end)
        {
            this.start = start;
            this.end = end;
        }

        public void FindSequence()
        {
            var numbers = new Queue<Node>();
            var firstNode = new Node(this.start, null);
            numbers.Enqueue(firstNode);

            while (numbers.Count > 0)
            {
               
                var currentNode = numbers.Dequeue();

                if (currentNode.Value < this.end)
                {
                    numbers.Enqueue(new Node(currentNode.Value + 1, currentNode));
                    numbers.Enqueue(new Node(currentNode.Value + 2, currentNode));
                    numbers.Enqueue(new Node(currentNode.Value *2, currentNode));
                }

                if (currentNode.Value == this.end)
                {
                    this.PrintSequence(currentNode);
                    return;
                }
            }

            Console.WriteLine("(no solution)");
        }

        private void PrintSequence(Node currentNode)
        {
            var element = currentNode;
            var result = new Stack<int>();

            while (element != null)
            {
                result.Push(element.Value);
                element = element.PrevNode;
            }

            Console.WriteLine(string.Join(" -> ", result));
        }
    }
}
