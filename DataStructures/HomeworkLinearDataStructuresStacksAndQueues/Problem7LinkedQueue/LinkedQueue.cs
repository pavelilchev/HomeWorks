namespace Problem7LinkedQueue
{
    using System;

    public class LinkedQueue<T>
    {
        private QueueNode head;
        private QueueNode tail;

        public int Count { get; private set; }

        public void Enqueue(T element)
        {
            if (this.Count != 0)
            {
                this.tail.NextNode = new QueueNode(element);
                this.tail.NextNode.PrevNode = this.tail;
                this.tail = this.tail.NextNode;
            }
            else
            {
                this.head = this.tail = new QueueNode(element);
            }

            this.Count++;
        }

        public T Dequeue()
        {
            var element = this.head;

            if (element == null)
            {
                throw new InvalidOperationException("Queue is emty.");
            }

            this.head = this.head.NextNode;
            if (this.head != null)
            {
                this.head.PrevNode = null;
            }
            else
            {
                this.tail = null;
            }
            
            this.Count--;

            return element.Value;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            var first = this.head;
            int index = 0;

            while (first != null)
            {
                resultArr[index] = first.Value;
                first = first.NextNode;
                index++;
            }

            return resultArr;
        }

        private class QueueNode
        {
            public QueueNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public QueueNode NextNode { get; set; }

            public QueueNode PrevNode { get; set; }
        }
    }
}
