using AlgoLib.Core.Problems.Arrays;
using FluentAssertions;
using Xunit;


namespace AlgoLib.Tests.Problems.Arrays
{

    public class RemoveElementTheoryTests
    {
        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 }, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 1, 3, 0, 4 }, 5)]
        [InlineData(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3 }, 3)]
        [InlineData(new int[] { 5, 5, 5 }, 5, new int[] { }, 0)]
        [InlineData(new int[] { }, 1, new int[] { }, 0)]
        public void RemoveElementOptimized_ShouldRemoveValueAndReturnCorrectLength(
            int[] input, int val, int[] expectedArray, int expectedLength)
        {
            
            // Act
            int actualLength = RemoveElement.RemoveElementOptimized(input, val);

            // Assert
            actualLength.Should().Be(expectedLength);
            input[..actualLength].Should().BeEquivalentTo(expectedArray);
        }

        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, new int[] { 2, 2 }, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new int[] { 0, 1, 3, 0, 4 }, 5)]
        [InlineData(new int[] { 1, 2, 3 }, 4, new int[] { 1, 2, 3 }, 3)]
        [InlineData(new int[] { 5, 5, 5 }, 5, new int[] { }, 0)]
        [InlineData(new int[] { }, 1, new int[] { }, 0)]
        public void RemoveElementBruteForce_ShouldRemoveValueAndReturnCorrectLength(
            int[] input, int val, int[] expectedArray, int expectedLength)
        {

            // Act
            int actualLength = RemoveElement.RemoveElementBruteforce(input, val);

            // Assert
            actualLength.Should().Be(expectedLength);
            input[..actualLength].Should().BeEquivalentTo(expectedArray);
        }
    }

}
