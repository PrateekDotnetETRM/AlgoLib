using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Given an integer array nums and an integer k, return the k most frequent elements within the array.
    /// </summary>
    public static class TopKFrequentElements
    {
        public static int[] TopKFrequentLinq(int[] nums, int k)
        {
            return nums
                     .GroupBy(x => x)
                     .OrderByDescending(x => x.Count())
                     .Take(k)
                     .Select(x => x.Key)
                     .ToArray();
        }

        public static int[] TopKFrequentBucketSort(int[] nums, int k)
        {
            // Step 1: Count frequencies
            Dictionary<int, int> frequency = [];
            foreach (var num in nums)
            {
                frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
            }

            // Step 2: Use a array of list to store frequency -> for nums
            List<int>[] buckets = new List<int>[nums.Length + 1];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new();
            }


            foreach (var pair in frequency)
            {
                buckets[pair.Value].Add(pair.Key);
            }

            List<int> res = [];

            //Iterate from bigger count bucket to lower and save keys to res list
            for (int i = buckets.Length - 1; i > 0; i--)
            {
                foreach (var item in buckets[i])
                {
                    res.Add(item);
                    if (res.Count == k)
                    {
                        return [.. res];
                    }
                }
            }


            return [];
        }

        public static int[] TopKFrequentDictionary(int[] nums, int k)
        {
            Dictionary<int, int> frequency = new();

            foreach (var item in nums)
            {
                var c = frequency.GetValueOrDefault(item);

                frequency[item] = c + 1;
            }

            return frequency.OrderByDescending(x => x.Value).Take(k).Select(g => g.Key).ToArray();

        }


        public static int[] TopKFrequentPriorityQueue(int[] nums, int k)
        {
            // Step 1: Count frequencies
            Dictionary<int, int> frequency = new();
            foreach (var num in nums)
            {
                frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
            }

            // Step 2: Use a min-heap to keep top k elements
            var pq = new PriorityQueue<int, int>(); // element, priority (frequency)

            foreach (var pair in frequency)
            {
                pq.Enqueue(pair.Key, pair.Value);
                if (pq.Count > k)
                {
                    pq.Dequeue(); // remove smallest frequency
                }
            }

            // Step 3: Extract elements from heap
            var result = new List<int>();
            while (pq.Count > 0)
            {
                result.Add(pq.Dequeue());
            }


            return [.. result];
        }



        public static int[] TopKFrequentHybrid(int[] nums, int k)
        {
            // Step 1: Count frequencies
            var frequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                frequency[num] = frequency.GetValueOrDefault(num, 0) + 1;
            }

            int m = frequency.Count;

            // Step 2: Choose strategy
            if (k <= m / 2)
            {
                // Min-Heap approach
                var pq = new PriorityQueue<int, int>();
                foreach (var pair in frequency)
                {
                    pq.Enqueue(pair.Key, pair.Value);
                    if (pq.Count > k)
                    {
                        pq.Dequeue(); // remove smallest frequency
                    }
                }

                var result = new List<int>();
                while (pq.Count > 0)
                {
                    result.Add(pq.Dequeue());
                }
                return [.. result];
            }
            else
            {
                // Max-Heap approach if k is bigger 
                var pq = new PriorityQueue<int, int>();
                foreach (var pair in frequency)
                {
                    pq.Enqueue(pair.Key, -pair.Value); // negative for max-heap behavior
                }

                var result = new List<int>();
                for (int i = 0; i < k; i++)
                {
                    result.Add(pq.Dequeue());
                }
                return [.. result];
            }
        }
    }
}

