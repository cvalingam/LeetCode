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