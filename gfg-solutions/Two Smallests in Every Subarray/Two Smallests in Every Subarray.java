class Solution {
    public int pairWithMaxSum(int[] arr) {
        int n = arr.length;
        if (n < 2)
            return -1;

        int c = arr[0] + arr[1];

        for (int i = 1; i < n - 1; i++)
            c = Math.max(c, arr[i] + arr[i + 1]);

        return c;
    }
}