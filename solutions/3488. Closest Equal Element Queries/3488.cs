// Approach: Traverse the circular array twice while tracking the last seen position of each
// value. Whenever the same value reappears, update the minimum circular distance for both
// occurrences. Answer each query from the precomputed minimum-distance array.
// Time: O(n + q) Space: O(n)
public class Solution
{
    public IList<int> SolveQueries(int[] nums, int[] queries)
    {
        int n = nums.Length;
        List<int> ans = new List<int>();
        int[] minDist = new int[n];
        Array.Fill(minDist, n);
        Dictionary<int, int> lastSeen = new Dictionary<int, int>();

        for (int i = 0; i < n * 2; ++i)
        {
            int index = i % n;
            int num = nums[index];
            if (lastSeen.ContainsKey(num))
            {
                int prevIndex = lastSeen[num] % n;
                int d = i - prevIndex;
                minDist[index] = Math.Min(minDist[index], d);
                minDist[prevIndex] = Math.Min(minDist[prevIndex], d);
            }
            lastSeen[num] = i;
        }

        foreach (int query in queries)
            ans.Add(minDist[query] == n ? -1 : minDist[query]);

        return ans;
    }
}