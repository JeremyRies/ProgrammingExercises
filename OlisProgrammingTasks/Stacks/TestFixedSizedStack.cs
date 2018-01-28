using System;
using NUnit.Framework;

namespace OlisProgrammingTasks.Stacks
{
    public class TestFixedSizedStack : StackTest
    {
        protected override IStack CreateStack()
        {
            return new FixedSizedStack(3,4);
        }

        [Test]
        public void Test_ExceptionAdding()
        {
            var stack = CreateStack();
            Assert.Catch<ArgumentOutOfRangeException>(() => stack.Push('c', 5));
        }
    }
}