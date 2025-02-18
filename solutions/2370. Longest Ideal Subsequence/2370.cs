public class Solution
{
    public int LongestIdealString(string s, int k)
    {
        int n = s.Length;
        int[] dp = new int[26];

        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int el = s[i] - 'a';
            for (int j = el; j >= 0 && j >= el - k; j--)
            {
                if (j == el && dp[j] == 0)
                {
                    dp[j] = 1;
                    ans = Math.Max(ans, dp[j]);
                    continue;
                }
                dp[el] = Math.Max(dp[el], dp[j] + 1);
            }

            for (int j = el + 1; j < 26 && j <= el + k; j++)
                dp[el] = Math.Max(dp[el], dp[j] + 1);

            ans = Math.Max(ans, dp[el]);
        }

        return ans;
    }
}