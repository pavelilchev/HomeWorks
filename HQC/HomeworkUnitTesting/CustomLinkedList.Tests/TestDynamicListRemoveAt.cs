namespace CustomLinkedList.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class TestDynamicListRemoveAt
    {
        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRemoveAt_InvalidIndex_ShouldThrow()
        {
            var list = new DynamicList<int>();
            list.RemoveAt(1);
        }

        [Test]
        public void TestRemoveAt_ValidIndex_ShouldReturnProperElement()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            list.Add(15);
            var element = list.RemoveAt(1);
            Assert.AreEqual(15, element);
        }
    }
}
