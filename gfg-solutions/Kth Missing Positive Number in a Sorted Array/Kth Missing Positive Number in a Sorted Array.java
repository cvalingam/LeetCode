// Approach: Binary search. For index i, missing count = arr[i] - (i+1). Find where missing count >= k.
// Time: O(log n) Space: O(1)
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