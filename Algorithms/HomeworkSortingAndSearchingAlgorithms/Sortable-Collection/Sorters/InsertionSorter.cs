namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            for (int i = 1; i < collection.Count; i++)
            {
                int index = i;
                while (index > 0 && collection[i].CompareTo(collection[index - 1]) < 0)
                {
                    index--;
                }

                if (index < i)
                {
                    T item = collection[i];
                    collection.RemoveAt(i);
                    collection.Insert(index, item);
                }
            }
        }
    }
}
