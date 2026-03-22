class Solution {
    long floorSqrt(long n) {
        if (n == 0 || n == 1)
            return n;

        long start = 1, end = n, ans = 0;

        while (start <= end) {
            long mid = (start + end) / 2;

            if (mid <= (n / mid)) {
                ans = mid;
                start = mid + 1;
            } else {
                end = mid - 1;
            }
        }

        return ans;
    }
}