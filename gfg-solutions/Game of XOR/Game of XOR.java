// Approach: Observe XOR pattern. XOR of a range [1..n] follows a 4-cycle pattern. Use prefix XOR.
// Time: O(n) Space: O(1)
class Solution {
    public int subarrayXor(int[] arr) {
        int n = arr.length;
        int total = 0;
        for (int i = 0; i < n; i++) {
            long freq = (long) (i + 1) * (n - i);
            if (freq % 2 != 0)
                total ^= arr[i];
        }
        return total;
    }
}