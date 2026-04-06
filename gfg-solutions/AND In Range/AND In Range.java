// Approach: Bit manipulation. The AND of all numbers in [l, r] keeps only common prefix bits.
// Right-shift both numbers until they are equal, tracking the shift count, then shift back.
// Time: O(log n) Space: O(1)
class Solution {
    public int andInRange(int l, int r) {
        // Answer will be the common part of binary l and r from msb. As all other will
        // give zero for & operation which are not common.
        int count = 0; // will store the number of bits removed from lsb
        while (l != r) {
            l >>= 1; // remove a bit from left
            r >>= 1; // remove a bit from left
            count++; // update removed count
        }
        
        return l << count; // add zeroes to right after common part
    }
}
