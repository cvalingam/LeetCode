class Solution {
    public int alternatingMaxLength(int[] arr) {
        int n = arr.length;

        int inc = 1;
        int dec = 1;

        for (int i = 1; i < n; i++) {
            if (arr[i] > arr[i - 1])
                inc = dec + 1;
            else if (arr[i] < arr[i - 1])
                dec = inc + 1;
        }

        return Math.max(inc, dec);
    }
}