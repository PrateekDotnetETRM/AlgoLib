using AlgoLib.Core.Problems.Arrays;
using FluentAssertions;
using Xunit;

namespace AlgoLib.Tests.Problems.Arrays
{


    public class SumMatrixTests
    {
        private readonly int[][] _matrix = {
        new[] {1, 2, 3},
        new[] {4, 5, 6},
        new[] {7, 8, 9}
    };

        private readonly SumMatrix _sumMatrix;

        public SumMatrixTests()
        {
            _sumMatrix = new SumMatrix(_matrix);
        }

        [Fact]
        public void SumRegion_ShouldReturnCorrectValue_ForNormalRange()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(1, 1, 2, 2); // 5+6+8+9 = 28
            var resultBrute = _sumMatrix.SumRegionBruteForce(1, 1, 2, 2);

            resultBetter.Should().Be(28);
            resultBrute.Should().Be(28);
        }

        [Fact]
        public void SumRegion_ShouldHandleSingleCell()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(0, 0, 0, 0); // Only 1
            var resultBrute = _sumMatrix.SumRegionBruteForce(0, 0, 0, 0);

            resultBetter.Should().Be(1);
            resultBrute.Should().Be(1);
        }

        [Fact]
        public void SumRegion_ShouldHandleFullMatrix()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(0, 0, 2, 2); // Sum of all = 45
            var resultBrute = _sumMatrix.SumRegionBruteForce(0, 0, 2, 2);

            resultBetter.Should().Be(45);
            resultBrute.Should().Be(45);
        }

        [Fact]
        public void SumRegion_ShouldHandleFirstRow()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(0, 0, 0, 2); // 1+2+3 = 6
            var resultBrute = _sumMatrix.SumRegionBruteForce(0, 0, 0, 2);

            resultBetter.Should().Be(6);
            resultBrute.Should().Be(6);
        }

        [Fact]
        public void SumRegion_ShouldHandleLastColumn()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(0, 2, 2, 2); // 3+6+9 = 18
            var resultBrute = _sumMatrix.SumRegionBruteForce(0, 2, 2, 2);

            resultBetter.Should().Be(18);
            resultBrute.Should().Be(18);
        }

        [Fact]
        public void SumRegion_ShouldHandleSingleRowMiddle()
        {
            var resultBetter = _sumMatrix.SumRegionBetter(1, 0, 1, 2); // 4+5+6 = 15
            var resultBrute = _sumMatrix.SumRegionBruteForce(1, 0, 1, 2);

            resultBetter.Should().Be(15);
            resultBrute.Should().Be(15);
        }
    }
}
