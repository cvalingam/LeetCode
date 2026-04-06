// Approach: Dutch National Flag (2-way). Two pointers: swap 0s to front and 1s to back.
// Time: O(n) Space: O(1)
class Solution {
    void segregate0and1(int[] arr) {
        int low = 0, n = arr.length;
        int high = n - 1;

        for (int i = 0; i < n && i <= high; i++) {
            if (arr[i] == 0) {
                int temp = arr[low];
                arr[low] = arr[i];
                arr[i] = temp;
                low++;
            }
        }
    }
}
