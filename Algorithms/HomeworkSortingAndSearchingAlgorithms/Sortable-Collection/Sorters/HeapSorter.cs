namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap();
            foreach (var element in collection)
            {
                heap.Add(element);
            }
           
            int index = 0;
            while (heap.Count > 0)
            {
                collection[index] = heap.ExtractMinItem();
                index++;
            }
        }

        private class BinaryHeap
        {
            private IList<T> heap;

            public BinaryHeap()
            {
                this.heap = new List<T>();
            }

            public int Count
            {
                get
                {
                    return this.heap.Count;
                }
            }

            public void Add(T item)
            {
                this.heap.Add(item);

                int index = this.Count - 1;
                int parentIndex = GetParentIndex(index);
                while (index > 0 &&
                    this.heap[parentIndex].CompareTo(this.heap[index]) > 0)
                {
                    T swapValue = this.heap[index];
                    this.heap[index] = this.heap[parentIndex];
                    this.heap[parentIndex] = swapValue;

                    index = parentIndex;
                    parentIndex = GetParentIndex(index);
                }
            }

            public T ExtractMinItem()
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException(
                        "Cannot get the maximum item of an empty binary heap!");
                }

                T maxItem = this.heap[0];
                this.heap[0] = this.heap[this.Count - 1];
                this.heap.RemoveAt(this.Count - 1);

                this.MaxHeapify(0);

                return maxItem;
            }

            private static int GetParentIndex(int index)
            {
                return (index - 1) / 2;
            }

            private static int GetLeftChildIndex(int index)
            {
                return index * 2 + 1;
            }

            private static int GetRightChildIndex(int index)
            {
                return index * 2 + 2;
            }

            private void MaxHeapify(int index)
            {
                int leftChildIndex = GetLeftChildIndex(index);
                int rightChildIndex = GetRightChildIndex(index);

                int largestItemIndex = 0;
                if (leftChildIndex < this.Count &&
                    this.heap[leftChildIndex].CompareTo(this.heap[index]) < 0)
                {
                    largestItemIndex = leftChildIndex;
                }
                else
                {
                    largestItemIndex = index;
                }

                if (rightChildIndex < this.Count &&
                    this.heap[rightChildIndex].CompareTo(this.heap[largestItemIndex]) < 0)
                {
                    largestItemIndex = rightChildIndex;
                }

                if (largestItemIndex != index)
                {
                    T swapValue = this.heap[index];
                    this.heap[index] = this.heap[largestItemIndex];
                    this.heap[largestItemIndex] = swapValue;

                    this.MaxHeapify(largestItemIndex);
                }
            }
        }
    }
}
