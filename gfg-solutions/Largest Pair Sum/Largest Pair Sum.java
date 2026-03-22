class Solution {
    public static int pairsum(int[] arr) {
        int first = Math.max(arr[0], arr[1]);
        int second = Math.min(arr[0], arr[1]);
        for (int i = 2; i < arr.length; i++) {
            if (arr[i] >= first) {
                second = first;
                first = arr[i];
            } else if (arr[i] > second) {
                second = arr[i];
            }
        }
        return first + second;
    }
}
