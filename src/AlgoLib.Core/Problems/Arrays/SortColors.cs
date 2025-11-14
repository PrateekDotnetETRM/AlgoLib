using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{

    public static class SortColors
    {
        /// <summary>
        /// Dutch National Flag problem (The task is to sort the array in-place such that elements of the same color are grouped together 
        /// and arranged in the order: red (0), white (1), and then blue (2))
        /// </summary>
        /// <param name="nums"></param>
        public static void SortDutchFlagColors(int[] nums)
        {
            int low = 0, mid = 0, high = nums.Length - 1;

            while (mid <= high)
            {
                if (nums[mid] == 0)
                {
                    (nums[low], nums[mid]) = (nums[mid], nums[low]);
                    low++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else
                { 
                    (nums[mid], nums[high]) = (nums[high], nums[mid]);
                    high--;
                }
            }
        }

        /// <summary>
        /// Simpler but more CPU cycle used here . Still O(n) but that doesn't make it equivalent in performance to Dutch national flag problem
        /// </summary>
        /// <param name="nums"></param>
        public static void SortDutchColorsTwoPass(int[] nums)
        {
            int n = nums.Length;
            int index = 0;

            // First pass: move all 0s to the front
            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    index++;
                }
            }

            // Second pass: move all 2s to the back
            for (int i = n - 1; i >= index; i--)
            {
                if (nums[i] == 2)
                {
                    (nums[i], nums[n - 1]) = (nums[n - 1], nums[i]);
                    n--;
                }
            }
        }
    }
}
