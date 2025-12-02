public class Solution
{
    public int CountTrapezoids(int[][] points)
    {
        const int MOD = 1000000007;
        var cnt = new Dictionary<int, int>();
        foreach (var point in points)
        {
            int y = point[1];
            if (!cnt.ContainsKey(y))
                cnt[y] = 0;
            cnt[y]++;
        }

        long result = 0, total = 0;
        foreach (var c in cnt.Values)
        {
            long curr = ((long)c * (c - 1) / 2) % MOD;
            result = (result + (total * curr) % MOD) % MOD;
            total = (total + curr) % MOD;
        }

        return (int)result;
    }
}