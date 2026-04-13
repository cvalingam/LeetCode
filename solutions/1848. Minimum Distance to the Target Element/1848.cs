// Approach: Scan the array once. Track the minimum distance from start to any occurrence
// of target by checking |i - start| for each matching element.
// Time: O(n) Space: O(1)
public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int ans = int.MaxValue;

        for (int i = 0; i < nums.Length; ++i)
        {
            if (nums[i] == target)
                ans = Math.Min(ans, Math.Abs(i - start));
        }

        return ans;
    }
}