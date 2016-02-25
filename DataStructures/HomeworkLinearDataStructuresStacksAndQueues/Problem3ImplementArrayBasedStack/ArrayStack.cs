namespace Problem3ImplementArrayBasedStack
{
    using System;

    public class ArrayStack<T>
    {
        private const int InitialCapacity = 16;
        private T[] elements;

        public ArrayStack(int capacity = InitialCapacity)
        {
            this.elements = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }

            this.elements[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack is empty.");
            }

            var element = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;

            return element;
        }

        public T[] ToArray()
        {
            var resultArr = new T[this.Count];
            int index = 0;
            for (int i = this.Count - 1; i >= 0; i--)
            {
                resultArr[index] = this.elements[i];
                index++;
            }

            return resultArr;
        }

        private void Grow()
        {
            var newElements = new T[this.elements.Length * 2];
            Array.Copy(this.elements, newElements, this.Count);
            this.elements = newElements;
        }
    }
}
