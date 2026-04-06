// Approach: Sliding window XOR. Maintain running XOR; for a window of size k, slide and track max XOR.
// Time: O(n) Space: O(1)
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
