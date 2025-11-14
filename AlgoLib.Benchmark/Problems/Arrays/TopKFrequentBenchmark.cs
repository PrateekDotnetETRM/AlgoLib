using AlgoLib.Core.Problems.Arrays;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;

namespace AlgoLib.Benchmark.Problems.Arrays
{

    [MemoryDiagnoser]
    public class TopKFrequentBenchmark
    {
        private int[] nums;
        private int k;

        [Params(10000, 100000, 500000)]
        public int Size;

        [Params(5, 50, 500)]
        public int K;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new Random();
            nums = Enumerable.Range(0, Size).Select(_ => rand.Next(0, 1000)).ToArray();
            k = K;
        }

        [Benchmark]
        public int[] LinqVersion() => TopKFrequentElements.TopKFrequentLinq(nums, k);

        [Benchmark]
        public int[] BucketSortVersion() => TopKFrequentElements.TopKFrequentBucketSort(nums, k);

        [Benchmark]
        public int[] DictionaryVersion() => TopKFrequentElements.TopKFrequentDictionary(nums, k);

        [Benchmark]
        public int[] PriorityQueueVersion() => TopKFrequentElements.TopKFrequentPriorityQueue(nums, k);

        [Benchmark]
        public int[] HybridVersion() => TopKFrequentElements.TopKFrequentHybrid(nums, k);
    }

}
