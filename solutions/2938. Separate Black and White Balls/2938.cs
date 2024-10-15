public class Solution
{
    public long MinimumSteps(string s)
    {
        long ans = 0;
        int ones = 0;

        foreach (char c in s)
        {
            if (c == '1')
                ones++;
            else // Move 1s to the front of the current '0'.
                ans += ones;
        }

        return ans;
    }
}