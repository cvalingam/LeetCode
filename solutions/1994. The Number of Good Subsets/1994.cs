public class Solution
{
    public int NumberOfGoodSubsets(int[] nums)
    {
        int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };
        int n = 1 << primes.Length;
        int maxNum = nums.Max();
        long[] dp = new long[n];
        int[] count = new int[maxNum + 1];

        dp[0] = 1;

        foreach (int num in nums)
            ++count[num];

        for (int num = 2; num <= maxNum; ++num)
        {
            if (count[num] == 0)
                continue;
            if (num % 4 == 0 || num % 9 == 0 || num % 25 == 0)
                continue;
            int numPrimesMask = GetPrimesMask(num, primes);
            for (int primesMask = 0; primesMask < n; ++primesMask)
            {
                if ((primesMask & numPrimesMask) > 0)
                    continue;
                int nextPrimesMask = primesMask | numPrimesMask;
                dp[nextPrimesMask] += dp[primesMask] * count[num];
                dp[nextPrimesMask] %= kMod;
            }
        }

        return (int)((ModPow(2, count[1]) * ((dp.Sum() - 1) % kMod)) % kMod);
    }

    const int kMod = 1_000_000_007;

    private int GetPrimesMask(int num, int[] primes)
    {
        int primesMask = 0;
        for (int i = 0; i < primes.Length; ++i)
            if (num % primes[i] == 0)
                primesMask |= 1 << i;
        return primesMask;
    }

    private long ModPow(long x, long n)
    {
        if (n == 0)
            return 1;
        if (n % 2 == 1)
            return x * ModPow(x, n - 1) % kMod;
        return ModPow(x * x % kMod, n / 2);
    }
}