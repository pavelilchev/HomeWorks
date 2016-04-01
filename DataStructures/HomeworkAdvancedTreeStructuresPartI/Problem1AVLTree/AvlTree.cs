namespace Problem1AVLTree
{
    using System;
    using System.Collections.Generic;

    public class AvlTree<T>
        where T : IComparable<T>
    {
        private Node<T> root;

        public int Count { get; private set; }

        public T this[int key]
        {
            get
            {
                return this.GetValue(key);
            }

            set
            {
                this.SetValue(key, value);
            }
        }

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

        public void ForeachDfs(Action<int, T> action)
        {
            if (this.Count == 0)
            {
                return;
            }

            this.InOrderDfs(this.root, 1, action);
        }

        public void Print(int indent)
        {
            this.PrintInternal(indent, this.root);
        }


        public IEnumerable<T> Range(T from, T to)
        {
            if (this.Count == 0)
            {
                return new T[0];
            }

            var elementsInRange = new List<T>();
            this.FindRange(this.root, from, to, elementsInRange);

            return elementsInRange;
        }
        
        private void SetValue(int key, T value)
        {
            this.ValidateIndex(key);

            var elements = new List<Node<T>>();
            this.Find(key, this.root, elements);
            elements[key].Value = value;
        }

        private T GetValue(int key)
        {
            this.ValidateIndex(key);

            var elements = new List<Node<T>>();
            this.Find(key, this.root, elements);

            return elements[key].Value;
        }

        private void ValidateIndex(int key)
        {
            if (key < 0 || key >= this.Count)
            {
                string msg = $"Index should be in range {0}..{this.Count - 1}";
                throw new IndexOutOfRangeException(msg);
            }
        }

        private void Find(int key, Node<T> node, List<Node<T>> elements)
        {
            if (node.LeftChild != null)
            {
                this.Find(key, node.LeftChild, elements);
            }

            elements.Add(node);
            if (elements.Count - 1 == key)
            {
                return;
            }

            if (node.RightChild != null)
            {
                this.Find(key, node.RightChild, elements);
            }
        }

        private void FindRange(Node<T> node, T from, T to, IList<T> elementsInRange)
        {
            if (node != null && node.Value.CompareTo(from) > 0)
            {
                this.FindRange(node.LeftChild, from, to, elementsInRange);
            }

            if (node != null && node.Value.CompareTo(from) >= 0 && node.Value.CompareTo(to) <= 0)
            {
                elementsInRange.Add(node.Value);
            }

            if (node != null && node.Value.CompareTo(to) < 0)
            {
                this.FindRange(node.RightChild, from, to, elementsInRange);
            }
        }

        private void PrintInternal(int indent, Node<T> node)
        {
            Console.WriteLine("{0}({1})", new string('-', 2 * indent), node.Value);

            if (node.LeftChild != null)
            {
                this.PrintInternal(indent + 1, node.LeftChild);
            }

            if (node.RightChild != null)
            {
                this.PrintInternal(indent + 1, node.RightChild);
            }
        }

        private void InOrderDfs(Node<T> node, int depth, Action<int, T> action)
        {
            if (node.LeftChild != null)
            {
                this.InOrderDfs(node.LeftChild, depth + 1, action);
            }

            action(depth, node.Value);

            if (node.RightChild != null)
            {
                this.InOrderDfs(node.RightChild, depth + 1, action);
            }
        }

        private bool InsertInternal(Node<T> node, T item)
        {
            var currentNode = node;
            var newNode = new Node<T>(item);
            bool shouldRetrace;
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
    }
}
