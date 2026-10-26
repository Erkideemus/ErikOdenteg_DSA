using System;

namespace DSA.Lab02
{
    public sealed class RingQueue<T>
    {
        private readonly T[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public RingQueue(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _items = new T[capacity];
        }

        public int Count => _count;
        public int Capacity => _items.Length;

        public void Enqueue(T item)
        {
            if (_count == _items.Length)
            {
                throw new InvalidOperationException();
            }

            _items[_count] = item;
            _count++;
            _tail = _count;
            // TODO: write at tail, advance tail with wrap-around, update count.
        }

        public T Peek()
        {
            if (_count != 0)
            {
                return _items[_head];
            }
            // TODO: return the item at head without removing it.
            throw new InvalidOperationException();
        }

        public T Dequeue()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            _count--;
            T item = _items[_head];
            _tail = _count;
            for (int i = 0; i < _items.Length; i++)
            {
                if (i < _tail) { _items[i] = _items[i + 1]; }
                else { _items[i] = default; }
            }
            return item;
            // TODO: read/clear at head, advance head with wrap-around, update count.
        }
    }
}
