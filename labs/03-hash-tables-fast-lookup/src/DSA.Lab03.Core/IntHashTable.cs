using System;
using System.Collections.Generic;

namespace DSA.Lab03
{
    public sealed class IntHashTable<TValue>
    {
        private readonly List<Entry<TValue>>[] _buckets;
        private int _count;

        public IntHashTable(int bucketCount)
        {
            if (bucketCount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(bucketCount));
            }

            _buckets = new List<Entry<TValue>>[bucketCount];
            for (int i = 0; i < _buckets.Length; ++i)
            {
                _buckets[i] = new List<Entry<TValue>>();
            }
        }
        public int Count => _count;
        public int BucketCount => _buckets.Length;

        public void Set(int key, TValue value)
        {
            if (key < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "This learning implementation uses non-negative integer keys.");
            }
            
            bool hasCopy = false;
            if (_buckets[GetBucketIndex(key)].Count == 0)
            {
                _buckets[GetBucketIndex(key)].Add(new Entry<TValue>(key, value));
                _count++;
            }
            for (int i = 0; i < _buckets[GetBucketIndex(key)].Count; i++)
            {
                if (_buckets[GetBucketIndex(key)][i].Key == key)
                {
                    _buckets[GetBucketIndex(key)][i] = new Entry<TValue>(key, value);
                    hasCopy = true;
                }
            }
            if (hasCopy == false)
            {
                _buckets[GetBucketIndex(key)].Add(new Entry<TValue>(key, value));
                _count++;
            }
            // TODO: search only the correct bucket, replace or append.
        }

        public bool TryGetValue(int key, out TValue value)
        {
            for (int i = 0; i < _buckets[GetBucketIndex(key)].Count; i++)
            {
                if (_buckets[GetBucketIndex(key)][i].Key == key)
                {
                    value = _buckets[GetBucketIndex(key)][i].Value;
                    return true;
                }
            }
            // TODO: search only the correct bucket.
            value = default!;
            return false;
        }

        public bool ContainsKey(int key)
        {
            for (int i = 0; i < _buckets[GetBucketIndex(key)].Count; i++)
            {
                if (_buckets[GetBucketIndex(key)][i].Key == key)
                {
                    return true;
                }
            }
            return false;
            // TODO: reuse the lookup behavior if useful.
        }

        private int GetBucketIndex(int key)
        {
            if (key < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "This learning implementation uses non-negative integer keys.");
            }

            return key % _buckets.Length;
        }
    }
}
