class Solution {
    public int getSecondLargest(int[] arr) {
        int l = arr[0];
        int sl = -1;
        for (int i = 1; i < arr.length; i++) {
            if (arr[i] > l) {
                sl = l;
                l = arr[i];
            } else if (arr[i] < l && arr[i] > sl) {
                sl = arr[i];
            }
        }
        return sl;
    }
}