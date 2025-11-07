using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public class MyHashMap<T, U>
    {
        Bucket<T, U>[] buckets;
        private readonly decimal resizeFactor = 0.90m;
        private uint capacity = 4;
        private uint count = 0;
        private uint threshold = 0;
        private const uint MaxCapacity = 1u << 30;
        private readonly IEqualityComparer<T> comparer;

        public MyHashMap() : this(EqualityComparer<T>.Default)
        {

        }

        public MyHashMap(IEqualityComparer<T> comparer)
        {
            this.comparer = comparer;
            buckets = new Bucket<T, U>[capacity];
            threshold = (uint)(capacity * resizeFactor);
            for (int i = 0; i < capacity; i++)
            {
                buckets[i] = new();
            }
        }

        public void Put(T key, U value)
        {
            if (count >= threshold)
            {
                Resize();
            }

            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            var current = buckets[index].Head;

            while (current != null)
            {
                if (this.comparer.Equals(current.Key, key))
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }

            Node<T, U> newNode = new(key, value, buckets[index].Head);
            buckets[index].Head = newNode;
            count++;
        }

        public bool TryGetValue(T key, out U value)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node<T, U> current = buckets[index].Head;
            while (current != null)
            {
                if (this.comparer.Equals(current.Key, key))
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            value = default;
            return false;
        }

        public IEnumerable<KeyValuePair<T, U>> GetAll()
        {
            foreach (var bucket in buckets)
            {
                var current = bucket.Head;
                while (current != null)
                {
                    yield return new KeyValuePair<T, U>(current.Key, current.Value);
                    current = current.Next;
                }
            }
        }

        private void Resize()
        {
            // Overflow protection
            if (capacity > uint.MaxValue >> 1 || capacity >= MaxCapacity)
            {
                throw new InvalidOperationException("Cannot resize: capacity overflow or exceeds maximum allowed.");
            }

            uint newCapacity = capacity << 1;

            Bucket<T, U>[] newBuckets = new Bucket<T, U>[newCapacity];
            for (int i = 0; i < newCapacity; i++)
            {
                newBuckets[i] = new();
            }

            foreach (Bucket<T, U> bucket in buckets)
            {
                Node<T, U>? current = bucket.Head;
                while (current != null)
                {
                    var key = current.Key;
                    var value = current.Value;
                    var hashcode = ComputeHash(key);
                    var index = hashcode & (newCapacity - 1);

                    Node<T, U> newNode = new(key, value, newBuckets[index].Head);
                    newBuckets[index].Head = newNode;
                    current = current.Next;
                }
            }

            this.buckets = newBuckets;
            this.capacity = newCapacity;
            this.threshold = Math.Max(1, (uint)(this.capacity * this.resizeFactor));
        }

        public U Get(T key)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node<T, U> current = buckets[index].Head;

            while (current != null)
            {
                if (this.comparer.Equals(current.Key, key))
                {
                    return current.Value;
                }
                current = current.Next;
            }
            throw new ArgumentException($"This key doesn't exists.");
        }

        public void Remove(T key)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node<T, U> current = buckets[index].Head;
            Node<T, U> previous = null;
            while (current != null)
            {
                if (this.comparer.Equals(current.Key, key))
                {
                    if (previous == null)
                        buckets[index].Head = current.Next;
                    else
                        previous.Next = current.Next;

                    count--;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        public uint ComputeHash(T key)
        {
            if (key == null)
            {
                return 0;
            }
            unchecked
            {
                int rawHash = this.comparer.GetHashCode(key);
                uint hash = (uint)rawHash;

                // Bit mixing for better distribution
                hash ^= hash >> 16;
                hash *= 0x85ebca6b;
                hash ^= hash >> 13;
                hash *= 0xc2b2ae35;
                hash ^= hash >> 16;

                return hash;
            }
        }
    }

    public sealed class Bucket<T, U>
    {
        public Node<T, U>? Head;
    }

    public sealed class Node<T, U>(T key, U value, Node<T, U> next = null)
    {
        public T Key = key;
        public U Value = value;
        public Node<T, U> Next = next;
    }


    public class FastHashMap<T, U> : IEnumerable<KeyValuePair<T, U>>
    {
        private struct Entry
        {
            public T Key;
            public U Value;
            public bool IsOccupied;
        }

        private Entry[] entries;
        private int count;
        private int capacity;
        private int threshold;
        private readonly float loadFactor = 0.75f;
        private readonly IEqualityComparer<T> comparer;

        public FastHashMap(int initialCapacity = 4, IEqualityComparer<T> comparer = null)
        {
            this.capacity = NextPowerOfTwo(initialCapacity);
            this.entries = new Entry[this.capacity];
            this.threshold = (int)(this.capacity * loadFactor);
            this.comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public void Put(T key, U value)
        {
            if (count >= threshold)
                Resize();

            int index = ProbeIndex(key);
            if (!entries[index].IsOccupied)
            {
                count++;
            }

            entries[index].Key = key;
            entries[index].Value = value;
            entries[index].IsOccupied = true;
        }

        public bool TryGetValue(T key, out U value)
        {
            int index = ProbeIndex(key, false);
            if (index >= 0 && entries[index].IsOccupied)
            {
                value = entries[index].Value;
                return true;
            }

            value = default;
            return false;
        }

        public bool ContainsKey(T key)
        {
            return ProbeIndex(key, false) >= 0;
        }

        public void Remove(T key)
        {
            int index = ProbeIndex(key, false);
            if (index >= 0 && entries[index].IsOccupied)
            {
                entries[index].IsOccupied = false;
                count--;
            }
        }

        public void Clear()
        {
            Array.Clear(entries, 0, entries.Length);
            count = 0;
        }

        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i].IsOccupied)
                    yield return new KeyValuePair<T, U>(entries[i].Key, entries[i].Value);
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private int ProbeIndex(T key, bool forInsert = true)
        {
            int hash = ComputeHash(key);
            int index = hash & (capacity - 1);

            while (true)
            {
                if (!entries[index].IsOccupied)
                    return forInsert ? index : -1;

                if (comparer.Equals(entries[index].Key, key))
                    return index;

                index = (index + 1) & (capacity - 1); // wrap around
            }
        }

        private void Resize()
        {
            int newCapacity = capacity << 1;
            var newEntries = new Entry[newCapacity];

            foreach (var kvp in this)
            {
                int hash = ComputeHash(kvp.Key);
                int index = hash & (newCapacity - 1);

                while (newEntries[index].IsOccupied)
                    index = (index + 1) & (newCapacity - 1);

                newEntries[index].Key = kvp.Key;
                newEntries[index].Value = kvp.Value;
                newEntries[index].IsOccupied = true;
            }

            entries = newEntries;
            capacity = newCapacity;
            threshold = (int)(capacity * loadFactor);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int ComputeHash(T key)
        {
            if (key == null)
            {
                return 0;
            }
            unchecked
            {
                int rawHash = this.comparer.GetHashCode(key);
                uint hash = (uint)rawHash;

                // Bit mixing for better distribution
                hash ^= hash >> 16;
                hash *= 0x85ebca6b;
                hash ^= hash >> 13;
                hash *= 0xc2b2ae35;
                hash ^= hash >> 16;

                return (int)hash;
            }
        }

        private static int NextPowerOfTwo(int x)
        {
            if (x < 1) return 1;
            return 1 << (32 - BitOperations.LeadingZeroCount((uint)x - 1));
        }
    }

}
