// Approach: Track previous and current group lengths; at each group boundary,
// add min(prev, curr) valid substrings to the answer.
// Time: O(n) Space: O(1)

public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int ans = 0;
        int prevEquals = 0;
        int currEquals = 1;

        for (int i = 0; i + 1 < s.Length; ++i)
        {
            if (s[i] == s[i + 1])
                ++currEquals;
            else
            {
                ans += Math.Min(prevEquals, currEquals);
                prevEquals = currEquals;
                currEquals = 1;
            }
        }

        return ans + Math.Min(prevEquals, currEquals);
    }
}