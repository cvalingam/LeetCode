// Approach: Group indices by value. For each value, check every 3-consecutive occurrence
// window (idx[h], idx[h+2]); the minimum movement is 2 * (idx[h+2] - idx[h]). Take the
// minimum across all values.
// Time: O(n) Space: O(n)
public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; ++i)
        {
            if (!g.ContainsKey(nums[i]))
            {
                g[nums[i]] = new List<int>();
            }
            g[nums[i]].Add(i);
        }
        const int inf = 1 << 30;
        int ans = inf;
        foreach (var ls in g.Values)
        {
            int m = ls.Count;
            for (int h = 0; h < m - 2; ++h)
            {
                int i = ls[h];
                int k = ls[h + 2];
                int t = (k - i) * 2;
                ans = Math.Min(ans, t);
            }
        }
        
        return ans == inf ? -1 : ans;
    }
}