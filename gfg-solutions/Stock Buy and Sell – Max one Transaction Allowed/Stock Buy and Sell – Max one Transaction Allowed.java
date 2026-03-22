class Solution {
    public int maximumProfit(int prices[]) {
        int minSofar = prices[0];
        int maxDiff = 0;

        for (int i = 1; i < prices.length; i++) {
            if (prices[i] < minSofar) {
                minSofar = prices[i];
            }

            maxDiff = Math.max(maxDiff, prices[i] - minSofar);
        }

        return maxDiff;
    }
}

class Solution1 {
    public int maxProfit(int[] prices) {
        int n = prices.length;
        int minPrice = prices[0];
        int maxProfit = 0;

        for (int i = 1; i < n; i++) {
            minPrice = Math.min(prices[i], minPrice);
            int profit = prices[i] - minPrice;
            maxProfit = Math.max(profit, maxProfit);
        }
        return maxProfit;
    }
}