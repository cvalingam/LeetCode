public class Solution
{
    public int LongestValidParentheses(string s)
    {
        string s2 = ")" + s;
        // dp[i] := the length of the longest valid parentheses in the substring
        // s2[1..i]
        int[] dp = new int[s2.Length];

        for (int i = 1; i < s2.Length; ++i)
        {
            if (s2[i] == ')' && s2[i - dp[i - 1] - 1] == '(')
                dp[i] = dp[i - 1] + dp[i - dp[i - 1] - 2] + 2;
        }

        return dp.Max();
    }
}