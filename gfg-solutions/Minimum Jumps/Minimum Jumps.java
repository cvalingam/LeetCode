class Solution {
    static int minJumps(int[] arr) {
        int n = arr.length;
        if (n == 0 || arr[0] == 0)
            return -1;

        if (n == 1)
            return 0;

        int jumps = 0, currentEnd = 0, farthest = 0;
        for (int i = 0; i < n; i++) {
            farthest = Math.max(farthest, arr[i] + i);

            if (i == currentEnd) {
                jumps++;
                currentEnd = farthest;
            }

            if (currentEnd >= n - 1)
                return jumps;
        }

        return -1;
    }
}