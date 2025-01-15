public class Solution
{
    public int MinimizeXor(int num1, int num2)
    {
        const int kMaxBit = 30;
        int bits = CountBits(num2);
        // Can turn off all the bits in `num1`.
        if (CountBits(num1) == bits)
            return num1;

        int ans = 0;

        // Turn off the MSB if we have `bits` quota.
        for (int i = kMaxBit - 1; i >= 0; --i)
        {
            if ((num1 >> i & 1) == 1)
            {
                ans |= 1 << i;
                if (--bits == 0)
                    return ans;
            }
        }

        // Turn on the LSB if we still have `bits`.
        for (int i = 0; i < kMaxBit; ++i)
        {
            if ((num1 >> i & 1) == 0)
            {
                ans |= 1 << i;
                if (--bits == 0)
                    return ans;
            }
        }

        return ans;
    }

    private int CountBits(int number)
    {
        int count = 0;
        while (number > 0)
        {
            count += (number & 1);
            number >>= 1;
        }
        return count;
    }
}