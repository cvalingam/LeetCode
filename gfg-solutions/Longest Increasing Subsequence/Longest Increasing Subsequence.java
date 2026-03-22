class Solution {
    static int lis(int arr[]) {
        int n = arr.length;
        if (n == 0)
            return 0; // Although constraint says size >= 1, good to handle empty case.

        int[] dp = new int[n];
        Arrays.fill(dp, 1); // Initialize dp array with 1s

        for (int i = 1; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (arr[j] < arr[i])
                    dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }

        int maxLen = 0;
        for (int len : dp)
            maxLen = Math.max(maxLen, len);

        return maxLen;
    }
}