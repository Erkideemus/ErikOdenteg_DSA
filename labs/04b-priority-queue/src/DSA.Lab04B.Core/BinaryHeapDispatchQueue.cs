using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DSA.Lab04B
{
    /// <summary>
    /// Priority queue implemented with a binary min-heap.
    ///
    /// Invariant:
    /// each parent's Priority is <= the Priority of each of its children.
    ///
    /// The heap is NOT fully sorted.
    /// </summary>
    public sealed class BinaryHeapDispatchQueue<T>
    {
        private readonly List<PriorityEntry<T>> _heap = new List<PriorityEntry<T>>();

        public int Count => _heap.Count;

        public void Enqueue(T item, int priority)
        {
            if (item == null) { throw new ArgumentNullException("item"); }
            PriorityEntry<T> entry = new PriorityEntry<T>(item, priority);
            _heap.Add(entry);

            for (int i = _heap.Count-1; i > 0; i--)
            {
                SiftUp(i);
            }
        }

        public PriorityEntry<T> PeekNext()
        {
            if (_heap.Count == 0)
            {
                throw new InvalidOperationException("The dispatch queue is empty.");
            }

            return _heap[0];
        }

        public PriorityEntry<T> DequeueNext()
        {
            if (_heap.Count <= 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            PriorityEntry<T> entry = _heap[0];

            for (int i = 0; i < _heap.Count; i++)
            {
                SiftDown(i);
            }

            return entry;
            // TODO:
            // 1. Reject an empty queue.
            // 2. Remember the root: that is the minimum.
            // 3. Move the final heap entry to the root and remove the final slot.
            // 4. If anything remains, restore the invariant downward.
            // 5. Return the old root.
        }

        private void SiftUp(int index)
        {
            if (_heap[index].Priority < _heap[index - 1].Priority)
            {
                Swap(index, index - 1);
            }
        }

        private void SiftDown(int index)
        {
            if (index + 1 >= _heap.Count)
            {
                _heap.RemoveAt(index);
            }
            else
            {
                _heap[index] = _heap[index + 1];
            }
        }

        private static int ParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private static int LeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private static int RightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private void Swap(int a, int b)
        {
            PriorityEntry<T> temp = _heap[a];
            _heap[a] = _heap[b];
            _heap[b] = temp;
        }
    }
}
