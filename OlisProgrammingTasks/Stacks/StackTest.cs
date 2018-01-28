using NUnit.Framework;

namespace OlisProgrammingTasks.Stacks
{
    public abstract class StackTest
    {
        private IStack _stackToTest;

        [SetUp]
        public void Setup()
        {
            _stackToTest = CreateStack();
        }

        protected abstract IStack CreateStack();

        [Test]
        public void TestSimple_AddingToAllStacks()
        {
            var stack = _stackToTest;

            stack.Push('c',0);
            Assert.AreEqual('c', stack.Pop(0));

            stack.Push('d', 1);
            Assert.AreEqual('d', stack.Pop(1));

            stack.Push('e', 2);
            Assert.AreEqual('e', stack.Pop(2));
        }

        [Test]
        public void Test_AddingMultipleToOneStack()
        {
            var stack = _stackToTest;
            stack.Push('c', 1);
            stack.Push('d', 1);
            stack.Push('e', 1);
            stack.Push('f', 1);

            Assert.AreEqual('f', stack.Pop(1));
            Assert.AreEqual('e', stack.Pop(1));
            Assert.AreEqual('d', stack.Pop(1));
            Assert.AreEqual('c', stack.Pop(1));
        }
    }
}