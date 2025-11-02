using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Easy
    /// Given an array of integers nums and an integer target, return the indices i and j such that nums[i] + nums[j] == target and i != j.
    ///You may assume that every input has exactly one pair of indices i and j that satisfy the condition.
    /// </summary>
    public static class TwoSumSolution
    {
        /// <summary>
        /// Dictionary works pretty well . Will be optimal for moderate to large arrays
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSumOptimized(int[] nums, int target)
        {
            Dictionary<int, int> set = [];

            for (int i = 0; i < nums.Length; i++)
            {
                var diff = target - nums[i];
                if (set.TryGetValue(nums[i], out int j))
                {
                    return [j, i];
                }
                else
                {
                    set[diff] = i;
                }
            }
            return [];
        }

        /// <summary>
        /// Fine for small arrays , Space complexity is constant .
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return [i, j];
                    }
                }
            }
            return []; 
        }
    }
}

