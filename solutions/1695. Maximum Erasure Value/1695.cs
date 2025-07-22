public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int[] lastIndex = new int[10001]; // Array to store the last index of each number
        int length = nums.Length; // Length of nums
        int[] prefixSum = new int[length + 1]; // Array to store prefix sum

        // Calculate prefix sum array
        for (int i = 0; i < length; ++i)
            prefixSum[i + 1] = prefixSum[i] + nums[i];


        int maxSum = 0; // Initialize the maximum sum of a unique subarray
        int windowStart = 0; // Initialize the start of the current window

        // Iterate over the nums array
        for (int i = 1; i <= length; ++i)
        {
            int value = nums[i - 1]; // Current value
            windowStart = Math.Max(windowStart, lastIndex[value]); // Update the start of the window to be after the last occurrence of value
            // Calculate the current sum of unique subarray and compare it with the maximum sum found so far
            maxSum = Math.Max(maxSum, prefixSum[i] - prefixSum[windowStart]);
            lastIndex[value] = i; // Update the last index of the current value
        }

        return maxSum; // Return the maximum sum of a unique subarray
    }
}