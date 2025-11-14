using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// HashSet Implementaion
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class MyHashSet<T>
    {
        readonly decimal resizeFactor = 0.75m;
        readonly IEqualityComparer<T> comparer;
        int capacity = 4;
        int threshold = 0;

        int counter = 0;

        Bucket<T>[] buckets;


        public MyHashSet() : this(EqualityComparer<T>.Default) { }

        public MyHashSet(IEqualityComparer<T> comparer)
        {
            this.comparer = comparer ?? EqualityComparer<T>.Default;

            this.threshold = Math.Max(1, (int)(capacity * resizeFactor));
            this.buckets = new Bucket<T>[capacity];
         
            for (int i = 0; i < capacity; i++)
            {
                this.buckets[i] = new();
            }
        }


        public void Add(T key)
        {
            if (counter >= threshold)
            {
                ResizeBucket();
            }


            var hashcode = ComputeHash(key);

            var index = hashcode & (capacity - 1);

            Node<T>? current = this.buckets[index].Head;

            while (current != null)
            {
                if (comparer.Equals(current.value , key))
                {
                    return;
                }
                current = current.next;
            }


            current = new Node<T>(key)
            {
                next = this.buckets[index].Head
            };
            this.buckets[index].Head = current;

            counter++;
        }

        private void ResizeBucket()
        {
            var newCapacity = capacity * 2;
            Bucket<T>[] newBuckets = new Bucket<T>[newCapacity];
            for (int i = 0; i < newCapacity; i++)
            {
                newBuckets[i] = new();
            }

            foreach (Bucket<T> bucket in buckets)
            {
                Node<T>? current = bucket.Head;
                while (current != null)
                {
                    var key = current.value;
                    var hashcode = ComputeHash(key);

                    var index = hashcode & (newCapacity - 1);


                    Node<T>? newBn = newBuckets[index].Head;

                    Node<T> newNode = new(key);
                    newNode.next = newBuckets[index].Head;
                    newBuckets[index].Head = newNode;

                    current = current.next;
                }
            }

            this.buckets = newBuckets;
            this.capacity = newCapacity;
            this.threshold = Math.Max(1, (int)(this.capacity * this.resizeFactor));
        }

        public IEnumerable<T> Items()
        {
            foreach (var bucket in buckets)
            {
                var current = bucket.Head;
                while (current != null)
                {
                    yield return current.value;
                    current = current.next;
                }
            }
        }

        public void Remove(T key)
        {

            var hashcode = ComputeHash(key);

            var index = hashcode & (capacity - 1);

            Node<T>? current = this.buckets[index].Head;
            Node<T>? previous = null;

            while (current != null)
            {
                if (comparer.Equals(current.value, key))
                {
                    if (previous != null)
                        previous.next = current.next;
                    else
                        this.buckets[index].Head = current.next;
                    counter--;
                    break;
                }
                previous = current;
                current = current.next;
            }
        }

        public int Count => counter;

        public bool Contains(T key)
        {

            var hashcode = ComputeHash(key);

            var index = hashcode & (capacity - 1);

            Node<T>? current = this.buckets[index].Head;


            while (current != null)
            {
                if (comparer.Equals(current.value, key))
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public void Clear()
        {
            for (int i = 0; i < capacity; i++)
            {
                buckets[i].Head = null;
            }
            counter = 0;
        }

        public uint ComputeHash(T key)
        {


            if (key == null)
                return 0;

            unchecked
            {
                int rawHash = comparer.GetHashCode(key);
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

    public class Bucket<T>
    {
        public Node<T>? Head;
    }

    public sealed class Node<T>(T value, Node<T>? next = null)
    {
        public T value = value;
        public Node<T>? next = next;
    }


}
