// Approach: Build a bitmask of all 1s with the same bit-length as n; XOR with n gives the complement.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int BitwiseComplement(int n)
    {
        int mask = 1;
        while (mask < n)
            mask = (mask << 1) + 1;
            
        return mask ^ n;
    }
}