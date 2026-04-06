// Approach: Weighted digit sum modulo. Each digit position has a weight in {1,3,4,12,9,10} (mod 13 powers of 10).
// Time: O(n) Space: O(1)
class Solution {
    public boolean divby13(String s) {
        // Stores running remainder
        int rem = 0;

        // Process each digit and compute
        // remainder modulo 13
        for (int i = 0; i < s.length(); i++) {
            rem = (rem * 10 + (s.charAt(i) - '0')) % 13;
        }

        // Final check: if remainder is 0, number
        // is divisible by 13
        return rem == 0;
    }
}