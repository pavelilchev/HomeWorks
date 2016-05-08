namespace SortingLab.Sorters
{
    using System;
    using System.Collections.Generic;
    using SortingLab.Contracts;

    public class IntInterpolator
    {
        public int Interpolate(IList<int> list, int high, int low, int key)
        {
            int mid = low + ((key - list[low]) * (high - low)) / (list[high] - list[low]);

            return mid;
        }
    }
}
