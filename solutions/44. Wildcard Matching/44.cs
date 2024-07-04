public class Solution
{
    public bool IsMatch(string s, string p)
    {
        int n = p.Length;
        int m = s.Length;

        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            int[] arr = new int[m + 1];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }

        //return topDown(n, m, p, s, dp);
        return tabulation(n, m, p, s);
    }

    private bool topDown(int i, int j, string p, string s, int[][] dp)
    {
        if (i == 0 && j == 0)
            return true;
        if (i == 0 && j > 0)
            return false;
        if (i > 0 && j == 0)
        {
            for (int k = 1; k <= i; k++)
            {
                if (p[k - 1] != '*')
                    return false;
            }
            return true;
        }

        if (dp[i][j] != -1)
            return dp[i][j] > 0;

        if (p[i - 1] == s[j - 1] || p[i - 1] == '?')
        {
            bool match = topDown(i - 1, j - 1, p, s, dp);
            dp[i][j] = match == true ? 1 : 0;
            return match;
        }

        if (p[i - 1] == '*')
        {
            bool sequence = topDown(i - 1, j, p, s, dp) || topDown(i, j - 1, p, s, dp);
            dp[i][j] = sequence == true ? 1 : 0;
            return sequence;
        }

        dp[i][j] = 0;
        return false;
    }

    private bool tabulation(int n, int m, string p, string s)
    {
        int[][] dp = new int[n + 1][];
        for (int i = 0; i <= n; i++)
        {
            int[] arr = new int[m + 1];
            Array.Fill(arr, -1);
            dp[i] = arr;
        }
        dp[0][0] = 1;

        for (int j = 1; j <= m; j++)
            dp[0][j] = 0;

        for (int i = 1; i <= n; i++)
        {
            bool flag = true;
            for (int k = 1; k <= i; k++)
            {
                if (p[k - 1] != '*')
                {
                    flag = false;
                    break;
                }
            }
            dp[i][0] = flag == true ? 1 : 0;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (p[i - 1] == s[j - 1] || p[i - 1] == '?')
                    dp[i][j] = dp[i - 1][j - 1];
                else if (p[i - 1] == '*')
                {
                    if (dp[i - 1][j] == 1 || dp[i][j - 1] == 1)
                        dp[i][j] = 1;
                    else
                        dp[i][j] = 0;
                }
                else
                    dp[i][j] = 0;
            }
        }

        return dp[n][m] > 0;
    }
}