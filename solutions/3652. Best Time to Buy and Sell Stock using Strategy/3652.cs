// Approach: Prefix sums. Compute prefix sums of prices and strategy*price products.
// The base profit is sum(prices[i]*strategy[i]). For each window of size k, try swapping
// to the actual prices and maximize using the prefix difference arrays.
// Time: O(n) Space: O(n)
public class Solution
{
    public long MaxProfit(int[] prices, int[] strategy, int k)
    {
        int n = prices.Length;
        long[] profitSum = new long[n + 1];
        long[] priceSum = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            profitSum[i + 1] = profitSum[i] + (long)prices[i] * strategy[i];
            priceSum[i + 1] = priceSum[i] + prices[i];
        }

        long res = profitSum[n];
        for (int i = k - 1; i < n; i++)
        {
            long leftProfit = profitSum[i - k + 1];
            long rightProfit = profitSum[n] - profitSum[i + 1];
            long changeProfit = priceSum[i + 1] - priceSum[i - k / 2 + 1];
            res = Math.Max(res, leftProfit + changeProfit + rightProfit);
        }
        
        return res;
    }
}