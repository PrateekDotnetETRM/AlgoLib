using AlgoLib.Core.Problems.Arrays;
using FluentAssertions;


namespace AlgoLib.Tests.Problems.Arrays
{
   public class DetectDuplicateTests
    {

        private int[] GenerateLargeArrayWithDuplicates(int size, int duplicateCount)
        {
            var list = Enumerable.Range(0, size - duplicateCount).ToList();
            var rand = new Random();
            for (int i = 0; i < duplicateCount; i++)
            {
                list.Add(rand.Next(0, size - duplicateCount));
            }
            return [.. list];
        }


        private int[] GenerateUniqueArray(int size)
        {
            return [.. Enumerable.Range(0, size)];
        }


        [Fact]
        public void HasDuplicateMethods_ShouldDetectDuplicates()
        {
            int[] nums = GenerateLargeArrayWithDuplicates(1_000_000, 1000);

            DetectDuplicate.HasDuplicate(nums).Should().BeTrue();
            DetectDuplicate.HasDuplicateWithDictionary(nums).Should().BeTrue();
            DetectDuplicate.HasDuplicateParallel(nums).Should().BeTrue();
        }

        [Fact]
        public void HasDuplicateBruteForce_ShouldDetectDuplicatesInSmallArray()
        {
            int[] nums = GenerateLargeArrayWithDuplicates(10_000, 10);
            DetectDuplicate.HasDuplicateBruteForce(nums).Should().BeTrue();
        }


        [Fact]
        public void HasDuplicateMethods_ShouldReturnFalse_WhenNoDuplicates()
        {
            int[] nums = GenerateUniqueArray(1_000_000);


            DetectDuplicate.HasDuplicate(nums).Should().BeFalse();
            DetectDuplicate.HasDuplicateWithDictionary(nums).Should().BeFalse();
            DetectDuplicate.HasDuplicateParallel(nums).Should().BeFalse();
        }

        [Fact]
        public void HasDuplicateBruteForce_ShouldReturnFalse_WhenNoDuplicatesInSmallArray()
        {
            int[] nums = GenerateUniqueArray(10_000);
            DetectDuplicate.HasDuplicateBruteForce(nums).Should().BeFalse();
        }


    }
}
