namespace Problem4ArrayBasedStackUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem3ImplementArrayBasedStack;

    [TestClass]
    public class PopTest
    {
        private ArrayStack<int> stack;

        [TestInitialize]
        public void StackInitialize()
        {
            this.stack = new ArrayStack<int>();
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

        [TestMethod]
        public void Pop_OneElement_InCustomCapacityStack_ShouldReturnIt()
        {
            string expected = "Da";
            var newStack = new ArrayStack<string>(1);
            newStack.Push(expected);

            string actual = newStack.Pop();

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(0, newStack.Count);
        }

        [TestMethod]
        public void Pop_FewElements_InCustomCapacityStack_ShouldAddProperly()
        {
            string firstExpected = "Da";
            string secondExpected = "Ne";
            var newStack = new ArrayStack<string>(1);

            newStack.Push(firstExpected);
            newStack.Push(secondExpected);
           
            string secondActual = newStack.Pop();

            Assert.AreEqual(secondExpected, secondActual);
            Assert.AreEqual(1, newStack.Count);

            string firstActual = newStack.Pop();

            Assert.AreEqual(firstExpected, firstActual);
            Assert.AreEqual(0, newStack.Count);
        }
    }
}
