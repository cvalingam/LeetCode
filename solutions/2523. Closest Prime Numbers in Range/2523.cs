public class Solution
{
    public int[] ClosestPrimes(int left, int right)
    {
        bool[] isPrime = SieveEratosthenes(right + 1);
        List<int> primes = new List<int>();

        for (int i = left; i <= right; ++i)
        {
            if (isPrime[i])
                primes.Add(i);
        }

        if (primes.Count < 2)
            return new int[] { -1, -1 };

        int minDiff = int.MaxValue;
        int num1 = -1;
        int num2 = -1;

        for (int i = 1; i < primes.Count; ++i)
        {
            int diff = primes[i] - primes[i - 1];
            if (diff < minDiff)
            {
                minDiff = diff;
                num1 = primes[i - 1];
                num2 = primes[i];
            }
        }

        return new int[] { num1, num2 };
    }

    private bool[] SieveEratosthenes(int n)
    {
        bool[] isPrime = new bool[n];
        Array.Fill(isPrime, true);
        isPrime[0] = false;
        isPrime[1] = false;
        for (int i = 2; i * i < n; ++i)
        {
            if (isPrime[i])
            {
                for (int j = i * i; j < n; j += i)
                    isPrime[j] = false;
            }
        }
        return isPrime;
    }
}