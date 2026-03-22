class Solution {
    static long sumMatrix(long n, long q) {
        if (q < 2 || q > 2 * n)
            return 0;
        else if (q <= n + 1)
            return q - 1;
        else
            return 2 * n - (q - 1);
    }
}