// Approach: Group all indices of each value into a dictionary. For each value with ≥ 3
// occurrences, slide a window of 3 consecutive indices and compute 2*(last - first) as
// the cost (middle element is free to move to any position between them).
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