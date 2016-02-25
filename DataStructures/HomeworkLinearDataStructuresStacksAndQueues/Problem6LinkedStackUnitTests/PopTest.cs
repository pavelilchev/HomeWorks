namespace Problem6LinkedStackUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem5LinkedStack;

    [TestClass]
    public class PopTest
    {
        private LinkedStack<int> stack;

        [TestInitialize]
        public void StackInitialize()
        {
            this.stack = new LinkedStack<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyStack_ShouldThrow()
        {
            this.stack.Pop();
        }

        [TestMethod]
        public void Pop_OneElement_ShouldReturnIt()
        {
            int num = 3;

            this.stack.Push(num);
            var actual = this.stack.Pop();

            Assert.AreEqual(num, actual);
            Assert.AreEqual(0, this.stack.Count);
        }

        [TestMethod]
        public void Pop_OneTosendElements_ShouldReturnProperElements()
        {
            const int addedElementsCount = 1000;
            for (int i = 0; i < addedElementsCount; i++)
            {
                this.stack.Push(i);
            }

            for (int i = addedElementsCount - 1; i >= 0; i--)
            {
                var element = this.stack.Pop();
                Assert.AreEqual(i, element);
            }

            Assert.AreEqual(0, this.stack.Count);
        }
    }
}
