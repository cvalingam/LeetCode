public class Solution
{
    public int MaximumCount(int[] nums)
    {
        // Find the number of 1's by subtracting the index of the first 1 from the array length
        int countOfOnes = nums.Length - FirstOccurrence(nums, 1);
        // Find the first occurrence index of 0, which is also the count of 0's
        int countOfZeros = FirstOccurrence(nums, 0);
        // Return the max count between 0's and 1's
        return Math.Max(countOfOnes, countOfZeros);
    }

    // Helper method to find the first occurrence index of 'x' in the sorted array 'nums'
    private int FirstOccurrence(int[] nums, int x)
    {
        int left = 0;
        int right = nums.Length;
        // Binary search to find the first occurrence of 'x'
        while (left < right)
        {
            int mid = (left + right) >> 1; // Equivalent to (left + right) / 2 but faster
            // If mid element is greater than or equal to x, we move the right boundary
            if (nums[mid] >= x)
            {
                right = mid;
            }
            else
            {
                // If mid element is less than x, we move the left boundary
                left = mid + 1;
            }
        }
        // 'left' will point to the first occurrence of 'x' or nums.Length if 'x' is not found
        return left;
    }
}