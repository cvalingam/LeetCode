public class Solution
{
    public int NumSubseq(int[] nums, int target)
    {
        // Sort the input array to facilitate the two-pointer approach
        Array.Sort(nums);

        // Modulus value for avoiding integer overflow
        const int MOD = (int)1e9 + 7;

        // Get the length of the nums array
        int n = nums.Length;

        // Create an array to store powers of 2 mod MOD, up to n
        int[] powersOfTwoMod = new int[n + 1];
        powersOfTwoMod[0] = 1;

        // Precompute the powers of two modulo MOD for later use
        for (int i = 1; i <= n; ++i)
            powersOfTwoMod[i] = (int)((long)powersOfTwoMod[i - 1] * 2 % MOD);

        // Variable to store the final answer
        int answer = 0;

        // Iterate through the numbers in the sorted array
        for (int i = 0; i < n; ++i)
        {
            // If the smallest number in the subsequence is greater than half of the target, stop the loop
            if (nums[i] * 2L > target)
                break;

            // Find the largest index j such that nums[i] + nums[j] <= target
            int j = BinarySearch(nums, target - nums[i], i + 1) - 1;

            // Add the count of subsequences using the powers of two precomputed values
            answer = (answer + powersOfTwoMod[j - i]) % MOD;
        }

        // Return the total number of subsequences that satisfy the condition
        return answer;
    }

    // Helper function: binary search to find the rightmost index where nums[index] <= x
    private int BinarySearch(int[] nums, int x, int left)
    {
        int right = nums.Length;

        // Continue searching while the search space is valid
        while (left < right)
        {
            int mid = (left + right) >> 1; // Calculate the middle index

            // Narrow the search to the left half if nums[mid] > x
            if (nums[mid] > x)
                right = mid;
            else
                // Otherwise, narrow the search to the right half
                left = mid + 1;
        }

        // Return the insertion point for x
        return left;
    }
}