namespace CustomLinkedList.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class TestDynamicListIndexOf
    {
        [Test]
        public void TestIndexOf_NotExistingElement_ShouldReturnNeutralIndex()
        {
            var list = new DynamicList<int>();
            var index = list.IndexOf(5);
            Assert.AreEqual(-1, index);
        }

        [Test]
        public void TestIndexOf_ExistingElement_ShouldReturnProperIndex()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            var index = list.IndexOf(5);
            Assert.AreEqual(0, index);
        }

        [Test]
        public void TestContains_NotExistingElement_ShouldReturnNegative()
        {
            var list = new DynamicList<int>();
            var isContains = list.Contains(5);
            Assert.IsFalse(isContains);
        }

        [Test]
        public void TestContains_NExistingElement_ShouldReturnPositive()
        {
            var list = new DynamicList<int>();
            list.Add(5);
            var isContains = list.Contains(5);
            Assert.IsTrue(isContains);
        }
    }
}
