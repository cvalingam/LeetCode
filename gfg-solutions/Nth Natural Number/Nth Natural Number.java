class Solution {
    long findNth(long n) {
        if (n < 9)
            return n;

        return findNth(n / 9) * 10 + n % 9;
    }
}