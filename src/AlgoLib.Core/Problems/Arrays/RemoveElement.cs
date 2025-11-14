using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// You are given an integer array nums and an integer val. The task is to remove all occurrences of val from nums in-place.
    /// After removing all occurrences of val, return the number of remaining elements, say k, such that the first k elements of nums do not contain val.
    /// Easy : O(n) 
    /// </summary>
    public static class RemoveElement
    {

        public static int RemoveElementOptimized(int[] nums, int val)
        {
            int k = 0; // Index for the next valid element
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[k] = nums[i];
                    k++;
                }
            }
            return k;
        }

        public static int RemoveElementOptimizedTwo(int[] nums, int val)
        {
            int i = 0, n = nums.Length;
            while (i < n)
            {
                if (nums[i] == val)
                {
                    nums[i] = nums[--n];
                }
                else
                {
                    i++;
                }
            }
            return n;
        }

        public static int RemoveElementBruteforce(int[] nums, int val)
        {
            int count = 0;
            int i = 0;
            int k = nums.Length;
            while (i < k - count)
            {
                if (nums[i] == val)
                {
                    count++;
                    for (int j = i; j < nums.Length - count; j++)
                    {
                        nums[j] = nums[j + 1];
                    }
                }
                else
                {
                    i++;
                }
            }
            return nums.Length - count;
        }
    }
}
