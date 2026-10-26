using System;

namespace DSA.Lab02
{
    public sealed class ArrayStack<T>
    {
        private readonly T[] _items;
        private int _count;

        public ArrayStack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException("Stack is full");
            }
            for (int i = _count; i > 0; i--)
            {
                if (i != 0)
                {
                    _items[i] = _items[i - 1];
                }
            }
            _items[0] = item;
            _count++;
            // TODO: place the item at the logical top and update the state.
        }

        public T Peek()
        {
            if (_count != 0)
            {
                return _items[0];
            }
            // TODO: return the logical top without removing it.
            throw new InvalidOperationException();
        }

        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            _count--;
            T item = _items[0];
            for (int i = 0; i < _items.Length; i++)
            {
                if (i < _count) { _items[i] = _items[i + 1]; }
                else { _items[i] = default; }
            }
            return item;
            // TODO: remove and return the logical top.
        }
    }
}
