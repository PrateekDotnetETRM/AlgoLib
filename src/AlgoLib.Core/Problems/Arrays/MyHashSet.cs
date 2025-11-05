using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{

    public class MyHashSet
    {
        readonly decimal resizeFactor = 0.75m;
        int capacity = 4;
        int threshold = 0;

        int counter = 0;

        Bucket[] buckets;

        public MyHashSet()
        {
            this.threshold = (int)(capacity * resizeFactor);
            this.buckets = new Bucket[capacity];

        }


        public void Add(int key)
        {
            if (counter >= threshold)
            {
                ResizeBucket();
            }


            var hashcode = GetHashCode(key);

            var index = hashcode & (capacity - 1);

            Node current = this.buckets[index].Head;

            while (current != null)
            {
                if (current.value == key)
                {
                    return;
                }
                current = current.next;
            }


            current = new Node(key);

            current.next = this.buckets[index].Head;
            this.buckets[index].Head = current;

            counter++;
        }

        private void ResizeBucket()
        {
            var newCapacity = capacity * 2;
            Bucket[] newBuckets = new Bucket[newCapacity];

            foreach (Bucket bucket in buckets)
            {
                Node current = bucket.Head;
                while (current != null)
                {
                    var key = current.value;
                    var hashcode = GetHashCode(key);

                    var index = hashcode & (newCapacity - 1);


                    Node newBn = newBuckets[index].Head;

                    Node newNode = new(key);
                    newNode.next = newBuckets[index].Head;
                    newBuckets[index].Head = newNode;

                    current = current.next;
                }
            }

            this.buckets = newBuckets;
            this.capacity = newCapacity;
            this.threshold = (int)(this.capacity * this.resizeFactor);
        }

        public void Remove(int key)
        {

            var hashcode = GetHashCode(key);

            var index = hashcode & (capacity - 1);

            Node current = this.buckets[index].Head;
            Node previous = null;

            while (current != null)
            {
                if (current.value == key)
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

        public bool Contains(int key)
        {

            var hashcode = GetHashCode(key);

            var index = hashcode & (capacity - 1);

            Node current = this.buckets[index].Head;


            while (current != null)
            {
                if (current.value == key)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        public uint GetHashCode<T>(T key)
        {


            if (key == null)
                return 0;

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

    public struct Bucket
    {
        public Node Head;
    }

    public class Node
    {
        public int value;
        public Node next;

        public Node(int value , Node next = null)
        {

            this.value = value;
            this.next = next;
        }

    }


}
