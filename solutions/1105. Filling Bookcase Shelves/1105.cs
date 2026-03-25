// Approach: DP where dp[i] = min total height for first i books; for each book i try starting a new shelf or extending the current one backwards.
// Time: O(n²) Space: O(n)

public class Solution
{
    public int MinHeightShelves(int[][] books, int shelfWidth)
    {
        int n = books.Length;
        int[] dp = new int[n + 1];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;

        for (int i = 0; i < books.Length; ++i)
        {
            int sumThickness = 0;
            int maxHeight = 0;
            for (int j = i; j >= 0; --j)
            {
                int thickness = books[j][0];
                int height = books[j][1];
                sumThickness += thickness;
                if (sumThickness > shelfWidth)
                    break;
                maxHeight = Math.Max(maxHeight, height);
                dp[i + 1] = Math.Min(dp[i + 1], dp[j] + maxHeight);
            }
        }

        return dp[n];
    }
}