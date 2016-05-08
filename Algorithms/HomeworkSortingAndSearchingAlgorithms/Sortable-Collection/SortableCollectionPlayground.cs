namespace Sortable_Collection
{
    using System;
    using Sorters;
    using SortingLab.Sorters;

    public class SortableCollectionPlayground
    {
        private static readonly Random Random = new Random();

        public static void Main()
        {
            const int NumberOfElementsToSort = 15;
            const int MaxValue = 100;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new MergeSorter<int>());

            Console.WriteLine(collectionToSort);
        }
    }
}

