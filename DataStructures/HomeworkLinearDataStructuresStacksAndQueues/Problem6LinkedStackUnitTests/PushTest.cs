namespace Problem6LinkedStackUnitTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem5LinkedStack;

    [TestClass]
    public class PushTest
    {
        private LinkedStack<int> stack;

        [TestInitialize]
        public void StackInitialize()
        {
            this.stack = new LinkedStack<int>();
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
    }
}
