class Solution {
    public int maxSubarrayXOR(int[] arr, int k) {
        int maxXOR = Integer.MIN_VALUE;

        int i = -1;
        int j = -1;
        int n = arr.length;
        int currXOR = 0;

        while (j < n) {
            if ((j - i) == k) {
                maxXOR = Math.max(maxXOR, currXOR);
                i++;
                currXOR ^= arr[i];
            }
            j++;
            if (j < n)
                currXOR ^= arr[j];
        }

        return maxXOR;
    }
}
