package solutions.nCr;

class Solution {
    public int nCr(int n, int r) {
        if (r > n)
            return 0;

        long res = 1;
        for (int i = 0; i < r; i++) {
            res = res * (n - i);
            res = res / (i + 1);
        }

        return (int) res;
    }
}