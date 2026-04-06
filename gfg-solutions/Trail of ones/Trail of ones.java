// Approach: DP counting binary strings of length n with no two consecutive 1s.
// dp[i][0] = dp[i-1][0] + dp[i-1][1]; dp[i][1] = dp[i-1][0].
// Time: O(n) Space: O(1)
class Solution {
    public int countConsec(int n) {
        if (n == 2)
            return 1;
            
        int st = 1, fib1 = 0, fib2 = 1;
        for (int i = 3; i <= n; i++) {
            st = 2 * st + (fib2 + fib1);
            int temp = fib2;
            fib2 = fib1 + fib2;
            fib1 = temp;
        }

        return st;
    }
}
