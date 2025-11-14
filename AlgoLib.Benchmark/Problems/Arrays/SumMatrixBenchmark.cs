using AlgoLib.Core.Problems.Arrays;
using BenchmarkDotNet.Attributes;

namespace AlgoLib.Benchmark.Problems.Arrays
{

    public class SumMatrixBenchmark
    {
        private SumMatrix _sumMatrix;

        [GlobalSetup]
        public void Setup()
        {
            int size = 1000;
            var matrix = new int[size][];
            var rand = new Random();
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new int[size];
                for (int j = 0; j < size; j++)
                    matrix[i][j] = rand.Next(1, 10);
            }
            _sumMatrix = new SumMatrix(matrix);
        }

        [Benchmark]
        public int BruteForce() => _sumMatrix.SumRegionBruteForce(100, 100, 900, 900);

        [Benchmark]
        public int PrefixSum() => _sumMatrix.SumRegionBetter(100, 100, 900, 900);
    }

}
