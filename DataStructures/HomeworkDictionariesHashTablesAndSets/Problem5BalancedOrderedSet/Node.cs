namespace Problem5BalancedOrderedSet
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        private Node<T> leftChild;
        private Node<T> rightChild;

        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.leftChild = value;
            }
        }

        public Node<T> RightChild
        {
            get
            {
                return this.rightChild;
            }

            set
            {
                if (value != null)
                {
                    value.Parent = this;
                }

                this.rightChild = value;
            }
        }

        public Node<T> Parent { get; set; }

        public int BalanceFactor { get; set; }

        public bool IsLeftChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this.Parent.Value.CompareTo(this.Value) > 0;
            }
        }

        public bool IsRightChild
        {
            get
            {
                if (this.Parent == null)
                {
                    return false;
                }

                return this.Parent.Value.CompareTo(this.Value) < 0;
            }
        }

        public int ChildrenCount
        {
            get
            {
                if (this.RightChild != null && this.LeftChild != null)
                {
                    return 2;
                }
                else if (this.RightChild == null && this.LeftChild == null)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = (Node<T>)obj;

            return this.Value.CompareTo(other.Value) == 0;
        }
    }
}
