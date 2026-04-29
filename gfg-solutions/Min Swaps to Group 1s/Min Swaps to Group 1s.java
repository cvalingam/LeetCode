
class Solution {

    // Approach: Count total ones, then use a fixed-size sliding window of length
    // `ones` to find the window with maximum ones already inside. The minimum
    // swaps needed is the number of zeros in that best window.
    // Time: O(n) Space: O(1)

    public int minSwaps(int[] arr) {
        int n = arr.length;
        int ones = 0;
        for (int x : arr) {
            if (x == 1) {
                ones++;
            }
        }
        if (ones == arr.length) {
            return 0;
        }
        if (ones == 0) {
            return -1;
        }
        int cnt = 0;
        for (int i = 0; i < ones; i++) {
            if (arr[i] == 1) {
                cnt++;
            }
        }
        int maxOnes = cnt;
        for (int i = ones; i < n; i++) {
            if (arr[i] == 1) {
                cnt++;
            }
            if (arr[i - ones] == 1) {
                cnt--;
            }
            maxOnes = Math.max(maxOnes, cnt);
        }
        
        return ones - maxOnes;
    }
}
