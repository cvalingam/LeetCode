public class Solution
{
    public string ShortestCommonSupersequence(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;
        int[][] dp = tabulation(str1, str2, m, n);
        int i = m;
        int j = n;

        StringBuilder result = new StringBuilder();
        while (i > 0 && j > 0)
        {
            if (str1[i - 1] == str2[j - 1])
            {
                result.Append(str1[i - 1]);
                i--;
                j--;
            }
            else if (dp[i - 1][j] > dp[i][j - 1])
            {
                result.Append(str1[i - 1]);
                i--;
            }
            else
            {
                result.Append(str2[j - 1]);
                j--;
            }
        }

        while (i > 0)
        {
            result.Append(str1[i - 1]);
            i--;
        }

        while (j > 0)
        {
            result.Append(str2[j - 1]);
            j--;
        }

        char[] sArray = result.ToString().ToCharArray();
        Array.Reverse(sArray);

        return new string(sArray);
    }

    private int[][] tabulation(string text1, string text2, int m, int n)
    {
        int[][] dp = new int[m + 1][];
        for (int i = 0; i <= m; i++)
        {
            int[] arr = new int[n + 1];
            Array.Fill(arr, -1);
            dp[i] = arr;
            dp[i][0] = 0;
        }

        for (int j = 0; j <= n; j++)
            dp[0][j] = 0;

        for (int i = 1; i <= m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                    dp[i][j] = 1 + dp[i - 1][j - 1];
                else
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
            }
        }

        return dp;
    }
}