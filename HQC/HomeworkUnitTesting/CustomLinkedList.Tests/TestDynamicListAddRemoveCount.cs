namespace CustomLinkedList.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TestDynamicListAddRemoveCount
    {
        [Test]
        public void Count_EmptyList_ShouldBeZero()
        {
            var list = new DynamicList<int>();
            var count = list.Count;
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Count_AddToList_ShouldBeProperCount()
        {
            var list = new DynamicList<int>();
            list.Add(1);
            var count = list.Count;
            Assert.AreEqual(1, count);
        }

        [Test]
        public void Count_MultipleAddToList_ShouldBeProperCount()
        {
            var list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var count = list.Count;
            Assert.AreEqual(10, count);
        }

        [Test]
        public void Count_SingleAddAndRemove_ShouldProperCount()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            var index = list.Remove(5);
            var count = list.Count;
            Assert.AreEqual(0, count);
            Assert.AreEqual(0, index);
        }

        [Test]
        public void Count_MultipleAddAndRemove_ShouldProperCount()
        {
            var list = new DynamicList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
                list.Add(i);
                list.Remove(i);
            }

            var index = list.Remove(9);
            var count = list.Count;

            Assert.AreEqual(9, count);
            Assert.AreEqual(9, index);
        }

        [Test]
        public void TestRemove_NotExistingElement_ShouldNeutralIndex()
        {
            var list = new DynamicList<int>();

            var index = list.Remove(1);
            Assert.AreEqual(-1, index);
        }
    }
}
