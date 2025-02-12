public class Solution
{
    public int MergeStones(int[] stones, int K)
    {
        int n = stones.Length;
        var mem = new int[n, n, K + 1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                for (int k = 0; k <= K; k++)
                    mem[i, j, k] = kMax;
            }
        }

        var prefix = new int[n + 1];
        for (int i = 0; i < n; i++)
            prefix[i + 1] = prefix[i] + stones[i];

        int cost = MergeStones(stones, 0, n - 1, 1, K, prefix, mem);
        return cost == kMax ? -1 : cost;
    }

    private const int kMax = 1_000_000_000;

    private int MergeStones(int[] stones, int i, int j, int k, int K, int[] prefix, int[,,] mem)
    {
        if ((j - i + 1 - k) % (K - 1) != 0)
            return kMax;
        if (i == j)
            return k == 1 ? 0 : kMax;
        if (mem[i, j, k] != kMax)
            return mem[i, j, k];
        if (k == 1)
            return mem[i, j, k] = MergeStones(stones, i, j, K, K, prefix, mem) + (prefix[j + 1] - prefix[i]);

        for (int m = i; m < j; m += K - 1)
        {
            mem[i, j, k] = Math.Min(mem[i, j, k],
                MergeStones(stones, i, m, 1, K, prefix, mem) +
                MergeStones(stones, m + 1, j, k - 1, K, prefix, mem));
        }

        return mem[i, j, k];
    }
}