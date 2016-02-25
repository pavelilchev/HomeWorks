namespace Problem8LinkedQueueUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem7LinkedQueue;

    [TestClass]
    public class LinkedQueueTest
    {
        private LinkedQueue<int> queue;

        [TestInitialize]
        public void InitQueue()
        {
            this.queue = new LinkedQueue<int>();
        }

        [TestMethod]
        public void InitQueue_ShouldZeroCount()
        {
            Assert.AreEqual(0, this.queue.Count);
        }

        [TestMethod]
        public void Dequeue_SingleElement_ShouldReturnIt()
        {
            int element = 5;

            this.queue.Enqueue(element);

            Assert.AreEqual(1, this.queue.Count);

            var actual = this.queue.Dequeue();

            Assert.AreEqual(element, actual);
            Assert.AreEqual(0, this.queue.Count);
        }

        [TestMethod]
        public void Dequeue_OneTausendElement_ShouldReturnCorrectOrder()
        {
            int addedCount = 5;

            for (int i = 0; i < addedCount; i++)
            {
                this.queue.Enqueue(i);
                Assert.AreEqual(i + 1, this.queue.Count);
            }

            int expectedCount = addedCount;
            for (int i = 0; i < addedCount; i++)
            {
                int element = this.queue.Dequeue();
                expectedCount--;
                Assert.AreEqual(i, element);
                Assert.AreEqual(expectedCount, this.queue.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Enqueue_EmptyQueue_ShouldThrow()
        {
            this.queue.Dequeue();
        }

        [TestMethod]
        public void ToArray_EmptyQueue_ShouldReturnEmptyArray()
        {
            var arr = this.queue.ToArray();

            CollectionAssert.AreEqual(new int[] {}, arr);
        }

        [TestMethod]
        public void ToArray_MultipleElements_ShouldReturnProperArray()
        {
            this.queue.Enqueue(1);
            this.queue.Enqueue(2);
            this.queue.Enqueue(-3);
            this.queue.Enqueue(-4);

            var arr = this.queue.ToArray();
            var expected = new [] {1, 2, -3, -4};

            CollectionAssert.AreEqual(expected, arr);
        }
    }
}
