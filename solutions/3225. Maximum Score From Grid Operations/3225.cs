public class Solution
{
    // Approach: Dynamic programming by columns with two states per possible
    // boundary row: `pick` (current column contributes) and `skip` (current
    // column does not contribute). Transition all (prev, curr) boundary pairs
    // using per-column prefix sums to get segment sums in O(1).
    // Time: O(n^3) Space: O(n^2)
    public long MaximumScore(int[][] grid)
    {
        int n = grid.Length;
        // prefix[j][i] := the sum of the first i elements in the j-th column
        long[][] prefix = new long[n][];
        for (int j = 0; j < n; j++)
            prefix[j] = new long[n + 1];

        // prevPick[i] := the maximum achievable score up to the previous column,
        // where the bottommost selected element in that column is in row (i - 1)
        long[] prevPick = new long[n + 1];
        // prevSkip[i] := the maximum achievable score up to the previous column,
        // where the bottommost selected element in the column before the previous
        // one is in row (i - 1)
        long[] prevSkip = new long[n + 1];

        for (int j = 0; j < n; ++j)
        {
            for (int i = 0; i < n; ++i)
                prefix[j][i + 1] = prefix[j][i] + grid[i][j];
        }

        for (int j = 1; j < n; ++j)
        {
            long[] currPick = new long[n + 1];
            long[] currSkip = new long[n + 1];
            // Consider all possible combinations of the number of current and
            // previous selected elements.
            for (int curr = 0; curr <= n; ++curr)
                for (int prev = 0; prev <= n; ++prev)
                    if (curr > prev)
                    {
                        // 1. The current bottom is deeper than the previous bottom.
                        // Get the score of grid[prev..curr)[j - 1] for pick and skip.
                        long score = prefix[j - 1][curr] - prefix[j - 1][prev];
                        currPick[curr] = Math.Max(currPick[curr], prevSkip[prev] + score);
                        currSkip[curr] = Math.Max(currSkip[curr], prevSkip[prev] + score);
                    }
                    else
                    {
                        // 2. The previous bottom is deeper than the current bottom.
                        // Get the score of grid[curr..prev)[j] for pick only.
                        long score = prefix[j][prev] - prefix[j][curr];
                        currPick[curr] = Math.Max(currPick[curr], prevPick[prev] + score);
                        currSkip[curr] = Math.Max(currSkip[curr], prevPick[prev]);
                    }
            prevPick = currPick;
            prevSkip = currSkip;
        }

        return prevPick.Max();
    }
}