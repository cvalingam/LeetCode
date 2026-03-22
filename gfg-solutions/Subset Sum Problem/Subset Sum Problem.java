class Solution {

    static Boolean isSubsetSum(int arr[], int sum) {
        int[][] dp = new int[arr.length][10001];

        for (int i = 0; i < dp.length; i++) {
            for (int j = 0; j < dp[0].length; j++)
                dp[i][j] = -1;
        }

        return dfs(arr, 0, 0, sum, dp);
    }

    static Boolean dfs(int[] arr, int ind, int curSum, int sum, int[][] dp) {
        if (curSum == sum)
            return true;

        if (ind >= arr.length)
            return false;

        if (curSum > sum)
            return false;

        if (dp[ind][curSum] != -1)
            return dp[ind][curSum] == 1;

        boolean take = dfs(arr, ind + 1, arr[ind] + curSum, sum, dp);
        if (take) {
            dp[ind][curSum] = 1;
            return take;
        }
        boolean notTake = dfs(arr, ind + 1, curSum, sum, dp);
        dp[ind][curSum] = notTake == true ? 1 : 0;

        return notTake;
    }
}