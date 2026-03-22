class Solution {
    public int maxSubarraySum(int[] arr, int k) {
        int n = arr.length;

        int windowSum = 0;
        int maxSum = 0;

        for (int i = 0; i < k; i++)
            windowSum += arr[i];

        maxSum = windowSum;

        for (int i = k; i < n; i++) {
            windowSum += arr[i];
            windowSum -= arr[i - k];
            maxSum = Math.max(maxSum, windowSum);
        }

        return maxSum;
    }
}