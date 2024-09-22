public class Solution
{
    public int FindKthNumber(int n, int k)
    {
        k--;
        long curr = 1;
        while (k > 0)
        {
            long count = CountNodes(curr, n);
            if (k >= count)
            {
                curr++;
                k -= (int)count;
            }
            else
            {
                curr *= 10;
                k--;
            }
        }

        return (int)curr;
    }

    private long CountNodes(long curr, int n)
    {
        long next = curr + 1;
        long result = 0;
        while (curr <= n)
        {
            result += Math.Min(n - curr + 1, next - curr);
            curr *= 10;
            next *= 10;
        }

        return result;
    }
}