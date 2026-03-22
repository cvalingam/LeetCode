class Solution {
    public int findUnique(int[] arr) {
        // code here
        int uniqueVal = 0;

        for (int val : arr)
            uniqueVal ^= val;

        return uniqueVal;
    }
}