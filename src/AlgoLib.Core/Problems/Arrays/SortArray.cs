using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public static class SortArray
    {

        #region Heap Sort
        /// <summary>
        /// Time complexity: O(n log⁡ n) in all cases
        /// Space complexity: O(1) (in-place)
        /// Not stable: Equal elements may not retain their original order
        /// 
        /// Heap sort has good theoretical guarantees: O(n log n) time complexity in all cases.
        /// However, in practice, it's rarely used as the default sorting algorithm in standard libraries (e.g., C++ STL, Java, Python) 
        /// because of performance and cache inefficiency.Heap sort relies on a binary heap structure, which involves frequent jumps in memory (especially in array-based implementations).
        /// This leads to cache misses, making it slower than algorithms like Quick Sort that access memory more sequentially.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortArrayHeapSort(int[] nums)
        {
            int n = nums.Length;

            //Build the heap from random array 
            for (int i = (n / 2) - 1; i >= 0; i -= 1)
            {
                Heapify(nums, n, i);
            }


            for (int i = n-1;i >= 0; i--)
            {
                Swap(nums, 0, i);
                Heapify(nums, i, 0);
            }

            return nums;
        }
        private static void Heapify(int[] nums, int heapSize, int rootIndex)
        {
            while (true)
            {
                int largest = rootIndex;
                int left = 2 * rootIndex + 1;
                int right = left + 1;

                if (left < heapSize && nums[left] > nums[largest])
                    largest = left;

                if (right < heapSize && nums[right] > nums[largest])
                    largest = right;

                if (largest == rootIndex)
                    break;

                Swap(nums, rootIndex, largest);
                rootIndex = largest;
            }
        }
        #endregion

        #region MergeSort
        /// <summary>
        /// Time complexity: O(n log⁡ n) in all cases
        /// Space complexity: O(n) (uses temp array during merge)
        /// stable: Equal elements retain their original order
        /// </summary>
        /// <param name="nums"></param>
        public static int[] SortArrayMergeSort(int[] nums)
        {
            MergeSort(nums, 0, nums.Length - 1);
            return nums;
        }

        private static void MergeSort(int[] nums, int left, int right)
        {
            if (left >= right) return;

            int mid = (left + right) / 2;

            MergeSort(nums, left, mid);
            MergeSort(nums, mid + 1, right);

            Merge(nums, left, mid, right);
        }

        private static void Merge(int[] nums, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (nums[i] <= nums[j])
                    temp[k++] = nums[i++];
                else
                    temp[k++] = nums[j++];
            }

            while (i <= mid) temp[k++] = nums[i++];
            while (j <= right) temp[k++] = nums[j++];

            for (int t = 0; t < temp.Length; t++)
                nums[left + t] = temp[t];
        }



        #endregion

        #region Hybrid Merge Sort with Span<T>

        /// <summary>
        /// Better in performance for small arrays
        /// Time complexity: O(n log⁡ n) in all cases
        /// Space complexity: O(n) (uses temp array during merge)
        /// stable: Equal elements retain their original order
        /// </summary>
        /// <param name="span"></param>
        public static int[] HybridMergeSort(Span<int> span)
        {
            const int INSERTION_SORT_THRESHOLD = 32; // Tunable threshold
            MergeSort(span, INSERTION_SORT_THRESHOLD);
            return span.ToArray();
        }

        private static void MergeSort(Span<int> span, int threshold)
        {
            if (span.Length <= threshold)
            {
                InsertionSort(span);
                return;
            }

            int mid = span.Length / 2;
            var left = span[..mid];
            var right = span[mid..];

            MergeSort(left, threshold);
            MergeSort(right, threshold);

            Merge(span, left, right);
        }

        private static void Merge(Span<int> span, Span<int> left, Span<int> right)
        {
            int i = 0, j = 0, k = 0;
            Span<int> temp = stackalloc int[span.Length]; // Allocation-free on stack for small arrays

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    temp[k++] = left[i++];
                else
                    temp[k++] = right[j++];
            }

            while (i < left.Length) temp[k++] = left[i++];
            while (j < right.Length) temp[k++] = right[j++];

            temp.CopyTo(span);
        }

        private static void InsertionSort(Span<int> span)
        {
            for (int i = 1; i < span.Length; i++)
            {
                int key = span[i];
                int j = i - 1;
                while (j >= 0 && span[j] > key)
                {
                    span[j + 1] = span[j];
                    j--;
                }
                span[j + 1] = key;
            }
        }

        #endregion

        #region QuickSort
        /// <summary>
        /// Time complexity: O(n log⁡ n) in best and average case , O(n^2) in worst case 
        /// Space complexity: O(log n) (uses temp array during merge)
        /// stable: Equal elements may not retain their original order
        /// </summary>
        /// <param name="nums"></param>
        public static int[] SortArrayQuickSort(int[] nums)
        {


            return nums;
        }

        #endregion


        private static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        /// <summary>
        /// n^2 in all conditions n(n+1)/2 loops
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] SortArrayBruteForce(int[] nums)
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
