﻿namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.MergeSort(collection, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, int start, int end)
        {
            if (start < end)
            {
                int middle = (end + start) / 2;

                this.MergeSort(array, start, middle);
                this.MergeSort(array, middle + 1, end);

                this.Merge(array, start, middle, end);
            }
        }

        private void Merge(List<T> array, int start, int middle, int end)
        {
            int leftMinIndex = start;
            int rightMinIndex = middle + 1;
            int tempIndex = 0;
            T[] temporaryArray = new T[end - start + 1];
            while (leftMinIndex <= middle && rightMinIndex <= end)
            {
                if (array[leftMinIndex].CompareTo(array[rightMinIndex]) <= 0)
                {
                    temporaryArray[tempIndex] = array[leftMinIndex];
                    leftMinIndex++;
                }
                else
                {
                    temporaryArray[tempIndex] = array[rightMinIndex];
                    rightMinIndex++;
                }

                tempIndex++;
            }

            while (leftMinIndex <= middle)
            {
                temporaryArray[tempIndex] = array[leftMinIndex];
                leftMinIndex++;
                tempIndex++;
            }

            while (rightMinIndex <= end)
            {
                temporaryArray[tempIndex] = array[rightMinIndex];
                rightMinIndex++;
                tempIndex++;
            }

            for (int i = start; i <= end; i++)
            {
                array[i] = temporaryArray[i - start];
            }
        }
    }
}
