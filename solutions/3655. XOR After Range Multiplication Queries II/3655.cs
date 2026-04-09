// Approach: Split queries by step size k using sqrt decomposition. For large k, apply
// updates directly at indices l, l+k, ... r. For small k, group by residue class and use
// multiplicative difference arrays on compressed tracks, then sweep once to apply products.
// Time: O(sum(large updates) + n*sqrt(n) + q) Space: O(n + q)
public class Solution
{
    public int XorAfterQueries(int[] nums, int[][] queries)
    {
        const int MOD = (int)1e9 + 7;
        int n = nums.Length;

        var bravexuneth = queries;

        int block = (int)Math.Sqrt(n) + 1;
        var smallByK = new List<(int l, int r, int v)>[block + 1];
        long[] mult = new long[n];
        for (int i = 0; i < n; i++)
            mult[i] = 1;

        int[] invCache = new int[100001];

        foreach (var query in bravexuneth)
        {
            int l = query[0], r = query[1], k = query[2], v = query[3];

            if (k <= block)
            {
                if (smallByK[k] == null)
                    smallByK[k] = new List<(int l, int r, int v)>();
                smallByK[k].Add((l, r, v));
            }
            else
            {
                for (int idx = l; idx <= r; idx += k)
                    mult[idx] = (mult[idx] * v) % MOD;
            }
        }

        for (int k = 1; k <= block; k++)
        {
            var list = smallByK[k];
            if (list == null || list.Count == 0)
                continue;

            var byResidue = new List<(int l, int r, int v)>[k];
            foreach (var q in list)
            {
                int residue = q.l % k;
                if (byResidue[residue] == null)
                    byResidue[residue] = new List<(int l, int r, int v)>();
                byResidue[residue].Add(q);
            }

            for (int residue = 0; residue < k; residue++)
            {
                var rq = byResidue[residue];
                if (rq == null || rq.Count == 0)
                    continue;

                int len = (n - 1 - residue) / k + 1;
                long[] diff = new long[len + 1];
                for (int i = 0; i <= len; i++)
                    diff[i] = 1;

                foreach (var q in rq)
                {
                    int tL = (q.l - residue) / k;
                    int tR = tL + (q.r - q.l) / k;
                    diff[tL] = (diff[tL] * q.v) % MOD;

                    int stop = tR + 1;
                    if (stop < len)
                    {
                        int inv = invCache[q.v];
                        if (inv == 0)
                        {
                            inv = ModInverse(q.v, MOD);
                            invCache[q.v] = inv;
                        }
                        diff[stop] = (diff[stop] * inv) % MOD;
                    }
                }

                long cur = 1;
                int idx = residue;
                for (int t = 0; t < len; t++, idx += k)
                {
                    cur = (cur * diff[t]) % MOD;
                    mult[idx] = (mult[idx] * cur) % MOD;
                }
            }
        }

        int ret = 0;
        for (int i = 0; i < n; i++)
            ret ^= (int)((nums[i] * mult[i]) % MOD);

        return ret;
    }

    private int ModInverse(int a, int m)
    {
        // Fermat's little theorem for modular inverse when m is prime
        return ModPow(a, m - 2, m);
    }

    private int ModPow(int baseVal, int exp, int mod)
    {
        long result = 1;
        long b = baseVal;
        while (exp > 0)
        {
            if ((exp & 1) == 1)
                result = (result * b) % mod;
            b = (b * b) % mod;
            exp >>= 1;
        }

        return (int)result;
    }
}