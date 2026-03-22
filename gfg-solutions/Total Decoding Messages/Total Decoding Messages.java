import java.util.*;

class Solution {
    int[] dp;

    public int countWays(String digits) {
        dp = new int[digits.length() + 1];
        Arrays.fill(dp, -1);
        int ans = countDecodes(0, digits);
        return ans;
    }

    private int countDecodes(int i, String digits) {
        if (i >= digits.length())
            return 1;
        else if (digits.charAt(i) == '0')
            return 0;
        else if (dp[i] != -1)
            return dp[i];

        dp[i] = countDecodes(i + 1, digits);
        int digit1 = digits.charAt(i) - '0';
        if (i + 1 < digits.length() && (digit1 == 1 || (digit1 == 2 && digits.charAt(i + 1) <= '6')))
            dp[i] += countDecodes(i + 2, digits);

        return dp[i];
    }
}