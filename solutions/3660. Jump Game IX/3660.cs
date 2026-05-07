// Approach: Build a prefix-max array, then sweep right-to-left maintaining a suffix minimum.
// At each position, if the prefix max exceeds the suffix min, the optimal value propagates from result[i+1];
// otherwise the best value is capped at the prefix max seen so far.
// Time: O(n) Space: O(n)

public class Solution
{
    public int[] MaxValue(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        // Build prefix maximum array
        // prefixMax[i] stores the maximum value from nums[0] to nums[i]
        int[] prefixMax = new int[n];
        prefixMax[0] = nums[0];
        for (int i = 1; i < n; i++)
            prefixMax[i] = Math.Max(prefixMax[i - 1], nums[i]);

        // Initialize suffix minimum with a large value (approximately int.MaxValue)
        int suffixMin = 1 << 30;

        // Traverse from right to left to compute result
        // For each position, check if prefix maximum is greater than suffix minimum
        for (int i = n - 1; i >= 0; i--)
        {
            // If prefix max up to current position is greater than suffix min after current position,
            // use the next result value (or 0 for last element)
            // Otherwise, use the prefix max value
            if (prefixMax[i] > suffixMin)
                result[i] = (i + 1 < n) ? result[i + 1] : 0;
            else
                result[i] = prefixMax[i];

            // Update suffix minimum to include current element
            suffixMin = Math.Min(suffixMin, nums[i]);
        }

        return result;
    }
}