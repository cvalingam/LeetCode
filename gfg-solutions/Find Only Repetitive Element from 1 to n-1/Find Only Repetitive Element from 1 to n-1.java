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