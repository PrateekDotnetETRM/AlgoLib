using BenchmarkDotNet.Attributes;
using AlgoLib.Core.Problems.Arrays;

namespace AlgoLib.Benchmark.Problems.Arrays
{
    public class SortArrayBenchmarks
    {
        private int[] data;
        private const int Size = 100_000;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new Random();
            data = new int[Size];
            for (int i = 0; i < Size; i++)
                data[i] = rand.Next(0, 1_000_000);
        }

        [Benchmark]
        public int[] MergeSort() => SortArray.SortArrayMergeSort((int[])data.Clone());

        [Benchmark]
        public int[] HeapSort() => SortArray.SortArrayHeapSort((int[])data.Clone());

        [Benchmark]
        public int[] HybridMergeSort() => SortArray.HybridMergeSort((int[])data.Clone());

        [Benchmark]
        public int[] QuickSort() => SortArray.SortArrayQuickSort((int[])data.Clone());

       
    }
}