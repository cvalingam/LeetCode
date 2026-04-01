
// Approach: DP with memoization. Count binary strings of length n with no two
// consecutive 1s. At each bit position, track the previous bit placed.
// If prev == 1, only 0 is allowed next; if prev == 0, both 0 and 1 are allowed.
// Sum results for strings starting with 0 and starting with 1.
// Time: O(n) Space: O(n)
class Solution {

    int[][] memo;

    public int solve(int bits, int prev, int n) {
        if (bits == n) {
            return 1;
        }

        if (memo[bits][prev] != -1) {
            return memo[bits][prev];
        }

        int totalCount = 0;
        if (prev == 0) {
            totalCount += solve(bits + 1, 1, n);
        }
        totalCount += solve(bits + 1, 0, n);

        return memo[bits][prev] = totalCount;
    }

    int countStrings(int n) {
        memo = new int[n][2];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < 2; j++) {
                memo[i][j] = -1;
            }
        }
        int forStartWith0 = solve(1, 0, n);
        int forStartWith1 = solve(1, 1, n);

        return forStartWith0 + forStartWith1;
    }
}
