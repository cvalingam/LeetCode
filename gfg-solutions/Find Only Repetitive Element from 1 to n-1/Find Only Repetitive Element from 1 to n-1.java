// Approach: XOR all indices 1..n with all array elements. The repeated element XORs itself twice.
// Alternatively: sum formula or sign-flip marking.
// Time: O(n) Space: O(1)
class Solution {
    public int findDuplicate(int[] arr) {
        int xorr = 0;
        for (int i = 0; i < arr.length; i++)
            xorr ^= arr[i];

        for (int i = 1; i < arr.length; i++)
            xorr ^= i;

        return xorr;
    }
}