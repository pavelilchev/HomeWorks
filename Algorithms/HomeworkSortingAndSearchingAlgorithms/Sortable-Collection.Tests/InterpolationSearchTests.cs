namespace Sortable_Collection.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingLab.Sorters;

    [TestClass]
    public class InterpolationSearchTests
    {
        private static readonly Random Random = new Random();
        private static IntInterpolator interpolator = new IntInterpolator();

        [TestMethod]
        public void TestWithEmptyCollectionShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();
            var items = collection.Items;

            var result = collection.InterpolationSearch(items, 0, interpolator);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(expected, result, "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void TestWithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);
            var items = collection.Items;

            var result = collection.InterpolationSearch(items, 0, interpolator);
            var expected = -1;

            Assert.AreEqual(expected, result, "Missing element should return -1.");
        }

        [TestMethod]
        public void TestWithItemAtMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);
            var items = collection.Items;

            var result = collection.InterpolationSearch(items, 3, interpolator);
            var expected = Array.BinarySearch(collection.ToArray(), 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheLeftOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var items = collection.Items;

            var result = collection.InterpolationSearch(items, 2, interpolator);
            var expected = Array.BinarySearch(collection.ToArray(), 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheRightOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);
            var items = collection.Items;

            var result = collection.InterpolationSearch(items, 4, interpolator);
            var expected = Array.BinarySearch(collection.ToArray(), 4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysSmallerThanMinimum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            var items = collection.Items;

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(int.MinValue, collection.Items[0]);

                var result = collection.InterpolationSearch(items, item, interpolator);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysLargerThanMaximum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            var items = collection.Items;

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(collection.Items[collection.Count - 1], int.MaxValue);

                var result = collection.InterpolationSearch(items, item, interpolator);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleKeys()
        {
            const int NumberOfElements = 10000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(-100, 100);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            var items = collection.Items;

            foreach (var element in elements)
            {
                var result = collection.InterpolationSearch(items, element, interpolator);

                Assert.AreEqual(element, items[result]);
            }
        }

        [TestMethod]
        public void TestWithRepeatingItemShouldReturnFirstDiscoveredIndex()
        {
            var collection = new SortableCollection<int>(0, 3, 3, 3, 3, 7, 7, 7, 7, 7, 7);
            var items = collection.Items;
            var result = collection.InterpolationSearch(items, 3, interpolator);

            Assert.AreEqual(3, items[result]);
        }
    }
}
