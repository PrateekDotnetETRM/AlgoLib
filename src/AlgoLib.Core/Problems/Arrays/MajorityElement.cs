using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// Easy : The majority element is the element that appears more than ⌊n / 2⌋ times in the array. You may assume that the majority element always exists in the array.
    /// 
    /// </summary>
    public static class MajorityElement
    {
        public static int FindMajorityElementLinq(int[] nums)
        {
            return nums.GroupBy(x => x).OrderByDescending(x => x.Count()).Select(x => x.Key).First();
        }


        public static int FindMajorityElementDictionary(int[] nums)
        {
            Dictionary<int, int> counter = new();
            var (key, max) = (0, 0);
            foreach (int num in nums)
            {
                var res = counter.GetValueOrDefault(num, 0) + 1;
                counter[num] = res;
                if (res > max)
                {
                    key = num;
                    max = res;
                }
            }
            return key;
        }

        /// <summary>
        /// Only works for one value is in array more than n/2 times.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int FindMajorityElement(int[] nums)
        {
            var (key, max) = (nums[0], 1);
            for (int i = 1; i < nums.Length; i++)
            {
                var num = nums[i];
                if (max == 0)
                {
                    key = num;
                }
                if (num == key)
                {
                    max++;
                }
                else
                {
                    max--;
                }
            }
            return key;
        }
    }
}
