using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using AlgoLib.Core.Problems.Arrays;

namespace AlgoLib.Benchmark.Problems.Arrays
{

    public class ProductExceptSelfBenchmark
    {
        private int[] nums;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new Random();
            nums = new int[1_000_000];
            for (int i = 0; i < nums.Length; i++)
                nums[i] = rand.Next(-20, 20);
        }
        [Benchmark]
        public int[] BruteForceVersion() => ProductExceptSelf.ProductExceptSelfBruteForce(nums);

        [Benchmark]
        public int[] ImprovedVersion() => ProductExceptSelf.ProductExceptSelf_ImprovedBruteForce(nums);

        [Benchmark]
        public int[] NoDivisionVersion() => ProductExceptSelf.ProductExceptSelfNoDivision(nums);


    }

}
