class Solution {
    public int kthMissing(int[] arr, int k) {
        // checking inside array
        for (int i = 0; i < arr.length; i++) {
            if (arr[i] <= k)
                k++;
            else
                break;
        }
        return k;
    }
}