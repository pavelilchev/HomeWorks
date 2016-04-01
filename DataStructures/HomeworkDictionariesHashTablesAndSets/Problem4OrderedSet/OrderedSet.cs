namespace Problem4OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
         where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; set; }

        public void Add(T element)
        {
            if (this.root == null)
            {
                this.root = new Node<T>(element);
            }
            else
            {
                this.Insert(element, this.root);
            }
        }

        public bool Contains(T element)
        {
            var currentElement = this.root;
            while (currentElement != null)
            {
                if (currentElement.Value.CompareTo(element) == 0)
                {
                    return true;
                }

                if (currentElement.Value.CompareTo(element) > 0)
                {
                    currentElement = currentElement.LeftChild;
                }
                else
                {
                    currentElement = currentElement.RightChild;
                }
            }

            return false;
        }

        public void Remove(T element)
        {
            var currentElement = this.root;
            Node<T> prevElement = null;
            while (currentElement != null)
            {
                if (currentElement.Value.CompareTo(element) == 0)
                {
                    if (prevElement == null)
                    {
                        this.RemoveRootElement(currentElement);
                        break;
                    }

                    RemoveInnerElement(prevElement, currentElement);
                    break;
                }

                if (currentElement.Value.CompareTo(element) > 0)
                {
                    prevElement = currentElement;
                    currentElement = currentElement.LeftChild;
                }
                else
                {
                    prevElement = currentElement;
                    currentElement = currentElement.RightChild;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            this.DfsInOrder(queue, this.root);

            while (queue.Count > 0)
            {
                var currentElement = queue.Dequeue();
                yield return currentElement.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static void RemoveInnerElement(Node<T> prevElement, Node<T> currentElement)
        {
            if (prevElement.Value.CompareTo(currentElement.Value) > 0 && currentElement.RightChild != null)
            {
                prevElement.LeftChild = currentElement.RightChild;
                prevElement.LeftChild.LeftChild = currentElement.LeftChild;
            }
            else if (prevElement.Value.CompareTo(currentElement.Value) > 0 && currentElement.LeftChild != null)
            {
                prevElement.LeftChild = currentElement.LeftChild;
            }
            else if (prevElement.Value.CompareTo(currentElement.Value) > 0)
            {
                prevElement.LeftChild = null;
            }
            else if (prevElement.Value.CompareTo(currentElement.Value) < 0 && currentElement.RightChild != null)
            {
                prevElement.RightChild = currentElement.RightChild;
                prevElement.RightChild.LeftChild = currentElement.LeftChild;
            }
            else if (prevElement.Value.CompareTo(currentElement.Value) < 0 && currentElement.LeftChild != null)
            {
                prevElement.RightChild = currentElement.LeftChild;
            }
            else if (prevElement.Value.CompareTo(currentElement.Value) < 0)
            {
                prevElement.RightChild = null;
            }
        }

        private void RemoveRootElement(Node<T> currentElement)
        {
            if (currentElement.RightChild != null)
            {
                this.root = currentElement.RightChild;
                var left = currentElement.RightChild;
                while (left.LeftChild != null)
                {
                    left = left.LeftChild;
                }

                left.LeftChild = currentElement.LeftChild;
            }
            else
            {
                this.root = currentElement.LeftChild;
            }
        }

        private void DfsInOrder(Queue<Node<T>> queue, Node<T> parent)
        {
            if (parent.LeftChild != null)
            {
                this.DfsInOrder(queue, parent.LeftChild);
            }

            queue.Enqueue(parent);

            if (parent.RightChild != null)
            {
                this.DfsInOrder(queue, parent.RightChild);
            }
        }

        private void Insert(T element, Node<T> parent)

        {
            if (element.CompareTo(parent.Value) == 0)
            {
                return;
            }

            if (element.CompareTo(parent.Value) < 0)
            {
                if (parent.LeftChild == null)
                {
                    parent.LeftChild = new Node<T>(element);
                }
                else
                {
                    this.Insert(element, parent.LeftChild);
                }
            }
            else
            {
                if (parent.RightChild == null)
                {
                    parent.RightChild = new Node<T>(element);
                }
                else
                {
                    this.Insert(element, parent.RightChild);
                }
            }
        }
    }
}
