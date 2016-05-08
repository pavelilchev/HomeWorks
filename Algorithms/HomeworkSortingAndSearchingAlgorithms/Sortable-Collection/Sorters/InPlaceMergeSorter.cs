namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            MergeSort(collection, 0, collection.Count - 1);
        }

        static void MergeSort(List<T> arrray, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int m = (start + end) / 2;

            MergeSort(arrray, start, m);
            MergeSort(arrray, m + 1, end);
            Merge(arrray, start, m, end);
        }

        //Flip hand
        static void Merge(List<T> arr, int start, int middle, int end)
        {
            int leftMinIndex = start;
            int rightMinIndex = middle + 1;

            while (leftMinIndex <= middle && rightMinIndex <= end)
            {
                int step = 0;

                while (leftMinIndex < rightMinIndex && arr[leftMinIndex].CompareTo(arr[rightMinIndex]) < 0)
                {
                    leftMinIndex++;
                }

                while (rightMinIndex <= end && arr[leftMinIndex].CompareTo(arr[rightMinIndex]) > 0)
                {
                    rightMinIndex++;
                    step++;
                }

                Reverse(arr, leftMinIndex, rightMinIndex - step - 1);
                Reverse(arr, rightMinIndex - step, rightMinIndex - 1);
                Reverse(arr, leftMinIndex, rightMinIndex - 1);

                leftMinIndex += step;
            }
        }

        static void Reverse(List<T> a, int s, int e)
        {
            int i = s, j = e;

            while (i < j)
            {
                Swap(a, i, j);
                i++;
                j--;
            }
        }

        static void Swap(List<T> a, int x, int y)
        {
            T old = a[x];
            a[x] = a[y];
            a[y] = old;
        }
    }
}
