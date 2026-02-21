public class Solution
{
    public int CountPrimeSetBits(int left, int right)
    {
        // {2, 3, 5, 7, 11, 13, 17, 19}-th bits are 1s.
        // 0b10100010100010101100 = 665772
        const int magic = 665772;
        int ans = 0;

        for (int num = left; num <= right; ++num)
        {
            if (((magic >> CountBits(num)) & 1) == 1)
                ++ans;
        }

        return ans;
    }

    private int CountBits(int n)
    {
        int count = 0;
        while (n > 0)
        {
            count += n & 1;
            n >>= 1;
        }
        return count;
    }
}