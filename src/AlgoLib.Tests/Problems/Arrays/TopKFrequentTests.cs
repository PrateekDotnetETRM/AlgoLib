using AlgoLib.Core.Problems.Arrays;
using System;
using Xunit;


namespace AlgoLib.Tests.Problems.Arrays
{
  
    public class TopKFrequentTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
        [InlineData(new int[] { 4, 4, 4, 4, 5, 5, 6 }, 1, new int[] { 4 })]
        [InlineData(new int[] { 1 }, 1, new int[] { 1 })]
        public void TestTopKFrequentLinq(int[] nums, int k, int[] expected)
        {
            var result = TopKFrequentElements.TopKFrequentLinq(nums, k);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
        public void TestTopKFrequentBucketSort(int[] nums, int k, int[] expected)
        {
            var result = TopKFrequentElements.TopKFrequentBucketSort(nums, k);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] {  2 , 1 })]
        public void TestTopKFrequentPriorityQueue(int[] nums, int k, int[] expected)
        {
            var result = TopKFrequentElements.TopKFrequentPriorityQueue(nums, k);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 1, 1, 1, 2, 2, 3 }, 2, new int[] { 1, 2 })]
        public void TestTopKFrequentHybrid(int[] nums, int k, int[] expected)
        {
            
            var result = TopKFrequentElements.TopKFrequentHybrid(nums, k);
            Assert.Equal(expected, result);
        }
    }
}
