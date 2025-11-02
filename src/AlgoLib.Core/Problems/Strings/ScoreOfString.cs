using System;
using System.Collections.Generic;
using System.Linq;
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
        /// Not much improvement can be made without using Parallel.For and process in chunks . Parallel.For will only help if string is large.
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
    }
}
