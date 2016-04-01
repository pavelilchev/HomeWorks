namespace Problem5BalancedOrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class OrderedSet<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public void Add(T item)
        {
            var inserted = true;
            if (this.root == null)
            {
                this.root = new Node<T>(item);
            }
            else
            {
                inserted = this.InsertInternal(this.root, item);
            }

            if (inserted)
            {
                this.Count++;
            }
        }

        public void Remove(T element)
        {
            var node = this.root;

            while (node != null)
            {
                if (node.Value.CompareTo(element) == 0)
                {
                    this.RemoveInternal(node);
                    break;
                }

                if (node.Value.CompareTo(element) > 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    node = node.RightChild;
                }
            }
        }

        public Node<T> Root => this.root;

        public void Print(int indent, Node<T> node)
        {
            Console.WriteLine("{0}({1})", new string('-', 2 * indent), node.Value);

            if (node.LeftChild != null)
            {
                this.Print(indent + 1, node.LeftChild);
            }
            if (node.RightChild != null)
            {
                this.Print(indent + 1, node.RightChild);
            }
        }

        private void RemoveInternal(Node<T> node)
        {
            var parent = node.Parent;
            if (parent == null)
            {
                this.RemoveRootElement(node);
            }
            else
            {
                RemoveInnerElement(parent, node);
            }
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

        public bool Contains(T item)
        {
            var node = this.root;
            while (node != null)
            {
                if (node.Value.CompareTo(item) == 0)
                {
                    return true;
                }
                else if (node.Value.CompareTo(item) > 0)
                {
                    node = node.LeftChild;
                }
                else
                {
                    node = node.RightChild;
                }
            }

            return false;
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            bool shouldRetrace = false;
            while (true)
            {
                if (currentNode.Value.CompareTo(newNode.Value) > 0)
                {
                    if (currentNode.LeftChild == null)
                    {
                        currentNode.LeftChild = newNode;
                        currentNode.BalanceFactor++;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(newNode.Value) < 0)
                {
                    if (currentNode.RightChild == null)
                    {
                        currentNode.RightChild = newNode;
                        currentNode.BalanceFactor--;
                        shouldRetrace = currentNode.BalanceFactor != 0;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                }
                else
                {
                    return false;
                }
            }

            if (shouldRetrace)
            {
                this.RetraceInsert(currentNode);
            }

            return true;
        }

        private void RetraceInsert(Node<T> node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.BalanceFactor++;
                    if (parent.BalanceFactor == 2)
                    {
                        if (node.BalanceFactor == -1)
                        {
                            this.RotateLeft(node);
                        }

                        this.RotateRight(parent);
                        break;
                    }
                }
                else
                {
                    parent.BalanceFactor--;
                    if (parent.BalanceFactor == -2)
                    {
                        if (node.BalanceFactor == 1)
                        {
                            this.RotateRight(node);
                        }

                        this.RotateLeft(parent);
                        break;
                    }
                }

                node = parent;
                parent = node.Parent;
            }
        }

        private void RotateLeft(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.RightChild;
            if (parent != null)
            {
                if (node.IsLeftChild)
                {
                    parent.LeftChild = child;
                }
                else
                {
                    parent.RightChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.RightChild = child.LeftChild;
            child.LeftChild = node;

            node.BalanceFactor += 1 - Math.Min(child.BalanceFactor, 0);
            child.BalanceFactor += 1 + Math.Max(node.BalanceFactor, 0);
        }

        private void RotateRight(Node<T> node)
        {
            var parent = node.Parent;
            var child = node.LeftChild;

            if (parent != null)
            {
                if (node.IsRightChild)
                {
                    parent.RightChild = child;
                }
                else
                {
                    parent.LeftChild = child;
                }
            }
            else
            {
                this.root = child;
                this.root.Parent = null;
            }

            node.LeftChild = child.RightChild;
            child.RightChild = node;

            node.BalanceFactor -= 1 + Math.Max(child.BalanceFactor, 0);
            child.BalanceFactor -= 1 - Math.Min(node.BalanceFactor, 0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<T>();
            this.DfsInOrder(this.root, queue);

            while (queue.Count > 0)
            {
                yield return queue.Dequeue();
            }
        }

        private void DfsInOrder(Node<T> node, Queue<T> queue)
        {
            if (node != null)
            {
                if (node.LeftChild != null)
                {
                    this.DfsInOrder(node.LeftChild, queue);
                }

                queue.Enqueue(node.Value);

                if (node.RightChild != null)
                {
                    this.DfsInOrder(node.RightChild, queue);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
