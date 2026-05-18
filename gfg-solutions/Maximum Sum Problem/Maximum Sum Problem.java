
// Approach: Recursion with memoization. maxSum(n) = max(n, maxSum(n/2) + maxSum(n/3) + maxSum(n/4)).
// At each step, choose to either take n directly or split into smaller pieces.
// Memoize results to avoid recomputation.
// Time: O(n) Space: O(n)

class Solution {

    public int maxSum(int n) {
        if (n == 0) {
            return 0;
        }
        return Math.max(n, (maxSum(n / 2) + maxSum(n / 3) + maxSum(n / 4)));
    }
}
