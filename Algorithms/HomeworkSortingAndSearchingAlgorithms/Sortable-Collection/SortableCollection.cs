namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using SortingLab.Sorters;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; private set; }

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item)
        {
            int result = this.BinarySearchProcedure(item, 0, this.Count - 1);

            return result;
        }

        private int BinarySearchProcedure(T item, int startIndex, int endIndex)
        {
            if (endIndex < startIndex)
            {
                return -1;
            }

            int midpoint = startIndex + (endIndex - startIndex) / 2;
            if (this.Items[midpoint].CompareTo(item) > 0)
            {
                midpoint = this.BinarySearchProcedure(item, startIndex, midpoint - 1);
            }
            else if (this.Items[midpoint].CompareTo(item) < 0)
            {
                midpoint = this.BinarySearchProcedure(item, midpoint + 1, endIndex);
            }

            return midpoint;
        }

        public int InterpolationSearch(List<int> arr, int item, IntInterpolator interpolator)
        {
            int low = 0;
            int high = this.Count - 1;
            if (high < 0)
            {
                return -1;
            }

            while (arr[low].CompareTo(item) <= 0 && arr[high].CompareTo(item) >= 0)
            {
                int mid = interpolator.Interpolate(arr, high, low, item);
                if (arr[mid].CompareTo(item) < 0)
                {
                    low = mid + 1;
                }
                else if (arr[mid].CompareTo(item) > 0)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (arr[low].CompareTo(item) == 0)
            {
                return low;
            }

            return -1;
        }

        public void Shuffle()
        {
            Random random = new Random();

            int n = this.Count;
            for (int i = 0; i < n; i++)
            {
                int swapIndex = i + random.Next(n - i);
                T old = Items[i];
                Items[i] = Items[swapIndex];
                Items[swapIndex] = old;
            }
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format("[{0}]", string.Join(", ", this.Items));
        }
    }
}