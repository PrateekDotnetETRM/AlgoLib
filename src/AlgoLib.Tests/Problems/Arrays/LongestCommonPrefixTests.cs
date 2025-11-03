
using AlgoLib.Core.Problems.Arrays;
using FluentAssertions;
using Xunit;

namespace AlgoLib.Tests.Problems.Arrays
{

    public class LongestCommonPrefixTests
    {
        [Theory]
        [InlineData(new[] { "flower", "flow", "flight" }, "fl")]
        [InlineData(new[] { "dog", "racecar", "car" }, "")]
        [InlineData(new[] { "interspecies", "interstellar", "interstate" }, "inters")]
        [InlineData(new[] { "throne", "throne", "throne" }, "throne")]
        [InlineData(new[] { "prefix", "pre", "prefixing" }, "pre")]
        [InlineData(new[] { "a" }, "a")]
        [InlineData(new string[] { }, "")]
        public void ReturnsExpectedPrefix(string[] input, string expected)
        {
            LongestCommonPrefix.FindLongestCommonPrefix(input).Should().Be(expected);
            LongestCommonPrefix.FindLongestCommonPrefixStringBuilder(input).Should().Be(expected);
            LongestCommonPrefix.FindLongestCommonPrefixOptimized(input).Should().Be(expected);


        }

    }
}
