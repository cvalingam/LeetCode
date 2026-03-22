class Solution {
    public int subarraySum(int[] arr) {
        int n = arr.length;
        int totalSum = 0;

        // For each element, calculate its contribution to all subarrays
        for (int i = 0; i < n; i++)
            // Element at index i appears in:
            // - Subarrays starting at indices 0, 1, 2, ..., i (i+1 choices)
            // - Subarrays ending at indices i, i+1, i+2, ..., n-1 (n-i choices)
            // Total contribution = arr[i] * (i+1) * (n-i)
            totalSum += arr[i] * (i + 1) * (n - i);

        return totalSum;
    }
}
