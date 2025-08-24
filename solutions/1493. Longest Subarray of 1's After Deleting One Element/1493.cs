public class Solution
{
    // Function to find the length of the longest subarray consisting of 1s after deleting exactly one element.
    public int LongestSubarray(int[] nums)
    {
        int length = nums.Length;

        // Arrays to store the count of consecutive 1s to the left and right of each index in nums
        int[] leftOnesCount = new int[length];
        int[] rightOnesCount = new int[length];

        // Count consecutive 1s from left to right, starting from the second element
        for (int i = 1; i < length; ++i)
        {
            if (nums[i - 1] == 1)
                // If the previous element is 1, increment the count
                leftOnesCount[i] = leftOnesCount[i - 1] + 1;
        }

        // Count consecutive 1s from right to left, starting from the second-to-last element
        for (int i = length - 2; i >= 0; --i)
        {
            if (nums[i + 1] == 1)
                // If the next element is 1, increment the count
                rightOnesCount[i] = rightOnesCount[i + 1] + 1;
        }

        // Variable to store the answer, the maximum length of a subarray
        int maxSubarrayLength = 0;

        // Loop to find the maximum length by combining the left and right counts of 1s
        for (int i = 0; i < length; ++i)
            // Compute the length of subarray by removing the current element, hence adding left and right counts of 1s.
            // Since one element is always removed, the combined length of consecutive 1s from left and right
            // should not be equal to the total length of the array (which implies no 0 was in the array to begin with).
            maxSubarrayLength = Math.Max(maxSubarrayLength, leftOnesCount[i] + rightOnesCount[i]);

        // Reduce the length by 1 if the length of consecutive 1s equals the array length, since we need to remove one element.
        if (maxSubarrayLength == length)
            maxSubarrayLength--;

        // Return the maximum length of subarray after deletion
        return maxSubarrayLength;
    }
}