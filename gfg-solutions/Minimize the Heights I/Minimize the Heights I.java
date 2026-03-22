class Solution {
    public int getMinDiff(int k, int[] arr) {
        int n = arr.length;
        if (n == 1) {
            return 0; // Single tower, no difference
        }

        // Sort the array
        Arrays.sort(arr);

        // Initial difference
        int initialDiff = arr[n - 1] - arr[0];
        int minDiff = initialDiff;

        // Base heights after adding/subtracting k
        int smallest = arr[0] + k;
        int largest = arr[n - 1] - k;

        // Traverse through the sorted array
        for (int i = 1; i < n; i++) {
            int minHeight = Math.min(smallest, arr[i] - k);
            int maxHeight = Math.max(largest, arr[i - 1] + k);
            minDiff = Math.min(minDiff, maxHeight - minHeight);
        }

        return minDiff;
    }
}