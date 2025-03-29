public class Solution
{
    public int MaximumScore(IList<int> nums, int k)
    {
        const int MOD = 1_000_000_007;
        int n = nums.Count;
        int mx = nums.Max();
        int[] minPrimeFactors = SieveEratosthenes(mx + 1);
        int[] primeScores = GetPrimeScores(nums, minPrimeFactors);
        int ans = 1;

        int[] left = Enumerable.Repeat(-1, n).ToArray();
        int[] right = Enumerable.Repeat(n, n).ToArray();
        Stack<int> stack = new Stack<int>();

        for (int i = n - 1; i >= 0; --i)
        {
            while (stack.Count > 0 && primeScores[stack.Peek()] <= primeScores[i])
                left[stack.Pop()] = i;
            stack.Push(i);
        }

        stack.Clear();

        for (int i = 0; i < n; ++i)
        {
            while (stack.Count > 0 && primeScores[stack.Peek()] < primeScores[i])
                right[stack.Pop()] = i;
            stack.Push(i);
        }

        var numAndIndexes = new (int, int)[n];

        for (int i = 0; i < n; ++i)
            numAndIndexes[i] = (nums[i], i);

        Array.Sort(numAndIndexes, Comparer<(int, int)>.Create((a, b) =>
        {
            int cmp = b.Item1.CompareTo(a.Item1);
            return cmp != 0 ? cmp : a.Item2.CompareTo(b.Item2);
        }));

        foreach (var (num, i) in numAndIndexes)
        {
            long rangeCount = (long)(i - left[i]) * (right[i] - i);
            long actualCount = Math.Min(rangeCount, (long)k);
            k -= (int)actualCount;
            ans = (int)((1L * ans * ModPow(num, actualCount, MOD)) % MOD);
        }

        return ans;
    }

    private long ModPow(long x, long n, int mod)
    {
        if (n == 0)
            return 1;
            
        if (n % 2 == 1)
            return x * ModPow(x, n - 1, mod) % mod;

        return ModPow(x * x % mod, n / 2, mod);
    }

    private int[] SieveEratosthenes(int n)
    {
        int[] minPrimeFactors = new int[n + 1];
        for (int i = 2; i <= n; ++i)
            minPrimeFactors[i] = i;
        for (int i = 2; i * i < n; ++i)
        {
            if (minPrimeFactors[i] == i)
            {
                for (int j = i * i; j < n; j += i)
                    minPrimeFactors[j] = Math.Min(minPrimeFactors[j], i);
            }
        }

        return minPrimeFactors;
    }

    private int[] GetPrimeScores(IList<int> nums, int[] minPrimeFactors)
    {
        int[] primeScores = new int[nums.Count];
        for (int i = 0; i < nums.Count; ++i)
            primeScores[i] = GetPrimeScore(nums[i], minPrimeFactors);

        return primeScores;
    }

    private int GetPrimeScore(int num, int[] minPrimeFactors)
    {
        HashSet<int> primeFactors = new HashSet<int>();
        while (num > 1)
        {
            int divisor = minPrimeFactors[num];
            primeFactors.Add(divisor);
            while (num % divisor == 0)
                num /= divisor;
        }
        return primeFactors.Count;
    }
}