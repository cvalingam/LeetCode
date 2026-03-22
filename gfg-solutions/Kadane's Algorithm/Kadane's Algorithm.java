class Solution {

    // arr: input array
    // Function to find the sum of contiguous subarray with maximum sum.
    long maxSubarraySum(int[] arr) {
        long ans = Integer.MIN_VALUE;
        long c = 0;

        for (int val : arr) {
            c += val;
            ans = Math.max(ans, c);
            c = c < 0 ? 0 : c;
        }

        return ans;
    }
}
