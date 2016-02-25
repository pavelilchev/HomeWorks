namespace Problem4ArrayBasedStackUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem3ImplementArrayBasedStack;

    [TestClass]
    public class PushTest
    {
        private ArrayStack<int> stack;

        [TestInitialize]
        public void StackInitialize()
        {
            this.stack = new ArrayStack<int>();
        }

        [TestMethod]
        public void InitializeStack_CountShouldBeZero()
        {
            Assert.AreEqual(0, this.stack.Count);
        }

        [TestMethod]
        public void Push_OneElement_ShouldIncrementCount()
        {
            int num = 3;

            this.stack.Push(num);

            Assert.AreEqual(1, this.stack.Count);
        }

        [TestMethod]
        public void Push_OneTosendElements_ShouldIncrementProperly()
        {
            const int addedElementsCount = 1000;
            for (int i = 0; i < addedElementsCount; i++)
            {
                this.stack.Push(i);
                Assert.AreEqual(i + 1, this.stack.Count);
            }
        }

        [TestMethod]
        public void CustomCapacityStack_ShouldProperlyCount()
        {
            var newStack = new ArrayStack<string>(1);

            Assert.AreEqual(0, newStack.Count);
        }

        [TestMethod]
        public void Push_OneElement_InCustomCapacityStack_ShouldAddProperly()
        {
            var newStack = new ArrayStack<string>(1);
            newStack.Push("ha");

            Assert.AreEqual(1, newStack.Count);
        }

        [TestMethod]
        public void Push_FewElements_InCustomCapacityStack_ShouldAddProperly()
        {
            var newStack = new ArrayStack<string>(1);
            newStack.Push("Az");
            newStack.Push("Ti");

            Assert.AreEqual(2, newStack.Count);
        }
    }
}
