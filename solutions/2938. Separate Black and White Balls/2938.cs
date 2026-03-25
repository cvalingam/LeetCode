// Approach: Count required swaps by tracking black balls encountered before each white position.
// Time: O(n) Space: O(1)

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