// Approach: Precompute all prime factors for every number up to 1e6 with a linear sieve.
// Build an adjacency map: prime → list of indices whose value has that prime factor.
// BFS from index 0; at each step expand to i-1, i+1, and all indices sharing a prime factor with nums[i].
// Clear each prime's index list after expansion to avoid re-visiting the same group.
// Time: O(N log log N) Space: O(N + max_val)

public class Solution
{
    private const int mx = 1000001;
    private static readonly List<int>[] factors = new List<int>[mx];

    static Solution()
    {
        for (int i = 0; i < mx; i++)
            factors[i] = new List<int>();

        for (int i = 2; i < mx; i++)
        {
            if (factors[i].Count == 0)
            {
                for (int j = i; j < mx; j += i)
                    factors[j].Add(i);
            }
        }
    }

    public int MinJumps(int[] nums)
    {
        int n = nums.Length;
        var g = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            foreach (int p in factors[x])
            {
                if (!g.ContainsKey(p))
                    g[p] = new List<int>();
                g[p].Add(i);
            }
        }

        int ans = 0;
        bool[] vis = new bool[n];
        vis[0] = true;
        var q = new Queue<int>();
        q.Enqueue(0);
        while (true)
        {
            var nq = new Queue<int>();
            while (q.Count > 0)
            {
                int i = q.Dequeue();
                if (i == n - 1)
                    return ans;

                List<int> idx;
                if (!g.TryGetValue(nums[i], out idx))
                    idx = new List<int>();

                idx.Add(i + 1);
                if (i > 0)
                    idx.Add(i - 1);

                foreach (int j in idx)
                {
                    if (j >= 0 && j < n && !vis[j])
                    {
                        vis[j] = true;
                        nq.Enqueue(j);
                    }
                }
                idx.Clear();
            }
            q = nq;
            ans++;
        }
    }
}