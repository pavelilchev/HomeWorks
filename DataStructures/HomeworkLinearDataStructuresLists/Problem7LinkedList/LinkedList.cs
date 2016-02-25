namespace Problem7LinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode head;
        private ListNode last;
        private int count;

        public LinkedList()
        {
            this.count = 0;
        }

        public int Count => this.count;

        public void Add(T element)
        {
            if (this.head == null)
            {
                this.head = new ListNode(element);
                this.last = this.head;
            }
            else
            {
                this.last.NextNode = new ListNode(element);
                this.last = this.last.NextNode;
            }

            this.count++;
        }

        public void Remove(int index)
        {
            if (0 > index || index > this.Count - 1)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }

            var currentElement = this.head;
            ListNode prevElement = null;
            int currentElementIndex = 0;

            while (currentElement != null)
            {
                if (currentElementIndex == index)
                {
                    if (prevElement != null)
                    {
                        prevElement.NextNode = currentElement.NextNode;

                    }
                    else
                    {
                        this.head = currentElement.NextNode;
                    }

                    currentElement.NextNode = null;
                    this.count--;
                    break;
                }

                prevElement = currentElement;
                currentElement = currentElement.NextNode;
                currentElementIndex++;
            }
        }

        public int FirstIndexOf(T item)
        {
            int firstIndex = -1;
            var currentElement = this.head;
            int index = 0;

            while (currentElement != null)
            {
                if (currentElement.Value.Equals(item))
                {
                    firstIndex = index;
                    break;
                }

                index++;
                currentElement = currentElement.NextNode;
            }

            return firstIndex;
        }

        public int LastIndexOf(T item)
        {
            int firstIndex = -1;
            var currentElement = this.head;
            int index = 0;

            while (currentElement != null)
            {
                if (currentElement.Value.Equals(item))
                {
                    firstIndex = index;
                }

                index++;
                currentElement = currentElement.NextNode;
            }

            return firstIndex;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentElement = this.head;

            while (currentElement != null)
            {
                yield return currentElement.Value;
                currentElement = currentElement.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class ListNode
        {
            public ListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; private set; }

            public ListNode NextNode { get; set; }
        }
    }
}
