// Approach: First robot splits row0 (left prefix) and row1 (right prefix); second robot takes max of remainders.
// Time: O(n) Space: O(1)

public class Solution
{
    public long GridGame(int[][] grid)
    {
        int n = grid[0].Length;
        long ans = long.MaxValue;
        long sumRow0 = 0;
        for (int i = 0; i < n; i++)
            sumRow0 += grid[0][i];
        long sumRow1 = 0;

        for (int i = 0; i < n; ++i)
        {
            sumRow0 -= grid[0][i];
            ans = Math.Min(ans, Math.Max(sumRow0, sumRow1));
            sumRow1 += grid[1][i];
        }

        return ans;
    }
}