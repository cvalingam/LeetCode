public class Solution
{
    public long MinEnd(int n, int x)
    {
        // Set x's 0s with (n - 1)'s LSb-to-MSb bits, preserving x's 1s. This
        // operation increases x for (n - 1) iterations while preserving x's 1s.
        int kMaxBit = (int)(Math.Log2(n) + Math.Log2(x) + 2);
        long k = n - 1;
        long ans = x;
        int kBinaryIndex = 0;

        for (int i = 0; i < kMaxBit; ++i)
        {
            if ((ans >> i & 1) == 0)
            {
                // Set x's 0 with k's bit if the running bit of k is 1.
                if ((k >> kBinaryIndex & 1) == 1)
                    ans |= 1L << i;
                ++kBinaryIndex;
            }
        }

        return ans;
    }
}