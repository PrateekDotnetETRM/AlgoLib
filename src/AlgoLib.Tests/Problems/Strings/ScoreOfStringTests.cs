using AlgoLib.Core.Problems.Strings;
using FluentAssertions;

namespace AlgoLib.Tests.Problems.Strings
{
    public class ScoreOfStringTests
    {

        [Theory]
        [InlineData("", 0)]                  // Empty string
        [InlineData("a", 0)]                 // Single character
        [InlineData("ab", 1)]                // Simple difference
        [InlineData("abc", 2)]              // a->b (1), b->c (1)
        [InlineData("cba", 2)]              // c->b (1), b->a (1)
        [InlineData("aaa", 0)]              // No difference
        [InlineData("az", 25)]              // a->z
        [InlineData("azaz", 75)]            // a->z (25), z->a (25), a->z (25)
        [InlineData("123", 2)]              // '1'->'2' (1), '2'->'3' (1)
        [InlineData("!@#", 60)]              // ASCII differences       
        public void Score_ShouldReturnExpected(string input, int expected)
        {
            var result = ScoreOfString.Score(input); 
            result.Should().Be(expected);
        }

    }
}
