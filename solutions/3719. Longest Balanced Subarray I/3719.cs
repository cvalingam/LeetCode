public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; ++i)
        {
            HashSet<int> vis = new HashSet<int>();
            int[] cnt = new int[2];
            for (int j = i; j < n; ++j)
            {
                if (vis.Add(nums[j]))
                    ++cnt[nums[j] & 1];
                if (cnt[0] == cnt[1])
                    ans = Math.Max(ans, j - i + 1);
            }
        }
        
        return ans;
    }
}