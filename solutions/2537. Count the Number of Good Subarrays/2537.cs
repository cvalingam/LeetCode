public class Solution
{
    public long CountGood(int[] nums, int k)
    {
        long ans = 0;
        int pairs = 0;
        Dictionary<int, int> count = new Dictionary<int, int>();

        for (int l = 0, r = 0; r < nums.Length; ++r)
        {
            // Since there're count[r] nums[r]s, including nums[r] to the window will
            // increase the number of good subarrays by count[r].
            if (count.ContainsKey(nums[r]))
            {
                pairs += count[nums[r]];
                count[nums[r]]++;
            }
            else
                count[nums[r]] = 1;

            while (pairs >= k)
            {
                pairs -= --count[nums[l]];
                if (count[nums[l]] == 0)
                    count.Remove(nums[l]);
                l++;
            }
            // nums[0..r], nums[1..r], ..., nums[l - 1..r] are good subarrays, so add
            // l to `ans`.
            ans += l;
        }

        return ans;
    }
}