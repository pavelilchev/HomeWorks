namespace ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int index;
        private int capacity;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.index = 0;
            this.capacity = capacity;
        }

        public int Count => this.index;

        public int Capacity => this.capacity;

        public T this[int key]
        {
            get
            {
                this.ValidateIndex(key);
                return this.elements[this.index - key - 1];
            }

            set
            {
                this.ValidateIndex(key);
                this.elements[this.index - key - 1] = value;
            }
        }

        public void Add(T element)
        {
            if (this.capacity == this.index)
            {
                this.Resize();
            }

            this.elements[this.index] = element;
            this.index++;
        }

        public void Remove(int position)
        {
            this.ValidateIndex(position);
            int startIndex = this.index - position - 1;

            for (int i = startIndex; i < this.index; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.index--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.index - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Resize()
        {
            var newElements = new T[this.capacity * 2];
            Array.Copy(this.elements, newElements, this.capacity);
            this.elements = newElements;
            this.capacity *= 2;
        }

        private void ValidateIndex(int key)
        {
            if (key < 0 || key > this.index - 1)
            {
                throw new IndexOutOfRangeException($"Invalid index, should be in range {0}..{this.index - 1}");
            }
        }
    }
}
