public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int columnCount = strs[0].Length;
        int[] dp = Enumerable.Repeat(1, columnCount).ToArray();

        for (int currentCol = 1; currentCol < columnCount; ++currentCol)
        {
            for (int previousCol = 0; previousCol < currentCol; ++previousCol)
            {
                bool isNonDecreasing = true;
                foreach (var str in strs)
                {
                    if (str[previousCol] > str[currentCol])
                    {
                        isNonDecreasing = false;
                        break;
                    }
                }
                if (isNonDecreasing)
                    dp[currentCol] = Math.Max(dp[currentCol], dp[previousCol] + 1);
            }
        }

        int maxIncreasingLength = dp.Max();
        return columnCount - maxIncreasingLength;
    }
}