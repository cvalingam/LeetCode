public class Solution
{
    int mod = 1000000007;
    public int CountGoodNumbers(long n)
    {
        long countOfFour = (n / 2);
        long countOfFive = (n / 2) + (n % 2);
        return (int)(GoodNumbersCount(5, countOfFive) % mod * GoodNumbersCount(4, countOfFour) % mod) % mod;
    }

    private long GoodNumbersCount(long i, long n)
    {
        if (n == 0)
            return 1;

        if (n % 2 == 0)
            return GoodNumbersCount((i % mod * i % mod) % mod, n / 2);
        else
            return (i % mod * GoodNumbersCount(i % mod, n - 1) % mod) % mod;
    }
}