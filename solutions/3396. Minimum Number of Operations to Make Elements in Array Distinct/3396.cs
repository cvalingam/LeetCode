// Approach: Scan from right in groups of 3; stop when first duplicate encountered; ops = ceil remaining.
// Time: O(n) Space: O(n)

public class Solution
{
    public int MinimumOperations(int[] nums)
    {
        var set = new HashSet<int>();
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            if (!set.Add(nums[i]))
                return (i + 1 + 2) / 3;
        }

        return 0;
    }
}