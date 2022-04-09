namespace Calculator.CustomCollections
{
    public class CustomStack<T>
    {
        private T[] _stack;
        private int _count;
        private int _stackSize;

        public CustomStack(int stackSize = 10)
        {
            _stackSize = stackSize;
            _stack = new T[_stackSize];
        }

        public void Push(T value)
        {
            if (IsStackFull())
                IncreaseStackSize();
            else
            {
                _stack[_count++] = value;
            }
        }       

        public T Pop()
        {
            if (IsStackEmpty())
                throw new InvalidOperationException("Stack: Call Pop operation when stack is empty");
            T value = _stack[--_count];
            _stack[_count] = default;
            return value;
        }

        public T Peek()
        {
            if (IsStackEmpty())
                throw new InvalidOperationException("Stack: Call Peek operation when stack is empty");
            return _stack[_count - 1];
        }

        private bool IsStackFull() => _count == _stackSize;

        private bool IsStackEmpty() => _count == 0;

        private void IncreaseStackSize()
        {
            _stackSize *= _stackSize;
            var newStack = new T[_stackSize];
            int i = 0;
            foreach (var item in _stack)
            {
                newStack[i++] = item;
            }
            _stack = newStack;
        }
    }
}
