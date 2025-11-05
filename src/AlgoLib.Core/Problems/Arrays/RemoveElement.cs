using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
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
