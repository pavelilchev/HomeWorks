namespace Problem6LinkedStackUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Problem5LinkedStack;

    [TestClass]
    public class ToArrayTest
    {
        [TestMethod]
        public void ToArray_PushFewItems_ShouldReturnInReversedOrder()
        {
            var stack = new LinkedStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            var arr = stack.ToArray();

            CollectionAssert.AreEqual(new [] {3, 2, 1}, arr);
        }

        [TestMethod]
        public void ToArray_EmptyStack_ShouldReturnEmptyArray()
        {
            var stack = new LinkedStack<DateTime>();

            var arr = stack.ToArray();

            CollectionAssert.AreEqual(new DateTime [] {}, arr);
        }
    }
}
