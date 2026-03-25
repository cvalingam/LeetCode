// Approach: XOR start and goal; count set bits (number of differing bit positions).
// Time: O(1) Space: O(1)

public class Solution
{
    public int MinBitFlips(int start, int goal)
    {
        int flip = 0;
        for (int i = 0; i < 32; i++)
        {
            int sBit = (start >> i) & 1;
            int gBit = (goal >> i) & 1;
            if (sBit != gBit)
                flip++;
        }

        return flip;
    }
}