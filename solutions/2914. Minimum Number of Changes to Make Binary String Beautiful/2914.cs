// Approach: Scan even-indexed pairs; each mismatched pair costs 1 change.
// Time: O(n) Space: O(1)

public class Solution
{
    public int MinChanges(string s)
    {
        int ans = 0;

        for (int i = 0; i + 1 < s.Length; i += 2)
        {
            if (s[i] != s[i + 1])
                ++ans;
        }

        return ans;
    }
}