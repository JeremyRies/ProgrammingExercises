using System;
using NUnit.Framework;

namespace OlisProgrammingTasks.Stacks
{
    public class TestVariableSizedStack : StackTest
    {
        protected override IStack CreateStack()
        {
            return new VariableSizedStack(4,5);
        }

        [Test]
        public void Test_AddingMaxToOneStack()
        {
            var stack = CreateStack();
            stack.Push('c', 1);
            stack.Push('d', 1);
            stack.Push('e', 1);
            stack.Push('f', 1);
            stack.Push('g', 1);

            Assert.AreEqual('g', stack.Pop(1));
            Assert.AreEqual('f', stack.Pop(1));
            Assert.AreEqual('e', stack.Pop(1));
            Assert.AreEqual('d', stack.Pop(1));
            Assert.AreEqual('c', stack.Pop(1));
        }

        [Test]
        public void Test_ExceedingMaxStack()
        {
            var stack = CreateStack();
            stack.Push('c', 1);
            stack.Push('d', 1);
            stack.Push('e', 1);
            stack.Push('f', 1);
            stack.Push('g', 1);

            Assert.Catch<ArgumentOutOfRangeException>(() => stack.Push('g', 1));
        }
    }
}