public class Solution
{
    public bool PrimeSubOperation(int[] nums)
    {
        const int kMax = 1000;
        var primes = SieveEratosthenes(kMax);

        int prevNum = 0;
        for (int k = 0; k < nums.Length; k++)
        {
            int num = nums[k];
            // Make nums[i] the smallest as possible and still > nums[i - 1].
            int i = FirstGreaterEqual(primes, num - prevNum);
            if (i > 0)
                num -= primes[i - 1];

            if (num <= prevNum)
                return false;
                
            prevNum = num;
            nums[k] = num;
        }

        return true;
    }

    private List<int> SieveEratosthenes(int n)
    {
        var primes = new List<int>();
        var isPrime = new bool[n];
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

        for (int i = 2; i < n; ++i)
        {
            if (isPrime[i])
                primes.Add(i);
        }
        return primes;
    }

    private int FirstGreaterEqual(List<int> A, int target)
    {
        int i = A.BinarySearch(target);
        return i < 0 ? -i - 1 : i;
    }
}