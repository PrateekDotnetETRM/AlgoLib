using Xunit;
using FluentAssertions;
using AlgoLib.Core.Problems.Arrays;

namespace AlgoLib.Tests.Problems.Arrays
{

    public class ProductExceptSelfTests
    {
        [Fact]
        public void ImprovedVersion_ShouldReturnCorrectResult()
        {
            var nums = new[] { 1, 2, 3, 4 };
            var expected = new[] { 24, 12, 8, 6 };

            var result = ProductExceptSelf.ProductExceptSelf_ImprovedBruteForce(nums);

            result.Should().Equal(expected);
        }

        [Fact]
        public void NoDivisionVersion_ShouldReturnCorrectResult()
        {
            var nums = new[] { 1, 2, 3, 4 };
            var expected = new[] { 24, 12, 8, 6 };

            var result = ProductExceptSelf.ProductExceptSelfNoDivision(nums);

            result.Should().Equal(expected);
        }

        [Fact]
        public void BruteForceVersion_ShouldReturnCorrectResult()
        {
            var nums = new[] { 1, 2, 3, 4 };
            var expected = new[] { 24, 12, 8, 6 };

            var result = ProductExceptSelf.ProductExceptSelfBruteForce(nums);

            result.Should().Equal(expected);
        }

        [Fact]
        public void HandlesZerosCorrectly()
        {
            var nums = new[] { 1, 2, 0, 4 };
            var expectedImproved = new[] { 0, 0, 8, 0 };
            var expectedNoDivision = new[] { 0, 0, 8, 0 };

            var bruteResult = ProductExceptSelf.ProductExceptSelfBruteForce(nums);
            var improvedResult = ProductExceptSelf.ProductExceptSelf_ImprovedBruteForce(nums);
            var noDivisionResult = ProductExceptSelf.ProductExceptSelfNoDivision(nums);

            bruteResult.Should().Equal(expectedImproved);
            improvedResult.Should().Equal(expectedImproved);
            noDivisionResult.Should().Equal(expectedNoDivision);
        }

        [Fact]
        public void HandlesDoubleZerosCorrectly()
        {
            var nums = new[] { 1, 2, 0, 4 ,0 , 11 , 12 ,14,15 };
            var expectedImproved = new[] { 0, 0, 0, 0 , 0 , 0, 0, 0, 0 };
            var expectedNoDivision = new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var bruteResult = ProductExceptSelf.ProductExceptSelfBruteForce(nums);
            var improvedResult = ProductExceptSelf.ProductExceptSelf_ImprovedBruteForce(nums);
            var noDivisionResult = ProductExceptSelf.ProductExceptSelfNoDivision(nums);

            bruteResult.Should().Equal(expectedImproved);
            improvedResult.Should().Equal(expectedImproved);
            noDivisionResult.Should().Equal(expectedNoDivision);
        }
    }

}
