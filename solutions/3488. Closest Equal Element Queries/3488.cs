// Approach: Precompute the minimum circular distance to the nearest equal element for every index.
// Traverse the array twice (2n steps) using i % n to simulate the circular wrap-around.
// Track the last-seen index for each value in a dictionary.
// When a value reappears, compute the circular distance min(fwd, n-fwd) and update minDist
// for both the current and last-seen occurrence.
// Answer each query in O(1) from the precomputed array; return -1 if no equal neighbour exists.
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