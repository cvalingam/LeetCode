// Approach: Reverse the digits of n by repeatedly extracting the last digit.
// The mirror distance is simply the absolute difference between n and its digit-reverse.
// No extra space is needed beyond two integers.
// Time: O(log n) Space: O(1)
public class Solution
{
    public int MirrorDistance(int n)
    {
        return Math.Abs(n - Reverse(n));
    }

    private int Reverse(int x)
    {
        int y = 0;
        for (; x > 0; x /= 10)
            y = y * 10 + x % 10;

        return y;
    }
}