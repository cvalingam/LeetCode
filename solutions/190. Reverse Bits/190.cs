// Approach: Iterate 32 times — shift the result left, extract the LSB of n
// and append it, then shift n right.
// Time: O(1) Space: O(1)

public class Solution
{
    public uint ReverseBits(uint n)
    {
        uint ans = 0;

        for (int i = 0; i < 32; i++)
        {
            ans <<= 1;
            if ((n & 1) == 1)
                ans += 1;
            n >>= 1;
        }

        return ans;
    }
}

public class Solution1
{
    public int ReverseBits(int n)
    {
        int ans = 0;

        for (int i = 0; i < 32; i++)
        {
            ans <<= 1;
            if ((n & 1) == 1)
                ans += 1;
            n >>= 1;
        }

        return ans;
    }
}