// Approach: DP tracking count of rows using 2-color pattern vs 3-color pattern; transitions per row follow fixed multiplicative rules.
// Time: O(n) Space: O(1)

public class Solution
{
    public int NumOfWays(int n)
    {
        const int MOD = 1_000_000_007;
        long color2 = 6; // 121, 131, 212, 232, 313, 323
        long color3 = 6; // 123, 132, 213, 231, 312, 321

        for (int i = 1; i < n; ++i)
        {
            long nextColor2 = color2 * 3 + color3 * 2;
            long nextColor3 = color2 * 2 + color3 * 2;
            color2 = nextColor2 % MOD;
            color3 = nextColor3 % MOD;
        }

        return (int)((color2 + color3) % MOD);
    }
}