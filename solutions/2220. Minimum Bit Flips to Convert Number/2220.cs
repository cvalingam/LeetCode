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