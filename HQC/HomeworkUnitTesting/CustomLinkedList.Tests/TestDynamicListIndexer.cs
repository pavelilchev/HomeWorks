namespace CustomLinkedList.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TestDynamicListIndexer
    {
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_GetIndexEmptyList_ShouldThrow()
        {
            var list = new DynamicList<int>();
            var element = list[0];
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_GetInvalidIndex_ShouldThrow()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var element = list[1];
        }

        [Test]
        public void Index_GetValidIndex_ShouldReturnProperElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var element = list[0];
            Assert.AreEqual(1, element);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Index_SetInvalidIndex_ShouldThrow()
        {
            var list = new DynamicList<int>();
            list[-1] = 5;
        }

        [Test]
        public void Index_SetValidIndex_ShouldChangeElement()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            list[0] = 3;
            Assert.AreEqual(3, list[0]);
        }
    }
}
