public class Solution
{
    public long MaximumProfit(int[] prices, int k)
    {
        int n = prices.Length;
        long[] prev = new long[n];
        long[] curr = new long[n];
        for (int t = 1; t <= k; t++)
        {
            long bestLong = -prices[0];
            long bestShort = prices[0];
            curr[0] = 0;
            for (int i = 1; i < n; i++)
            {
                long res = curr[i - 1];
                res = Math.Max(res, prices[i] + bestLong);
                res = Math.Max(res, -prices[i] + bestShort);
                curr[i] = res;
                bestLong = Math.Max(bestLong, prev[i - 1] - prices[i]);
                bestShort = Math.Max(bestShort, prev[i - 1] + prices[i]);
            }
            
            var tmp = prev;
            prev = curr;
            curr = tmp;
        }

        return prev[n - 1];
    }
}