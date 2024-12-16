public class Solution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        List<long>[] sizeToLcms = GetSizeToLcms(coins);
        long l = 0;
        long r = (long)k * coins.Min();

        while (l < r)
        {
            long m = (l + r) / 2;
            if (NumDenominationsNoGreaterThan(sizeToLcms, m) >= k)
                r = m;
            else
                l = m + 1;
        }

        return l;
    }

    // Returns the number of denominations <= m.
    private long NumDenominationsNoGreaterThan(List<long>[] sizeToLcms, long m)
    {
        long res = 0;
        for (int sz = 1; sz < sizeToLcms.Length; ++sz)
            foreach (long lcm in sizeToLcms[sz])
                res += m / lcm * (long)Math.Pow(-1, sz + 1);
        return res;
    }

    // Returns the LCMs for each number of combination of coins.
    private List<long>[] GetSizeToLcms(int[] coins)
    {
        int n = coins.Length;
        int maxMask = 1 << n;
        List<long>[] sizeToLcms = new List<long>[n + 1];

        for (int i = 1; i <= n; ++i)
            sizeToLcms[i] = new List<long>();

        for (int mask = 1; mask < maxMask; ++mask)
        {
            long lcmOfSelectedCoins = 1;
            for (int i = 0; i < n; ++i)
                if ((mask >> i & 1) == 1)
                    lcmOfSelectedCoins = Lcm(lcmOfSelectedCoins, coins[i]);
            sizeToLcms[CountBits(mask)].Add(lcmOfSelectedCoins);
        }

        return sizeToLcms;
    }

    private long Lcm(long a, long b)
    {
        return a * b / Gcd(a, b);
    }

    private long Gcd(long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    private int CountBits(int mask)
    {
        int count = 0;
        while (mask > 0)
        {
            count += mask & 1;
            mask >>= 1;
        }
        return count;
    }
}