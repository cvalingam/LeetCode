// Approach: XOR all elements. Duplicate elements cancel; the unique element remains.
// Time: O(n) Space: O(1)
class Solution {
    public int findUnique(int[] arr) {
        // code here
        int uniqueVal = 0;

        for (int val : arr)
            uniqueVal ^= val;

        return uniqueVal;
    }
}