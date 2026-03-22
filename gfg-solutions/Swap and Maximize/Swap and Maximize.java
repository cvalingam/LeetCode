class Solution {
    public long maxSum(Long[] arr) {
        Arrays.sort(arr);
        int n = arr.length;
        long sum = 0;
        for (int i = 0, j = n - 1; i < n && j >= 0; i++, j--)
            sum += Math.abs(arr[i] - arr[j]);

        return sum;
    }
}