using AlgoLib.Core.Problems.Strings;
using FluentAssertions;

namespace AlgoLib.Tests.Problems.Strings
{
    public class DetectAnagramTests
    {

        [Theory]
        [InlineData("你好", "好你")]               // Chinese characters
        [InlineData("résumé", "ésumér")]         // Accented Latin characters        
        [InlineData("𝔘𝔫𝔦𝔠𝔬𝔡𝔢", "𝔡𝔢𝔠𝔬𝔫𝔦𝔘")]       // Unicode Gothic letters
        [InlineData("á", "á")]                   // Combining vs composed character (may fail without normalization)
        public void IsAnagram_ShouldReturnTrue_ForUnicodeAnagrams(string s, string t)
        {
            var result = DetectAnagram.IsAnagram(s, t);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("你好", "你你")]               // Not anagrams
        [InlineData("résumé", "resume")]         // Missing accents
        [InlineData("𝔘𝔫𝔦𝔠𝔬𝔡𝔢", "Unicode")]         // Different character sets
        public void IsAnagram_ShouldReturnFalse_ForNonAnagrams(string s, string t)
        {
            var result = DetectAnagram.IsAnagram(s, t);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("你好", "好你")]               // Chinese characters
        [InlineData("résumé", "ésumér")]         // Accented Latin characters        
        [InlineData("𝔘𝔫𝔦𝔠𝔬𝔡𝔢", "𝔡𝔢𝔠𝔬𝔫𝔦𝔘")]       // Unicode Gothic letters
        [InlineData("á", "á")]                   // Combining vs composed character (may fail without normalization)
        public void IsAnagramDifferent_ShouldReturnTrue_ForUnicodeAnagrams(string s, string t)
        {
            var result = DetectAnagram.IsAnagramDifferent(s, t);
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("你好", "你你")]               // Not anagrams
        [InlineData("résumé", "resume")]         // Missing accents
        [InlineData("𝔘𝔫𝔦𝔠𝔬𝔡𝔢", "Unicode")]         // Different character sets
        public void IsAnagramDifferent_ShouldReturnFalse_ForNonAnagrams(string s, string t)
        {
            var result = DetectAnagram.IsAnagramDifferent(s, t);
            result.Should().BeFalse();
        }
    }
}
