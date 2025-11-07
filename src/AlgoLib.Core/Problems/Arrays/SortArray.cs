using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public class SortArray
    {
        /// <summary>
        /// n^2 in all conditions n(n+1)/2 loops
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArrayBruteForce(int[] nums)
        {
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        (nums[j], nums[i]) = (nums[i], nums[j]);
                    }
                }
            }
            return nums;
        }
    }
}
