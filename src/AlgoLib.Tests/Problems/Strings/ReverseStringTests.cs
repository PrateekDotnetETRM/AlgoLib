using AlgoLib.Core.Problems.Strings;
using FluentAssertions;
using Xunit;

namespace AlgoLib.Tests.Problems.Strings
{
    public class ReverseStringTests
    {
        [Theory]
        [InlineData("racecar", "racecar")]           // Palindrome
        [InlineData("12345", "54321")]               // Numeric string
        [InlineData("!@#$%", "%$#@!")]               // Special characters
        [InlineData("a b c", "c b a")]               // Spaces between characters
        [InlineData("  leading", "gnidael  ")]       // Leading spaces
        [InlineData("trailing  ", "  gniliart")]     // Trailing spaces
        [InlineData("こんにちは", "はちにんこ")]     // Unicode (Japanese)
        [InlineData("The quick brown fox", "xof nworb kciuq ehT")] // Sentence
        [InlineData("a\nb\nc", "c\nb\na")]           // Newlines
        [InlineData("tab\tseparated", "detarapes\tbat")] // Tabs
        [InlineData("longstringwithmanycharacters", "sretcarahcynamhtiwgnirtsgnol")] // Long string
        public void ReverseUsingSpanReverse_ShouldReturnExpected(string input, string expected)
        {
            var result = ReverseString.ReverseUsingSpanReverse(input);
            result.Should().Be(expected);
        }
    }
}
