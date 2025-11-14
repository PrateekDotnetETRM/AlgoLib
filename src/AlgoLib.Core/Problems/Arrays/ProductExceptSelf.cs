using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Given an integer array nums, return an array output where output[i] is the product of all the elements of nums except nums[i].
    /// Each product is guaranteed to fit in a 32-bit integer.
    /// Best version can be prefix postfix calculation . if division is allowed then better use bruteforce optimized version 
    /// </summary>
    public static class ProductExceptSelf
    {
        public static int[] ProductExceptSelfBruteForce(int[] nums)
        {
            int n = nums.Length;
            int zeroCount = 0;
            long product = 1;

            foreach (var num in nums)
            {
                if (num == 0)
                    zeroCount++;
                else
                    product *= num;
            }

            int[] result = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (zeroCount > 1)
                    result[i] = 0;
                else if (zeroCount == 1)
                    result[i] = nums[i] == 0 ? (int)product : 0;
                else
                    result[i] = (int)(product / nums[i]);
            }

            return result;
        }

        public static int[] ProductExceptSelf_ImprovedBruteForce(int[] nums)
        {
            int n = nums.Length;
            int zeroCount = 0;
            long product = 1;

            foreach (var num in nums)
            {
                if (num == 0)
                    zeroCount++;
                else
                    product *= num;
            }

            int[] result = new int[n];
            if (zeroCount > 1)
                return result;

            for (int i = 0; i < n; i++)
            {
                if (zeroCount == 0)
                    result[i] = (int)(product / nums[i]);
                else
                    result[i] = nums[i] == 0 ? (int)product : 0;

            }

            return result;
        }

        public static int[] ProductExceptSelfNoDivision(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            int zeroCount = 0;

            foreach (var num in nums)
                if (num == 0) zeroCount++;

            if (zeroCount > 1)
                return result; // all zeros

            result[0] = 1;
            for (int i = 1; i < n; i++)
                result[i] = result[i - 1] * (nums[i - 1] == 0 ? 1 : nums[i - 1]);

            int suffix = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                if (zeroCount == 1 && nums[i] != 0)
                    result[i] = 0;
                else
                    result[i] *= suffix;

                suffix *= (nums[i] == 0 ? 1 : nums[i]);
            }

            return result;
        }
    }
}
