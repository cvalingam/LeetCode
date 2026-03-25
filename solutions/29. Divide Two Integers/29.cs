// Approach: Bit-shift doubling — repeatedly double the divisor while it fits,
// accumulate the quotient, and subtract; use long to avoid overflow.
// Time: O(log²n) Space: O(1)

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (divisor == 1)
            return dividend;

        if (dividend == int.MinValue && divisor == -1)
            return int.MaxValue;

        bool sign = (dividend > 0 && divisor > 0) || (dividend < 0 && divisor < 0);
        dividend = dividend > 0 ? -dividend : dividend;
        divisor = divisor > 0 ? -divisor : divisor;
        int ans = 0;
        while (dividend <= divisor)
        {
            int x = divisor;
            int cnt = 1;
            while (x >= (int.MinValue >> 1) && dividend <= (x << 1))
            {
                x <<= 1;
                cnt <<= 1;
            }
            ans += cnt;
            dividend -= x;
        }
        return sign ? ans : -ans;
    }
}