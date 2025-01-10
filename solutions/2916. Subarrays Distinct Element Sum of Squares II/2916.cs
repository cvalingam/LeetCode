public class Solution
{
    public int SumCounts(int[] nums)
    {
        const int kMod = 1_000_000_007;
        int n = nums.Length;
        int ans = 0;
        var lastSeen = new Dictionary<int, int>();
        var tree = new SegmentTree(n, kMod);

        for (int r = 0; r < n; ++r)
        {
            int l = lastSeen.ContainsKey(nums[r]) ? lastSeen[nums[r]] + 1 : 0;
            tree.UpdateRange(l, r);
            lastSeen[nums[r]] = r;
            ans = (ans + tree.GetTreeSquaredSums()) % kMod;
        }

        return ans;
    }
}

public class SegmentTree
{
    private readonly int kMod;
    private readonly int n;
    private readonly long[] lazy;
    private readonly long[] sums;
    private readonly long[] squaredSums;

    public SegmentTree(int n, int kMod)
    {
        this.n = n;
        this.kMod = kMod;
        lazy = new long[4 * n];
        sums = new long[4 * n];
        squaredSums = new long[4 * n];
    }

    public void UpdateRange(int l, int r)
    {
        UpdateRange(0, 0, n - 1, l, r);
    }

    private void Propagate(int i, int l, int r)
    {
        int gap = r - l + 1;
        squaredSums[i] += 2 * lazy[i] * sums[i] + lazy[i] * lazy[i] * gap;
        squaredSums[i] %= kMod;
        sums[i] += lazy[i] * gap;
        sums[i] %= kMod;
        if (l < r)
        {
            lazy[i * 2 + 1] += lazy[i];
            lazy[i * 2 + 2] += lazy[i];
        }
        lazy[i] = 0;
    }

    public int GetTreeSquaredSums()
    {
        return (int)squaredSums[0];
    }

    private void UpdateRange(int i, int start, int end, int l, int r)
    {
        if (lazy[i] > 0)
            Propagate(i, start, end);
        if (end < l || start > r)
            return;
        if (start >= l && end <= r)
        {
            lazy[i] = 1;
            Propagate(i, start, end);
            return;
        }
        int mid = (start + end) / 2;
        UpdateRange(i * 2 + 1, start, mid, l, r);
        UpdateRange(i * 2 + 2, mid + 1, end, l, r);
        sums[i] = (sums[i * 2 + 1] + sums[i * 2 + 2]) % kMod;
        squaredSums[i] = (squaredSums[i * 2 + 1] + squaredSums[i * 2 + 2]) % kMod;
    }
}