public class Solution
{
    public long MinOperations(int[][] queries)
    {
        long ans = 0;
        foreach (var query in queries)
        {
            int l = query[0];
            int r = query[1];
            ans += (GetOperations(r) - GetOperations(l - 1) + 1) / 2;
        }
        return ans;
    }

    // Returns the number of operations required for [1, n].
    private long GetOperations(int n)
    {
        long res = 0;
        int ops = 0;
        for (int powerOfFour = 1; powerOfFour <= n; powerOfFour *= 4)
        {
            int l = powerOfFour;
            int r = Math.Min(n, powerOfFour * 4 - 1);
            res += (long)(r - l + 1) * ++ops;
        }
        return res;
    }
}