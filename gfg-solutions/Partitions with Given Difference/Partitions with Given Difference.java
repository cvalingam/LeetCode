
// Approach: If the array sums to total, two subsets S1 and S2 where S1-S2=d require S1=(total+d)/2.
// Return early if (total+d) is odd or d>total. Then count subsets with sum=(total+d)/2 using
// 0/1 knapsack DP: dp[i][j] = number of subsets of first i elements that sum to j.
// Time: O(n*sum) Space: O(n*sum)
class Solution {

    public int countPartitions(int[] arr, int d) {
        int totalsum = 0;
        for (int num : arr) {
            totalsum += num;
        }
        if ((totalsum + d) % 2 != 0 || d > totalsum) {
            return 0;
        }
        int sum = (d + totalsum) / 2;
        
        return countSubsets(arr, sum);
    }

    int countSubsets(int[] arr, int sum) {
        int n = arr.length;
        int[][] dp = new int[n + 1][sum + 1];
        for (int i = 0; i <= n; i++) {
            dp[i][0] = 1;
        }
        for (int i = 1; i <= n; i++) {
            for (int j = 0; j <= sum; j++) {
                if (arr[i - 1] <= j) {
                    dp[i][j] = dp[i - 1][j - arr[i - 1]] + dp[i - 1][j];
                } else {
                    dp[i][j] = dp[i - 1][j];
                }
            }
        }

        return dp[n][sum];
    }
}
