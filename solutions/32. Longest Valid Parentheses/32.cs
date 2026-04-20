// Approach: DP where dp[i] = length of the longest valid parentheses string ending at index i.
// If s[i] == ')' and s[i-1] == '(': dp[i] = dp[i-2] + 2 (direct match with immediate predecessor).
// If s[i] == ')' and s[i-1] == ')': check the char at i - dp[i-1] - 1.
//   If it is '(', then dp[i] = dp[i-1] + 2 + dp[i - dp[i-1] - 2] (extend through the prior valid run).
// The answer is the maximum dp value.
// Prepend ')' to avoid out-of-bounds indexing at position 0.
// Time: O(n) Space: O(n) for the dp array.

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