// Approach: Scan from the end of the string skipping trailing spaces,
// then count characters until the next space or the start.
// Time: O(n) Space: O(1)

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int n = s.Length;

        int len = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == ' ' && len == 0)
                continue;
            else if (s[i] == ' ')
                return len;

            len++;
        }

        return len;
    }
}