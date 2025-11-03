using Xunit;
using FluentAssertions;
using AlgoLib.Core.Problems.Arrays;


namespace AlgoLib.Tests.Problems.Arrays
{ 
    public class GroupAnagramsTests
    {
        [Theory]
        [MemberData(nameof(TestCases))]
        public void GroupAnagramsLinq_ShouldMatchExpectedOutput(string[] input, List<List<string>> expected)
        {
            var result = GroupAnagrams.FindGroupAnagramsWithLinq(input);
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void GroupAnagrams_ShouldMatchExpectedOutput(string[] input, List<List<string>> expected)
        {
            var result = GroupAnagrams.FindGroupAnagramsWithLinq(input);
            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> TestCases =>
            [
            [
                new[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                new List<List<string>>
                {
                    new() { "eat", "tea", "ate" },
                    new() { "tan", "nat" },
                    new() { "bat" }
                }
            ],
            [
                new[] { "abc", "bca", "cab", "xyz", "zyx", "yxz" },
                new List<List<string>>
                {
                    new() { "abc", "bca", "cab" },
                    new() { "xyz", "zyx", "yxz" }
                }
            ],
            [
                new[] { "a" },
                new List<List<string>>
                {
                    new() { "a" }
                }
            ],
            [
                new[] { "aaa", "aaa", "aaa" },
                new List<List<string>>
                {
                    new() { "aaa", "aaa", "aaa" }
                }
            ],
            [
                Array.Empty<string>(),
                new List<List<string>>()
            ],
            [
                new[] { "listen", "silent", "enlist", "google", "gogole", "elgoog" },
                new List<List<string>>
                {
                    new() { "listen", "silent", "enlist" },
                    new() { "google", "gogole", "elgoog" }
                }
            ]
            ];

    }
}
