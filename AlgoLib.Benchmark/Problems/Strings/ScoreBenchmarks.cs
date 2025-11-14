using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Linq;
using System.Numerics;
using AlgoLib.Core.Problems.Strings;

namespace AlgoLib.Benchmark.Problems.Strings
{

    public class ScoreBenchmarks
    {
        private string input;

        [Params(100, 1_000, 10_000, 100_000, 1_000_000, 10_000_000)]
        public int Size;

        [GlobalSetup]
        public void Setup()
        {
            var rand = new Random();
            input = new string(Enumerable.Range(0, Size)
                .Select(_ => (char)rand.Next(65, 91)) // A-Z
                .ToArray());
        }

        [Benchmark]
        public int OriginalVersion() => ScoreOriginal(input);

        [Benchmark]
        public int SpanVersion() => ScoreOfString.ScoreSpan(input);

        [Benchmark]
        public int SIMDVersion() => ScoreOfString.ScoreSIMD(input);

        [Benchmark]
        public int ParallelVersion() => ScoreOfString.ScoreParallel(input);

        public static int ScoreOriginal(string input)
        {
            int result = 0;
            for (int i = 1; i < input.Length; i++)
            {
                int diff = input[i] - input[i - 1];
                result += diff >= 0 ? diff : -diff;
            }
            return result;
        }

    }

}
