// Approach: XOR n with n>>2; if the result has exactly one set bit
// (is a power of two or 1), the bits alternate.
// Time: O(1) Space: O(1)

public class Solution
{
    public bool HasAlternatingBits(int n)
    {
        //            n = 0b010101
        //       n >> 2 = 0b000101
        // n ^ (n >> 2) = 0b010000 = a
        //        a - 1 = 0b001111
        //  a & (a - 1) = 0
        int a = n ^ (n >> 2);
        return (a & (a - 1)) == 0;
    }
}