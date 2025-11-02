using FluentAssertions;
using AlgoLib.Core.Problems.Arrays;

namespace AlgoLib.Tests.Problems.Arrays
{
    public class TwoSumSolutionTests
    {

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [InlineData(new int[] { -3, 4, 3, 90 }, 0, new int[] { 0, 2 })]        
        public void OptimizedTwoSum_ShouldReturnExpected(int[] nums, int target, int[] expected)
        {
            var result = TwoSumSolution.TwoSumOptimized(nums, target);

            if (expected != null)
            {
                result.Should().BeEquivalentTo(expected);
            }
            else
            {
                result.Length.Should().Be(2);
                (nums[result[0]] + nums[result[1]]).Should().Be(target);
            }
        }

        [Fact]
        public void BruteForceTwoSum_ShouldReturnExpected()
        {
            int[] nums = { 2, 7, 11, 15 };
            int target = 9;

            var result = TwoSumSolution.TwoSumBruteForce(nums, target);
            result.Should().BeEquivalentTo(new int[] { 0, 1 });
        }

        [Fact]
        public void TwoSum_ShouldReturnEmpty_WhenNoSolution()
        {
            int[] nums = { 1, 2, 3 };
            int target = 7;

            var result = TwoSumSolution.TwoSumOptimized(nums, target);
            result.Should().BeEmpty();
        }

       
    }
}