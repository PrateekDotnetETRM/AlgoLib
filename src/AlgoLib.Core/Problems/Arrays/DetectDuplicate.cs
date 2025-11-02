using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public static class DetectDuplicate
    {
        /// <summary>       
        /// Detect if array contains any duplicate data (In this case int[])    
        /// HashSet will work best for performance , Dictionary will have slight lower performance but still very good .
        /// for best performace presize set,dict before using 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static bool HasDuplicate(int[] nums)
        {

            if (nums == null || nums.Length < 2)
                return false;

            HashSet<int> set = new(nums.Length);


            foreach (int i in nums)
            {
                if (set.Contains(i))
                {
                    return true;
                }
                else
                {
                    set.Add(i);
                }
            }
            return false;
        }

        public static bool HasDuplicateWithDictionary(int[] nums)
        {
            Dictionary<int,bool> dict = [];

            foreach (int i in nums)
            {
                if (dict.TryGetValue(i, out bool result))
                {
                    return result;
                }
                else
                {
                    dict.Add(i,true);
                }
            }
            return false;
        }


        public static bool HasDuplicateParallel(int[] nums)
        {
            return nums.AsParallel().GroupBy(x => x).Any(g => g.Count() > 1);
        }

        public static bool HasDuplicateBruteForce(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return false;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                        return true;
                }
            }

            return false;
        }

    }
}
