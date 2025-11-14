using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Strings
{
    /// <summary>
    /// Easy : the sum of the absolute difference between the ASCII values of adjacent characters.
    /// </summary>
    public static class ScoreOfString
    {
        /// <summary>
        /// Not much improvement can be made without using Parallel.For and process in chunks . Parallel.For will only help if string is large (10 M chars).
        /// For strings of moderate size it's better to use single thread
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int Score(string input)
        {
            int result = 0;
            for (int i = 1; i < input.Length; i++)
            {
                result += Math.Abs(input[i] - input[i - 1]);
            }
            return result;
        }

        public static int ScoreSpan(string input)
        {
            int result = 0;
            ReadOnlySpan<char> span = input.AsSpan();
            for (int i = 1; i < span.Length; i++)
            {
                int diff = span[i] - span[i - 1];
                result += diff >= 0 ? diff : -diff;
            }

            return result;
        }

        public static int ScoreParallel(string input)
        {
            return Enumerable.Range(1, input.Length - 1)
                .AsParallel()
                .Sum(i => Math.Abs(input[i] - input[i - 1]));
        }


        public static int ScoreSIMD(string input)
        {
            ReadOnlySpan<char> span = input.AsSpan();
            int length = span.Length;
            int result = 0;

            int vectorSize = Vector<int>.Count;
            int i = 1;

            while (i + vectorSize <= length)
            {
                // Convert chars to int arrays for vector operations
                int[] currentArray = new int[vectorSize];
                int[] previousArray = new int[vectorSize];

                for (int j = 0; j < vectorSize; j++)
                {
                    currentArray[j] = span[i + j];
                    previousArray[j] = span[i + j - 1];
                }

                var current = new Vector<int>(currentArray);
                var previous = new Vector<int>(previousArray);

                var diff = current - previous;

                // Accumulate absolute differences
                for (int j = 0; j < vectorSize; j++)
                    result += Math.Abs(diff[j]);

                i += vectorSize;
            }

            // Handle remaining elements
            for (; i < length; i++)
            {
                int diff = span[i] - span[i - 1];
                result += diff >= 0 ? diff : -diff;
            }

            return result;
        }
    }
}
