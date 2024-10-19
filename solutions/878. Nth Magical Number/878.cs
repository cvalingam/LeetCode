public class Solution
{
    public int NthMagicalNumber(int n, int a, int b)
    {
        const int kMod = 1000000007;
        long lcm = a * b / Gcd(a, b);
        long l = Math.Min(a, b);
        long r = Math.Min(a, b) * (long)n;

        while (l < r)
        {
            long m = (l + r) / 2;
            if (m / a + m / b - m / lcm >= n)
                r = m;
            else
                l = m + 1;
        }

        return (int)(l % kMod);
    }

    private long Gcd(long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }
}