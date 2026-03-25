// Approach: Sliding window; shrink left while subarray still contains all distinct elements.
// Time: O(n) Space: O(n)

public class Solution
{
    public int CountCompleteSubarrays(int[] nums)
    {
        const int MAX = 2000;
        int totalDistinct = nums.Distinct().Count();
        int ans = 0;
        int distinct = 0;
        int[] count = new int[MAX + 1];

        int l = 0;
        foreach (int num in nums)
        {
            if (++count[num] == 1)
                ++distinct;
                
            while (distinct == totalDistinct)
            {
                if (--count[nums[l++]] == 0)
                    --distinct;
            }

            ans += l;
        }

        return ans;
    }
}