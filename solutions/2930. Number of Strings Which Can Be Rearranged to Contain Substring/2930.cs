public class Solution
{
    public int StringCount(int n)
    {
        // There're three invalid conditions:
        //   a. count('l') == 0
        //   b. count('e') < 2
        //   c. count('t') == 0
        //
        // By Principle of Inclusion-Exclusion (PIE):
        //   ans = allCount - a - b - c + ab + ac + bc - abc
        const long kMod = 1_000_000_007;
        long allCount = ModPow(26, n, kMod);
        long a = ModPow(25, n, kMod);
        long b = ModPow(25, n, kMod);
        long c = ModPow(25, n, kMod) + n * ModPow(25, n - 1, kMod) % kMod;
        long ab = ModPow(24, n, kMod) + n * ModPow(24, n - 1, kMod) % kMod;
        long ac = ModPow(24, n, kMod);
        long bc = ModPow(24, n, kMod) + n * ModPow(24, n - 1, kMod) % kMod;
        long abc = ModPow(23, n, kMod) + n * ModPow(23, n - 1, kMod) % kMod;
        return (int)((((allCount - a - b - c + ab + ac + bc - abc) % kMod) + kMod) % kMod);
    }

    private long ModPow(long x, long n, long mod)
    {
        if (n == 0)
            return 1;
        if (n % 2 == 1)
            return x * ModPow(x, n - 1, mod) % mod;
        return ModPow(x * x % mod, n / 2, mod);
    }
}