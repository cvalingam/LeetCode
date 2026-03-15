public class Fancy
{
    // To undo a * val + b and get the original value, we append (val - b) / a.
    // By Fermat's little theorem:
    //   a^(p - 1) ≡ 1 (mod p)
    //   a^(p - 2) ≡ a^(-1) (mod p)
    // So, (val - b) / a ≡ (val - b) * a^(p - 2) (mod p)
    public void Append(int val)
    {
        long x = (val - b + MOD) % MOD;
        vals.Add(x * ModPow(a, MOD - 2) % MOD);
    }

    // If the value is a * val + b, then the value after adding by `inc` will be
    // a * val + b + inc. So, we adjust b to b + inc.
    public void AddAll(int inc)
    {
        b = (b + inc) % MOD;
    }

    // If the value is a * val + b, then the value after multiplying by `m` will
    // be a * m * val + b * m. So, we adjust a to a * m and b to b * m.
    public void MultAll(int m)
    {
        a = (a * m) % MOD;
        b = (b * m) % MOD;
    }

    public int GetIndex(int idx)
    {
        return idx >= vals.Count ? -1 : (int)((a * vals[idx] + b) % MOD);
    }

    private const int MOD = 1_000_000_007;
    // For each `val` in `vals`, it actually represents a * val + b.
    private List<long> vals = new List<long>();
    private long a = 1;
    private long b = 0;

    private long ModPow(long x, long n)
    {
        if (n == 0)
            return 1;
        if (n % 2 == 1)
            return (x * ModPow(x % MOD, n - 1)) % MOD;
        long half = ModPow((x * x) % MOD, n / 2);
        return half % MOD;
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.Append(val);
 * obj.AddAll(inc);
 * obj.MultAll(m);
 * int param_4 = obj.GetIndex(idx);
 */