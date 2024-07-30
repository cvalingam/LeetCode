public class Solution
{
    public int MinimumDeletions(string s)
    {
        int dp = 0;
        int cntB = 0;

        foreach (char ch in s)
        {
            if (ch == 'a')
                dp = Math.Min(dp + 1, cntB);
            else
                cntB++;
        }

        return dp;
    }
}