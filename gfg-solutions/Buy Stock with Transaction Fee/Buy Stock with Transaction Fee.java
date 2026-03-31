
// Approach: Greedy. Track the effective buying cost (fee adjusted).
// For each price, update max profit if selling now is better than current profit.
// Update the minimum effective buy price as min(fee, price - profit).
// Time: O(n) Space: O(1)
class Solution {

    public int maxProfit(int arr[], int k) {
        int profit = 0, fee = arr[0];

        for (int i = 1; i < arr.length; i++) {
            profit = Math.max(profit, (arr[i] - fee - k));
            fee = Math.min(fee, arr[i] - profit);
        }

        return profit;
    }
}
