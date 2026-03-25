// Approach: Single pass through bits; track the distance from the last seen set bit and update the maximum.
// Time: O(log n) Space: O(1)

public class Solution
{
    public int BinaryGap(int n)
    {
        int ans = 0;

        // d := the distance between any two 1s
        for (int d = -32; n > 0; n /= 2, ++d)
        {
            if (n % 2 == 1)
            {
                ans = Math.Max(ans, d);
                d = 0;
            }
        }

        return ans;
    }
}