class Solution {
    public int minimizeCost(int k, int arr[]) {
        int n = arr.length;
        int[] dp = new int[n];

        Arrays.fill(dp, -1);

        return getMinCost(arr, k, 0, dp);
    }

    public int getMinCost(int[] arr, int k, int index, int[] dp) {
        if (index == arr.length - 1)
            return 0;

        if (dp[index] != -1)
            return dp[index];

        int mini = Integer.MAX_VALUE;

        for (int i = 1; i <= k && (index + i < arr.length); i++) {
            int cost = Math.abs(arr[index + i] - arr[index]) + getMinCost(arr, k, index + i, dp);

            mini = Math.min(mini, cost);
        }
        dp[index] = mini;

        return mini;
    }
}