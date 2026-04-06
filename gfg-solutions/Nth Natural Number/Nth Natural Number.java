// Approach: Skip numbers containing digit 9 (since we use base-9 style counting). Convert position to base-9.
// Time: O(log n) Space: O(1)
class Solution {
    long findNth(long n) {
        if (n < 9)
            return n;

        return findNth(n / 9) * 10 + n % 9;
    }
}