public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int n = prices.Length;
        // int[][] dp = new int[n][];
        // for(int i = 0; i < n; i++)
        // {
        //     int[] arr = new int[2];
        //     Array.Fill(arr, -1);
        //     dp[i] = arr;
        // }

        // return topDown(0, 1, prices, dp);
        return tabulation(n, prices);
    }

    private int topDown(int ind, int canBuy, int[] prices, int[][] dp)
    {
        if (ind >= prices.Length)
            return 0;

        if (dp[ind][canBuy] != -1)
            return dp[ind][canBuy];

        int profit = 0;
        if (canBuy == 1)
        {
            int bought = -prices[ind] + topDown(ind + 1, 0, prices, dp);
            int notBought = topDown(ind + 1, 1, prices, dp);
            profit = Math.Max(bought, notBought);
        }
        else
        {
            int sold = prices[ind] + topDown(ind + 2, 1, prices, dp);
            int notSold = topDown(ind + 1, 0, prices, dp);
            profit = Math.Max(sold, notSold);
        }

        return dp[ind][canBuy] = profit;
    }

    private int tabulation(int n, int[] prices)
    {
        int[][] dp = new int[n + 2][];
        for (int i = 0; i <= n + 1; i++)
        {
            int[] arr = new int[2];
            dp[i] = arr;
        }

        for (int ind = n - 1; ind >= 0; ind--)
        {
            for (int canBuy = 0; canBuy <= 1; canBuy++)
            {
                int profit = 0;
                if (canBuy == 1)
                {
                    int bought = -prices[ind] + dp[ind + 1][0];
                    int notBought = dp[ind + 1][1];
                    profit = Math.Max(bought, notBought);
                }
                else
                {
                    int sold = prices[ind] + dp[ind + 2][1];
                    int notSold = dp[ind + 1][0];
                    profit = Math.Max(sold, notSold);
                }
                dp[ind][canBuy] = profit;
            }
        }

        return dp[0][1];
    }
}