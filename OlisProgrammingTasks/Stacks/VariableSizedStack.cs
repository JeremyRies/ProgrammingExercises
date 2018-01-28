using System;

namespace OlisProgrammingTasks.Stacks
{
    public class VariableSizedStack : IStack
    {
        private readonly int _stackCount;
        private readonly int _totalSize;

        private readonly int[] _stackPointers;
        readonly char[] _charStack;

        public VariableSizedStack(int stackCount, int totalSize)
        {
            _stackCount = stackCount;
            _totalSize = totalSize;
            _stackPointers = new int[stackCount];
            _charStack = new char[totalSize];
        }

        public void Push(char t, int stackNumber)
        {
            int usedSpace = 0;
            for (int i = 0; i < _stackCount; i++)
            {
                usedSpace += _stackPointers[i];
            }

            if (usedSpace >= _totalSize)
                throw new ArgumentOutOfRangeException();

            int placeOfInsertion = 0;
            for (int i = 0; i <= stackNumber; i++)
            {
                placeOfInsertion += _stackPointers[i];
            }

            for (int i = placeOfInsertion; i < _totalSize - 1; i++)
            {
                _charStack[i + 1] = _charStack[i];
            }

            _charStack[placeOfInsertion] = t;
            _stackPointers[stackNumber]++;
        }

        public char Pop(int stackNumber)
        {
            int placeOfExtrusion = 0;
            for (int i = 0; i < stackNumber; i++)
            {
                placeOfExtrusion += _stackPointers[i];
            }
            _stackPointers[stackNumber]--;
            placeOfExtrusion += _stackPointers[stackNumber];

            var charToReturn = _charStack[placeOfExtrusion];

            for (int i = placeOfExtrusion; i < _totalSize - 1; i++)
            {
                _charStack[i] = _charStack[i+1];
            }

            return charToReturn;
        }
    }
}