using System;

namespace OlisProgrammingTasks.Stacks
{
    public class FixedSizedStack : IStack
    {
        private readonly int[] _stackPointers;

        private readonly int _fixedStackSize;

        private readonly char[] _charStack;

        public FixedSizedStack(int stackCount, int stackSize)
        {
            _stackPointers = new int[stackCount];
            _fixedStackSize = stackSize;

            _charStack = new char[stackCount * stackSize];
        }

        public void Push(char t, int stackNumber)
        {
            if (stackNumber >= _stackPointers.Length || _stackPointers[stackNumber] >= _fixedStackSize)
                throw new ArgumentOutOfRangeException();

            _charStack[stackNumber * _fixedStackSize + ++_stackPointers[stackNumber]] = t;
        }

        public char Pop(int stackNumber)
        {
            return _charStack[stackNumber * _fixedStackSize + _stackPointers[stackNumber]--];
        }
    }
}