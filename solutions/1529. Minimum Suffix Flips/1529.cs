// Approach: Greedily count each time the current state differs from target[i]; flip state on mismatch.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MinFlips(string target)
    {
        int ans = 0;
        int state = 0;

        foreach (char c in target)
        {
            if (c - '0' != state)
            {
                state = c - '0';
                ++ans;
            }
        }

        return ans;
    }
}