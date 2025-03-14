public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        long l = 1;
        long sum = 0;
        foreach (int val in candies)
            sum += val;
        long r = sum / k;

        while (l < r)
        {
            long m = (l + r) / 2;
            if (NumChildren(candies, m) < k)
                r = m;
            else
                l = m + 1;
        }

        return NumChildren(candies, l) >= k ? (int)l : (int)l - 1;
    }

    private long NumChildren(int[] candies, long m)
    {
        long sum = 0;
        foreach (int c in candies)
            sum = sum + (c / m);
        return sum;
    }
}