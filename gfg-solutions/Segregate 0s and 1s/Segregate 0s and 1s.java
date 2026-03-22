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
