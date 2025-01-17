public class Solution
{
    public int FindTheLongestBalancedSubstring(string s)
    {
        int ans = 0;
        int zeros = 0;
        int ones = 0;

        foreach (char c in s)
        {
            if (c == '0')
            {
                zeros = ones > 0 ? 1 : zeros + 1;
                ones = 0;
            }
            else
                ones++;

            if (zeros >= ones)
                ans = Math.Max(ans, ones);
        }

        return ans * 2;
    }
}