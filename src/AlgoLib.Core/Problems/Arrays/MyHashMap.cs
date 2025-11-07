using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public class MyHashMap
    {
        Bucket[] buckets;
        private readonly decimal resizeFactor = 0.90m;
        private uint capacity = 4;
        private uint count = 0;
        private uint threshold = 0;
        private const uint MaxCapacity = 1u << 30; 

        public MyHashMap()
        {
            buckets = new Bucket[capacity];
            threshold = (uint)(capacity * resizeFactor);
            for (int i = 0; i < capacity; i++)
            {
                buckets[i] = new();
            }
        }

        public void Put(int key, int value)
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
                if (current.Key == key)
                {
                    current.Value = value;
                    return;
                }
                current = current.Next;
            }

            Node newNode = new(key, value, buckets[index].Head);
            buckets[index].Head = newNode;
            count++;
        }

        public bool TryGetValue(int key, out int value)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node current = buckets[index].Head;
            while (current != null)
            {
                if (current.Key == key)
                {
                    value = current.Value;
                    return true;
                }
                current = current.Next;
            }

            value = default;
            return false;
        }

        public IEnumerable<KeyValuePair<int, int>> GetAll()
        {
            foreach (var bucket in buckets)
            {
                var current = bucket.Head;
                while (current != null)
                {
                    yield return new KeyValuePair<int, int>(current.Key, current.Value);
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

            Bucket[] newBuckets = new Bucket[newCapacity];
            for (int i = 0; i < newCapacity; i++)
            {
                newBuckets[i] = new();
            }

            foreach (Bucket bucket in buckets)
            {
                Node? current = bucket.Head;
                while (current != null)
                {
                    var key = current.Key;
                    var value = current.Value;
                    var hashcode = ComputeHash(key);
                    var index = hashcode & (newCapacity - 1);

                    Node newNode = new(key, value, newBuckets[index].Head);
                    newBuckets[index].Head = newNode;
                    current = current.Next;
                }
            }

            this.buckets = newBuckets;
            this.capacity = newCapacity;
            this.threshold = Math.Max(1, (uint)(this.capacity * this.resizeFactor));
        }

        public int Get(int key)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node currentBucket = buckets[index].Head;

            while (currentBucket != null)
            {
                if (currentBucket.Key == key)
                {
                    return currentBucket.Value;
                }
                currentBucket = currentBucket.Next;
            }
            return -1;
        }

        public void Remove(int key)
        {
            var hashCode = ComputeHash(key);
            var index = hashCode & (capacity - 1);

            Node current = buckets[index].Head;
            Node previous = null;
            while (current != null)
            {
                if (current.Key == key)
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

        public uint ComputeHash(int key)
        {
            unchecked
            {
                int rawHash = key.GetHashCode();
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

    public sealed class Bucket
    {
        public Node Head;
    }

    public sealed class Node
    {
        public int Key;
        public int Value;
        public Node Next;
        public Node(int key, int value, Node next = null)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}
